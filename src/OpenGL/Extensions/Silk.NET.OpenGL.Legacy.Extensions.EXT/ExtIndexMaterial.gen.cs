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
using Silk.NET.OpenGL.Legacy;
using Extension = Silk.NET.Core.Attributes.ExtensionAttribute;

#pragma warning disable 1591

namespace Silk.NET.OpenGL.Legacy.Extensions.EXT
{
    [Extension("EXT_index_material")]
    public unsafe partial class ExtIndexMaterial : NativeExtension<GL>
    {
        public const string ExtensionName = "EXT_index_material";
        [NativeApi(EntryPoint = "glIndexMaterialEXT")]
        public partial void IndexMaterial([Flow(FlowDirection.In)] EXT face, [Flow(FlowDirection.In)] EXT mode);

        [NativeApi(EntryPoint = "glIndexMaterialEXT")]
        public partial void IndexMaterial([Flow(FlowDirection.In)] EXT face, [Flow(FlowDirection.In)] IndexMaterialParameterEXT mode);

        [NativeApi(EntryPoint = "glIndexMaterialEXT")]
        public partial void IndexMaterial([Flow(FlowDirection.In)] MaterialFace face, [Flow(FlowDirection.In)] EXT mode);

        [NativeApi(EntryPoint = "glIndexMaterialEXT")]
        public partial void IndexMaterial([Flow(FlowDirection.In)] MaterialFace face, [Flow(FlowDirection.In)] IndexMaterialParameterEXT mode);

        public ExtIndexMaterial(INativeContext ctx)
            : base(ctx)
        {
        }
    }
}

