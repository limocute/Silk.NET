// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.
using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using Silk.NET.Core;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;
using Silk.NET.OpenGLES;
using Extension = Silk.NET.Core.Attributes.ExtensionAttribute;

#pragma warning disable 1591

namespace Silk.NET.OpenGLES.Extensions.NV
{
    [Extension("NV_polygon_mode")]
    public unsafe partial class NVPolygonMode : NativeExtension<GL>
    {
        public const string ExtensionName = "NV_polygon_mode";
        [NativeApi(EntryPoint = "glPolygonModeNV")]
        public partial void PolygonMode([Flow(FlowDirection.In)] NV face, [Flow(FlowDirection.In)] NV mode);

        [NativeApi(EntryPoint = "glPolygonModeNV")]
        public partial void PolygonMode([Flow(FlowDirection.In)] NV face, [Flow(FlowDirection.In)] PolygonMode mode);

        [NativeApi(EntryPoint = "glPolygonModeNV")]
        public partial void PolygonMode([Flow(FlowDirection.In)] MaterialFace face, [Flow(FlowDirection.In)] NV mode);

        [NativeApi(EntryPoint = "glPolygonModeNV")]
        public partial void PolygonMode([Flow(FlowDirection.In)] MaterialFace face, [Flow(FlowDirection.In)] PolygonMode mode);

        public NVPolygonMode(INativeContext ctx)
            : base(ctx)
        {
        }
    }
}

