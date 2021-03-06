// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Direct3D12
{
    [NativeName("Name", "D3D12_SHADER_COMPONENT_MAPPING")]
    public enum ShaderComponentMapping
    {
        [NativeName("Name", "D3D12_SHADER_COMPONENT_MAPPING_FROM_MEMORY_COMPONENT_0")]
        ShaderComponentMappingFromMemoryComponent0 = 0x0,
        [NativeName("Name", "D3D12_SHADER_COMPONENT_MAPPING_FROM_MEMORY_COMPONENT_1")]
        ShaderComponentMappingFromMemoryComponent1 = 0x1,
        [NativeName("Name", "D3D12_SHADER_COMPONENT_MAPPING_FROM_MEMORY_COMPONENT_2")]
        ShaderComponentMappingFromMemoryComponent2 = 0x2,
        [NativeName("Name", "D3D12_SHADER_COMPONENT_MAPPING_FROM_MEMORY_COMPONENT_3")]
        ShaderComponentMappingFromMemoryComponent3 = 0x3,
        [NativeName("Name", "D3D12_SHADER_COMPONENT_MAPPING_FORCE_VALUE_0")]
        ShaderComponentMappingForceValue0 = 0x4,
        [NativeName("Name", "D3D12_SHADER_COMPONENT_MAPPING_FORCE_VALUE_1")]
        ShaderComponentMappingForceValue1 = 0x5,
    }
}
