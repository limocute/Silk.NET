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

namespace Silk.NET.OpenGL.Legacy.Extensions.ARB
{
    [Extension("ARB_texture_barrier")]
    public unsafe partial class ArbTextureBarrier : NativeExtension<GL>
    {
        public const string ExtensionName = "ARB_texture_barrier";
        [NativeApi(EntryPoint = "glTextureBarrier")]
        public partial void TextureBarrier();

        public ArbTextureBarrier(INativeContext ctx)
            : base(ctx)
        {
        }
    }
}

