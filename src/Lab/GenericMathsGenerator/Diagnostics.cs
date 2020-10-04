﻿// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Microsoft.CodeAnalysis;

namespace GenericMathsGenerator
{
    public static class Diagnostics
    {
        public static DiagnosticDescriptor UnsupportedOperator { get; } = new DiagnosticDescriptor
        (
            "GM0001",
            "Unsupported Operator", 
            "{0} is unsupported, please file an issue",
            "Internal",
            DiagnosticSeverity.Error,
            true,
            null,
            null,
            WellKnownDiagnosticTags.AnalyzerException
        );

        public static DiagnosticDescriptor TypeMissmatch { get; } = new DiagnosticDescriptor(
            "GM0002",
            "Type Missmatch",
            "Type {0} is not supported",
            "",
            DiagnosticSeverity.Error,
            true,
            null,
            null);

        public static DiagnosticDescriptor IncompleteExpression { get; } = new DiagnosticDescriptor(
            "GM0003",
            "Incomplete Expression",
            "There are {0} values unset. This indicates an incomplete expression.",
            "",
            DiagnosticSeverity.Warning,
            true,
            null,
            null);

        public static DiagnosticDescriptor ComplexReturn { get; } = new DiagnosticDescriptor(
            "GM0004",
            "Complex Return Statement",
            "You are doing something more complicated with returns, which is currently not supported",
            "",
            DiagnosticSeverity.Warning,
            true,
            null,
            null);

        public static DiagnosticDescriptor NoReturn { get; } = new DiagnosticDescriptor(
            "GM0005",
            "No Return Statement",
            "Could not find Return",
            "",
            DiagnosticSeverity.Error,
            true,
            null,
            null);

        public static DiagnosticDescriptor TypeNotPartial { get; } = new DiagnosticDescriptor(
            "GM0006",
            "Containing Type not partial",
            "The types containing methods marked for processing have to be partial",
            "",
            DiagnosticSeverity.Error,
            true,
            null,
            null);

        public static DiagnosticDescriptor UnsupportedMember { get; } = new DiagnosticDescriptor(
            "GM0007",
            "Unsupported Member",
            "Members of type {0} are not supported",
            "",
            DiagnosticSeverity.Warning,
            true,
            null,
            null);

        public static DiagnosticDescriptor UnexpectedWalkerException { get; } = new DiagnosticDescriptor(
            "GM0008",
            "Unexpected Exception in Operation Walker",
            $"An unexpected exception occured while walking the operation Tree {{0}}",
            "",
            DiagnosticSeverity.Error,
            true,
            null,
            null);
    }
}
