// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Direct3D12
{
    [NativeName("Name", "D3D12_GPU_BASED_VALIDATION_SHADER_PATCH_MODE")]
    public enum GpuBasedValidationShaderPatchMode
    {
        [NativeName("Name", "D3D12_GPU_BASED_VALIDATION_SHADER_PATCH_MODE_NONE")]
        GpuBasedValidationShaderPatchModeNone = 0x0,
        [NativeName("Name", "D3D12_GPU_BASED_VALIDATION_SHADER_PATCH_MODE_STATE_TRACKING_ONLY")]
        GpuBasedValidationShaderPatchModeStateTrackingOnly = 0x1,
        [NativeName("Name", "D3D12_GPU_BASED_VALIDATION_SHADER_PATCH_MODE_UNGUARDED_VALIDATION")]
        GpuBasedValidationShaderPatchModeUnguardedValidation = 0x2,
        [NativeName("Name", "D3D12_GPU_BASED_VALIDATION_SHADER_PATCH_MODE_GUARDED_VALIDATION")]
        GpuBasedValidationShaderPatchModeGuardedValidation = 0x3,
        [NativeName("Name", "NUM_D3D12_GPU_BASED_VALIDATION_SHADER_PATCH_MODES")]
        NumD3D12GpuBasedValidationShaderPatchModes = 0x4,
    }
}
