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

namespace Silk.NET.OpenGL.Legacy.Extensions.NV
{
    [Extension("NV_vdpau_interop2")]
    public unsafe partial class NVVdpauInterop2 : NativeExtension<GL>
    {
        public const string ExtensionName = "NV_vdpau_interop2";
        [NativeApi(EntryPoint = "glVDPAURegisterVideoSurfaceWithPictureStructureNV")]
        public unsafe partial IntPtr VdpauregisterVideoSurfaceWithPictureStructure([Flow(FlowDirection.In)] void* vdpSurface, [Flow(FlowDirection.In)] NV target, [Flow(FlowDirection.In)] uint numTextureNames, [Count(Parameter = "numTextureNames"), Flow(FlowDirection.In)] uint* textureNames, [Flow(FlowDirection.In)] bool isFrameStructure);

        [NativeApi(EntryPoint = "glVDPAURegisterVideoSurfaceWithPictureStructureNV")]
        public unsafe partial IntPtr VdpauregisterVideoSurfaceWithPictureStructure([Flow(FlowDirection.In)] void* vdpSurface, [Flow(FlowDirection.In)] NV target, [Flow(FlowDirection.In)] uint numTextureNames, [Count(Parameter = "numTextureNames"), Flow(FlowDirection.In)] in uint textureNames, [Flow(FlowDirection.In)] bool isFrameStructure);

        [NativeApi(EntryPoint = "glVDPAURegisterVideoSurfaceWithPictureStructureNV")]
        public unsafe partial IntPtr VdpauregisterVideoSurfaceWithPictureStructure<T0>([Flow(FlowDirection.In)] in T0 vdpSurface, [Flow(FlowDirection.In)] NV target, [Flow(FlowDirection.In)] uint numTextureNames, [Count(Parameter = "numTextureNames"), Flow(FlowDirection.In)] uint* textureNames, [Flow(FlowDirection.In)] bool isFrameStructure) where T0 : unmanaged;

        [NativeApi(EntryPoint = "glVDPAURegisterVideoSurfaceWithPictureStructureNV")]
        public partial IntPtr VdpauregisterVideoSurfaceWithPictureStructure<T0>([Flow(FlowDirection.In)] in T0 vdpSurface, [Flow(FlowDirection.In)] NV target, [Flow(FlowDirection.In)] uint numTextureNames, [Count(Parameter = "numTextureNames"), Flow(FlowDirection.In)] in uint textureNames, [Flow(FlowDirection.In)] bool isFrameStructure) where T0 : unmanaged;

        public NVVdpauInterop2(INativeContext ctx)
            : base(ctx)
        {
        }
    }
}

