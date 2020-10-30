// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Operations;
using Silk.NET.Maths.GenericsGenerator.ValueTypes;
using Silk.NET.Maths.GenericsGenerator.VariableTypes;

namespace Silk.NET.Maths.GenericsGenerator
{
    public partial class OperationWalker : Microsoft.CodeAnalysis.Operations.OperationWalker
    {
        private ITypeSymbol _floatType;
        private ITypeSymbol _intType;
        private ITypeSymbol _boolType;
        private int _returnCount = 0;
        private Dictionary<string, IVariable> _locals;
        private List<LocalReferenceValue> _localReferences;
        private Location _currentLocation;
        private Stack<Scope> _scopes;
        private Scope? _scope;
        private Stack<IValue> _values;
        private IValue? _value;

        private sealed class DebugScopeBuilder
        {
            private TextWriter _writer;
            private int _level = 1;

            public DebugScopeBuilder(TextWriter writer)
            {
                _writer = writer;
            }

            private void Indent()
            {
                _writer.Write(new string(' ', _level * 2));
            }
            
            [Conditional("DEBUG")]
            public void Begin(char type, string s)
            {
                _writer.Write(type);
                Indent();
                _writer.WriteLine(s);
                _level++;
            }

            [Conditional("DEBUG")]
            public void End()
            {
                _level--;
            }
        }
        
        private DebugScopeBuilder _debugScopeBuilder;

        private void BeginScope(IValue condition)
        {
            var v = new Scope {Condition = condition};
            if (_scope is not null)
            {
                v.Parent = _scope;
                _scopes.Push(_scope);
            }

            _scope = v;
        }

        private void EndScope()
        {
            if (_scope is null)
                throw new InvalidOperationException("Cannot end scope when no scope has begun");
            
            if (_scopes.Count > 0)
            {
                var v = _scope;
                _scope = _scopes.Pop();
                _scope.Scopeables.Add(v);
            }
            else
            {
                // _scope is root, callers are asked to pop it off the stack
                _scopes.Push(_scope);
                _scope = null;
            }
        }

        private void BeginValue(IValue value)
        {
            if (_value is not null)
            {
                value.Parent = _value;
                _values.Push(_value);
            }
            _value = value;
        }

        private void EndValue()
        {
            if (_value is null)
                throw new InvalidOperationException("Cannot end value when no value has begun");
            
            if (_values.Count > 0)
            {
                var v = _value;
                _value = _values.Pop();
                _value.AddChild(v);
            }
            else
            {
                // _value is root, callers are asked to pop it off the stack
                _values.Push(_value);
                _value = null;
            }
        }
        
        public Scope? RootVisit(GeneratorExecutionContext context, IOperation root)
        {
            TextWriter file = TextWriter.Null;
#if DEBUG
            // file = File.CreateText(@"C:\Silk.NET\src\Lab\GenericMaths\debug.txt");
#endif

            _debugScopeBuilder = new DebugScopeBuilder(file);
            _values = new Stack<IValue>();
            _scopes = new Stack<Scope>();
            _locals = new Dictionary<string, IVariable>();
            _localReferences = new List<LocalReferenceValue>();
            _floatType = context.Compilation.GetSpecialType(SpecialType.System_Single);
            _intType = context.Compilation.GetSpecialType(SpecialType.System_Int32);
            _boolType = context.Compilation.GetSpecialType(SpecialType.System_Boolean);
            try
            {
                _currentLocation = root.Syntax.GetLocation();
                _debugScopeBuilder.Begin('S', "ROOT");
                BeginScope(new LiteralValue(true));
                base.Visit(root);
            }
            catch (DiagnosticException ex)
            {
                context.ReportDiagnostic(ex.Diagnostic);
            }
            catch (Exception ex)
            {
                context.ReportDiagnostic(Diagnostic.Create(Diagnostics.UnexpectedWalkerException, _currentLocation, ex.ToString()));
            }

            ResolveReferences();
            _debugScopeBuilder.End();
            file.WriteLine();
            file.WriteLine();
            file.WriteLine();
            _scope.DebugWrite(file);
            file.Flush();
            file.Dispose();
            return _scope;
        }

        private Type AsInternalType(ITypeSymbol symbol)
        {
            if (SymbolEqualityComparer.IncludeNullability.Equals(symbol, _boolType))
                return Type.Boolean;

            if (SymbolEqualityComparer.IncludeNullability.Equals(symbol, _intType)
            || SymbolEqualityComparer.IncludeNullability.Equals(symbol, _floatType))
                return Type.Numeric;

            return Type.Unknown;
        }

        private void ResolveReferences()
        {
            for (var index = 0; index < _localReferences.Count; index++)
            {
                var localReference = _localReferences[index];
                if (localReference.LocalVariable is not null)
                    continue;
                localReference.LocalVariable = _locals[localReference.Name];
                _locals[localReference.Name].References.Add(localReference);
                _localReferences[index] = localReference;
            }
        }

        public override void VisitConditional(IConditionalOperation operation)
        {
            _currentLocation = operation.Syntax.GetLocation();
            
            _debugScopeBuilder.Begin('S', "BEGIN IF");
            _debugScopeBuilder.Begin('C', "BEGIN CONDITION");
            base.Visit(operation.Condition);
            _debugScopeBuilder.End();
            _debugScopeBuilder.Begin('S', "BEGIN TRUE");
            var condition = _values.Pop();
            BeginScope(condition);
            base.Visit(operation.WhenTrue);
            EndScope();
            _debugScopeBuilder.End();
            _debugScopeBuilder.Begin('S', "BEGIN FALSE");
            BeginScope(new NegateValue {Child = condition});
            base.Visit(operation.WhenFalse);
            EndScope();
            _debugScopeBuilder.End();
        }

        public override void VisitBlock(IBlockOperation operation)
        {
            _currentLocation = operation.Syntax.GetLocation();
            
            _debugScopeBuilder.Begin('S', $"BEGIN SCOPE");
            BeginScope(new LiteralValue(true));
            base.VisitBlock(operation);
            EndScope();
            _debugScopeBuilder.End();
        }

        public override void VisitSimpleAssignment(ISimpleAssignmentOperation operation)
        {
            if (operation.Target is ILocalReferenceOperation localReferenceOperation)
            {
                _debugScopeBuilder.Begin('A', $"Assign {localReferenceOperation.Local.Name}");
                base.Visit(operation.Value);
                var v = new AssignmentVariable(localReferenceOperation.Local.Name, _values.Pop());
                _scope.Scopeables.Add(v);
                _locals[localReferenceOperation.Local.Name].ExtraReferences++;
                _locals[localReferenceOperation.Local.Name] = v;
                _debugScopeBuilder.End();
            } else if (operation.Target is IParameterReferenceOperation parameterReferenceOperation)
            {
                _debugScopeBuilder.Begin('A', $"Assign {parameterReferenceOperation.Parameter.Name}");
                base.Visit(operation.Value);
                _scope.Scopeables.Add(new AssignmentVariable(parameterReferenceOperation.Parameter.Name, _values.Pop()));
                _debugScopeBuilder.End();
            } else if (operation.Target is IPropertyReferenceOperation propertyReferenceOperation)
            {
                _debugScopeBuilder.Begin('A', $"Assign {propertyReferenceOperation.Property.Name}");
                base.Visit(operation.Value);
                _scope.Scopeables.Add(new AssignmentVariable(propertyReferenceOperation.Property.Name, _values.Pop()));
                _debugScopeBuilder.End();
            }
            else
            {
                throw new DiagnosticException(Diagnostic.Create(Diagnostics.UnsupportedMember, _currentLocation, operation.GetType()));
            }
        }

        public override void VisitFieldReference(IFieldReferenceOperation operation)
        {
            _currentLocation = operation.Syntax.GetLocation();
            
            _debugScopeBuilder.Begin('V', $"Ref {operation.Field.Name}");
            BeginValue(new FieldReferenceValue(operation.Field.Name, AsInternalType(operation.Field.Type)));
            base.VisitFieldReference(operation);
            EndValue();
            _debugScopeBuilder.End();
        }

        public override void VisitPropertyReference(IPropertyReferenceOperation operation)
        {
            _currentLocation = operation.Syntax.GetLocation();
            
            _debugScopeBuilder.Begin('V', $"Ref {operation.Property.Name}");
            BeginValue(new PropertyReferenceValue(operation.Property.Name, AsInternalType(operation.Property.Type)));
            base.VisitPropertyReference(operation);
            EndValue();
            _debugScopeBuilder.End();
        }

        public override void VisitParameterReference(IParameterReferenceOperation operation)
        {
            _currentLocation = operation.Syntax.GetLocation();
        
            _debugScopeBuilder.Begin('V', $"Ref {operation.Parameter.Name}");
            BeginValue(new ParameterReferenceValue(operation.Parameter.Name, AsInternalType(operation.Parameter.Type)));
            base.VisitParameterReference(operation);
            EndValue();
            _debugScopeBuilder.End();
        }

        public override void VisitReturn(IReturnOperation operation)
        {
            _currentLocation = operation.Syntax.GetLocation();
            
            _returnCount++;
            if (_returnCount > 1)
            {
                throw new DiagnosticException(Diagnostic.Create(Diagnostics.ComplexReturn, _currentLocation));
            }

            _debugScopeBuilder.Begin('R', "Return");
            base.VisitReturn(operation);
            _scope.Scopeables.Add(new ReturnVariable(_values.Pop()));
            _debugScopeBuilder.End();
        }

        public override void VisitVariableDeclaration(IVariableDeclarationOperation operation)
        {
            _currentLocation = operation.Syntax.GetLocation();
            
            _debugScopeBuilder.Begin('L', $"Local declaration");
            foreach (var declarator in operation.Declarators)
            {
                _debugScopeBuilder.Begin('D', $"Declaration {declarator.Symbol.Name}");
                base.VisitVariableDeclarator(declarator);
                var v = new LocalVariable(declarator.Symbol.Name, _values.Pop());
                _scope.Scopeables.Add(v);
                _locals[declarator.Symbol.Name] = v;
                _debugScopeBuilder.End();
            }

            _debugScopeBuilder.End();
        }

        public override void VisitLocalReference(ILocalReferenceOperation operation)
        {
            _currentLocation = operation.Syntax.GetLocation();
            
            _debugScopeBuilder.Begin('V', $"Ref {operation.Local.Name}");
            var r = new LocalReferenceValue(operation.Local.Name);
            BeginValue(r);
            _localReferences.Add(r);
            base.VisitLocalReference(operation);
            EndValue();
            _debugScopeBuilder.End();

            if (_locals.TryGetValue(r.Name, out var v))
            {
                r.LocalVariable = v;
                v.References.Add(r);
            }
        }

        public override void VisitBinaryOperator(IBinaryOperation operation)
        {
            _currentLocation = operation.Syntax.GetLocation();

            BinaryOperatorValue value = operation.OperatorKind switch
            {
                BinaryOperatorKind.Add => new AddValue(),
                BinaryOperatorKind.Subtract => new SubtractValue(),
                BinaryOperatorKind.Multiply => new MultiplyValue(),
                BinaryOperatorKind.Divide => new DivideValue(),
                /*BinaryOperatorKind.IntegerDivide => new IntegerDivideValue(),
                BinaryOperatorKind.Remainder => new RemainderValue(),
                BinaryOperatorKind.LeftShift => new LeftShiftValue(),
                BinaryOperatorKind.RightShift => new RightShiftValue(),
                BinaryOperatorKind.And => new AndValue(),
                BinaryOperatorKind.Or => new OrValue(),
                BinaryOperatorKind.ExclusiveOr => new XorValue(),*/
                BinaryOperatorKind.ConditionalAnd => new ConditionalAndValue(),
                BinaryOperatorKind.ConditionalOr => new ConditionalOrValue(),
                BinaryOperatorKind.Equals => new EqualsValue(),
                BinaryOperatorKind.NotEquals => new NotEqualsValue(),
                BinaryOperatorKind.LessThan => new LessThanValue(),
                BinaryOperatorKind.LessThanOrEqual => new LessThanOrEqualValue(),
                BinaryOperatorKind.GreaterThanOrEqual => new GreaterThanOrEqualValue(),
                BinaryOperatorKind.GreaterThan => new GreaterThanValue(),
                _ => throw new DiagnosticException
                (
                    Diagnostic.Create
                    (
                        Diagnostics.UnsupportedOperator, _currentLocation,
                        Enum.GetName(typeof(BinaryOperatorKind), operation.OperatorKind)
                    )
                )
            };

            _debugScopeBuilder.Begin('V', $"Binary {Enum.GetName(typeof(BinaryOperatorKind), operation.OperatorKind)}");
            BeginValue(value);
            base.VisitBinaryOperator(operation);
            EndValue();
            _debugScopeBuilder.End();
        }

        public override void VisitUnaryOperator(IUnaryOperation operation)
        {
            _currentLocation = operation.Syntax.GetLocation();

            UnaryOperatorValue? value = operation.OperatorKind switch
            {
                UnaryOperatorKind.Plus => null, // ignore
                UnaryOperatorKind.Minus => new NegateValue(),
                _ => throw new DiagnosticException
                (
                    Diagnostic.Create
                    (
                        Diagnostics.UnsupportedOperator, _currentLocation,
                        Enum.GetName(typeof(UnaryOperatorKind), operation.OperatorKind)
                    )
                )
            };

            _debugScopeBuilder.Begin('V', $"Unary {Enum.GetName(typeof(UnaryOperatorKind), operation.OperatorKind)}");
            if (value is not null) 
                BeginValue(value);

            base.VisitUnaryOperator(operation);
            
            if (value is not null)
                EndValue();
            _debugScopeBuilder.End();
        }

        public override void VisitLiteral(ILiteralOperation operation)
        {
            _currentLocation = operation.Syntax.GetLocation();
            
            if (!operation.ConstantValue.HasValue)
            {
#if DEBUG
                Debugger.Launch();
                Debugger.Break();
#endif
                Debug.Fail("non-constant literal?!");
            }
            
            var t = AsInternalType(operation.Type);
            if (t == Type.Unknown)
            {
                throw new DiagnosticException(Diagnostic.Create(Diagnostics.TypeMissmatch, _currentLocation, operation.Type.Name));
            }
            _debugScopeBuilder.Begin('V', $"Literal {operation.ConstantValue.Value}");
            var val = operation.ConstantValue.Value;
            if (val is int i)
                val = (float) i;
            BeginValue(new LiteralValue(val, t));
            base.VisitLiteral(operation);
            EndValue();
            _debugScopeBuilder.End();
        }
    }
}
