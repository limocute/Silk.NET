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

namespace Silk.NET.OpenGL.Legacy.Extensions.OES
{
    [Extension("OES_byte_coordinates")]
    public unsafe partial class OesByteCoordinates : NativeExtension<GL>
    {
        public const string ExtensionName = "OES_byte_coordinates";
        [NativeApi(EntryPoint = "glMultiTexCoord1bOES")]
        public partial void MultiTexCoord1([Flow(FlowDirection.In)] OES texture, [Flow(FlowDirection.In)] sbyte s);

        [NativeApi(EntryPoint = "glMultiTexCoord1bOES")]
        public partial void MultiTexCoord1([Flow(FlowDirection.In)] TextureUnit texture, [Flow(FlowDirection.In)] sbyte s);

        [NativeApi(EntryPoint = "glMultiTexCoord1bvOES")]
        public unsafe partial void MultiTexCoord1([Flow(FlowDirection.In)] OES texture, [Count(Count = 1), Flow(FlowDirection.In)] sbyte* coords);

        [NativeApi(EntryPoint = "glMultiTexCoord1bvOES")]
        public partial void MultiTexCoord1([Flow(FlowDirection.In)] OES texture, [Count(Count = 1), Flow(FlowDirection.In)] in sbyte coords);

        [NativeApi(EntryPoint = "glMultiTexCoord1bvOES")]
        public unsafe partial void MultiTexCoord1([Flow(FlowDirection.In)] TextureUnit texture, [Count(Count = 1), Flow(FlowDirection.In)] sbyte* coords);

        [NativeApi(EntryPoint = "glMultiTexCoord1bvOES")]
        public partial void MultiTexCoord1([Flow(FlowDirection.In)] TextureUnit texture, [Count(Count = 1), Flow(FlowDirection.In)] in sbyte coords);

        [NativeApi(EntryPoint = "glMultiTexCoord2bOES")]
        public partial void MultiTexCoord2([Flow(FlowDirection.In)] OES texture, [Flow(FlowDirection.In)] sbyte s, [Flow(FlowDirection.In)] sbyte t);

        [NativeApi(EntryPoint = "glMultiTexCoord2bOES")]
        public partial void MultiTexCoord2([Flow(FlowDirection.In)] TextureUnit texture, [Flow(FlowDirection.In)] sbyte s, [Flow(FlowDirection.In)] sbyte t);

        [NativeApi(EntryPoint = "glMultiTexCoord2bvOES")]
        public unsafe partial void MultiTexCoord2([Flow(FlowDirection.In)] OES texture, [Count(Count = 2), Flow(FlowDirection.In)] sbyte* coords);

        [NativeApi(EntryPoint = "glMultiTexCoord2bvOES")]
        public partial void MultiTexCoord2([Flow(FlowDirection.In)] OES texture, [Count(Count = 2), Flow(FlowDirection.In)] in sbyte coords);

        [NativeApi(EntryPoint = "glMultiTexCoord2bvOES")]
        public unsafe partial void MultiTexCoord2([Flow(FlowDirection.In)] TextureUnit texture, [Count(Count = 2), Flow(FlowDirection.In)] sbyte* coords);

        [NativeApi(EntryPoint = "glMultiTexCoord2bvOES")]
        public partial void MultiTexCoord2([Flow(FlowDirection.In)] TextureUnit texture, [Count(Count = 2), Flow(FlowDirection.In)] in sbyte coords);

        [NativeApi(EntryPoint = "glMultiTexCoord3bOES")]
        public partial void MultiTexCoord3([Flow(FlowDirection.In)] OES texture, [Flow(FlowDirection.In)] sbyte s, [Flow(FlowDirection.In)] sbyte t, [Flow(FlowDirection.In)] sbyte r);

        [NativeApi(EntryPoint = "glMultiTexCoord3bOES")]
        public partial void MultiTexCoord3([Flow(FlowDirection.In)] TextureUnit texture, [Flow(FlowDirection.In)] sbyte s, [Flow(FlowDirection.In)] sbyte t, [Flow(FlowDirection.In)] sbyte r);

        [NativeApi(EntryPoint = "glMultiTexCoord3bvOES")]
        public unsafe partial void MultiTexCoord3([Flow(FlowDirection.In)] OES texture, [Count(Count = 3), Flow(FlowDirection.In)] sbyte* coords);

        [NativeApi(EntryPoint = "glMultiTexCoord3bvOES")]
        public partial void MultiTexCoord3([Flow(FlowDirection.In)] OES texture, [Count(Count = 3), Flow(FlowDirection.In)] in sbyte coords);

        [NativeApi(EntryPoint = "glMultiTexCoord3bvOES")]
        public unsafe partial void MultiTexCoord3([Flow(FlowDirection.In)] TextureUnit texture, [Count(Count = 3), Flow(FlowDirection.In)] sbyte* coords);

        [NativeApi(EntryPoint = "glMultiTexCoord3bvOES")]
        public partial void MultiTexCoord3([Flow(FlowDirection.In)] TextureUnit texture, [Count(Count = 3), Flow(FlowDirection.In)] in sbyte coords);

        [NativeApi(EntryPoint = "glMultiTexCoord4bOES")]
        public partial void MultiTexCoord4([Flow(FlowDirection.In)] OES texture, [Flow(FlowDirection.In)] sbyte s, [Flow(FlowDirection.In)] sbyte t, [Flow(FlowDirection.In)] sbyte r, [Flow(FlowDirection.In)] sbyte q);

        [NativeApi(EntryPoint = "glMultiTexCoord4bOES")]
        public partial void MultiTexCoord4([Flow(FlowDirection.In)] TextureUnit texture, [Flow(FlowDirection.In)] sbyte s, [Flow(FlowDirection.In)] sbyte t, [Flow(FlowDirection.In)] sbyte r, [Flow(FlowDirection.In)] sbyte q);

        [NativeApi(EntryPoint = "glMultiTexCoord4bvOES")]
        public unsafe partial void MultiTexCoord4([Flow(FlowDirection.In)] OES texture, [Count(Count = 4), Flow(FlowDirection.In)] sbyte* coords);

        [NativeApi(EntryPoint = "glMultiTexCoord4bvOES")]
        public partial void MultiTexCoord4([Flow(FlowDirection.In)] OES texture, [Count(Count = 4), Flow(FlowDirection.In)] in sbyte coords);

        [NativeApi(EntryPoint = "glMultiTexCoord4bvOES")]
        public unsafe partial void MultiTexCoord4([Flow(FlowDirection.In)] TextureUnit texture, [Count(Count = 4), Flow(FlowDirection.In)] sbyte* coords);

        [NativeApi(EntryPoint = "glMultiTexCoord4bvOES")]
        public partial void MultiTexCoord4([Flow(FlowDirection.In)] TextureUnit texture, [Count(Count = 4), Flow(FlowDirection.In)] in sbyte coords);

        [NativeApi(EntryPoint = "glTexCoord1bOES")]
        public partial void TexCoord1([Flow(FlowDirection.In)] sbyte s);

        [NativeApi(EntryPoint = "glTexCoord1bvOES")]
        public unsafe partial void TexCoord1([Count(Count = 1), Flow(FlowDirection.In)] sbyte* coords);

        [NativeApi(EntryPoint = "glTexCoord1bvOES")]
        public partial void TexCoord1([Count(Count = 1), Flow(FlowDirection.In)] in sbyte coords);

        [NativeApi(EntryPoint = "glTexCoord2bOES")]
        public partial void TexCoord2([Flow(FlowDirection.In)] sbyte s, [Flow(FlowDirection.In)] sbyte t);

        [NativeApi(EntryPoint = "glTexCoord2bvOES")]
        public unsafe partial void TexCoord2([Count(Count = 2), Flow(FlowDirection.In)] sbyte* coords);

        [NativeApi(EntryPoint = "glTexCoord2bvOES")]
        public partial void TexCoord2([Count(Count = 2), Flow(FlowDirection.In)] in sbyte coords);

        [NativeApi(EntryPoint = "glTexCoord3bOES")]
        public partial void TexCoord3([Flow(FlowDirection.In)] sbyte s, [Flow(FlowDirection.In)] sbyte t, [Flow(FlowDirection.In)] sbyte r);

        [NativeApi(EntryPoint = "glTexCoord3bvOES")]
        public unsafe partial void TexCoord3([Count(Count = 3), Flow(FlowDirection.In)] sbyte* coords);

        [NativeApi(EntryPoint = "glTexCoord3bvOES")]
        public partial void TexCoord3([Count(Count = 3), Flow(FlowDirection.In)] in sbyte coords);

        [NativeApi(EntryPoint = "glTexCoord4bOES")]
        public partial void TexCoord4([Flow(FlowDirection.In)] sbyte s, [Flow(FlowDirection.In)] sbyte t, [Flow(FlowDirection.In)] sbyte r, [Flow(FlowDirection.In)] sbyte q);

        [NativeApi(EntryPoint = "glTexCoord4bvOES")]
        public unsafe partial void TexCoord4([Count(Count = 4), Flow(FlowDirection.In)] sbyte* coords);

        [NativeApi(EntryPoint = "glTexCoord4bvOES")]
        public partial void TexCoord4([Count(Count = 4), Flow(FlowDirection.In)] in sbyte coords);

        [NativeApi(EntryPoint = "glVertex2bOES")]
        public partial void Vertex2([Flow(FlowDirection.In)] sbyte x, [Flow(FlowDirection.In)] sbyte y);

        [NativeApi(EntryPoint = "glVertex2bvOES")]
        public unsafe partial void Vertex2([Count(Count = 2), Flow(FlowDirection.In)] sbyte* coords);

        [NativeApi(EntryPoint = "glVertex2bvOES")]
        public partial void Vertex2([Count(Count = 2), Flow(FlowDirection.In)] in sbyte coords);

        [NativeApi(EntryPoint = "glVertex3bOES")]
        public partial void Vertex3([Flow(FlowDirection.In)] sbyte x, [Flow(FlowDirection.In)] sbyte y, [Flow(FlowDirection.In)] sbyte z);

        [NativeApi(EntryPoint = "glVertex3bvOES")]
        public unsafe partial void Vertex3([Count(Count = 3), Flow(FlowDirection.In)] sbyte* coords);

        [NativeApi(EntryPoint = "glVertex3bvOES")]
        public partial void Vertex3([Count(Count = 3), Flow(FlowDirection.In)] in sbyte coords);

        [NativeApi(EntryPoint = "glVertex4bOES")]
        public partial void Vertex4([Flow(FlowDirection.In)] sbyte x, [Flow(FlowDirection.In)] sbyte y, [Flow(FlowDirection.In)] sbyte z, [Flow(FlowDirection.In)] sbyte w);

        [NativeApi(EntryPoint = "glVertex4bvOES")]
        public unsafe partial void Vertex4([Count(Count = 4), Flow(FlowDirection.In)] sbyte* coords);

        [NativeApi(EntryPoint = "glVertex4bvOES")]
        public partial void Vertex4([Count(Count = 4), Flow(FlowDirection.In)] in sbyte coords);

        public OesByteCoordinates(INativeContext ctx)
            : base(ctx)
        {
        }
    }
}

