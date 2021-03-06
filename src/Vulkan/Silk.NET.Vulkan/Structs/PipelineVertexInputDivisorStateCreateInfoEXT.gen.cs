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

#pragma warning disable 1591

namespace Silk.NET.Vulkan
{
    [NativeName("Name", "VkPipelineVertexInputDivisorStateCreateInfoEXT")]
    public unsafe partial struct PipelineVertexInputDivisorStateCreateInfoEXT
    {
        public PipelineVertexInputDivisorStateCreateInfoEXT
        (
            StructureType? sType = StructureType.PipelineVertexInputDivisorStateCreateInfoExt,
            void* pNext = null,
            uint? vertexBindingDivisorCount = null,
            VertexInputBindingDivisorDescriptionEXT* pVertexBindingDivisors = null
        ) : this()
        {
            if (sType is not null)
            {
                SType = sType.Value;
            }

            if (pNext is not null)
            {
                PNext = pNext;
            }

            if (vertexBindingDivisorCount is not null)
            {
                VertexBindingDivisorCount = vertexBindingDivisorCount.Value;
            }

            if (pVertexBindingDivisors is not null)
            {
                PVertexBindingDivisors = pVertexBindingDivisors;
            }
        }

/// <summary></summary>
        [NativeName("Type", "VkStructureType")]
        [NativeName("Type.Name", "VkStructureType")]
        [NativeName("Name", "sType")]
        public StructureType SType;
/// <summary></summary>
        [NativeName("Type", "void*")]
        [NativeName("Type.Name", "void")]
        [NativeName("Name", "pNext")]
        public void* PNext;
/// <summary></summary>
        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "vertexBindingDivisorCount")]
        public uint VertexBindingDivisorCount;
/// <summary></summary>
        [NativeName("Type", "VkVertexInputBindingDivisorDescriptionEXT*")]
        [NativeName("Type.Name", "VkVertexInputBindingDivisorDescriptionEXT")]
        [NativeName("Name", "pVertexBindingDivisors")]
        public VertexInputBindingDivisorDescriptionEXT* PVertexBindingDivisors;
    }
}
