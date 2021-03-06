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
    [NativeName("Name", "VkDescriptorUpdateTemplateEntry")]
    public unsafe partial struct DescriptorUpdateTemplateEntry
    {
        public DescriptorUpdateTemplateEntry
        (
            uint? dstBinding = null,
            uint? dstArrayElement = null,
            uint? descriptorCount = null,
            DescriptorType? descriptorType = null,
            UIntPtr? offset = null,
            UIntPtr? stride = null
        ) : this()
        {
            if (dstBinding is not null)
            {
                DstBinding = dstBinding.Value;
            }

            if (dstArrayElement is not null)
            {
                DstArrayElement = dstArrayElement.Value;
            }

            if (descriptorCount is not null)
            {
                DescriptorCount = descriptorCount.Value;
            }

            if (descriptorType is not null)
            {
                DescriptorType = descriptorType.Value;
            }

            if (offset is not null)
            {
                Offset = offset.Value;
            }

            if (stride is not null)
            {
                Stride = stride.Value;
            }
        }

/// <summary></summary>
        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "dstBinding")]
        public uint DstBinding;
/// <summary></summary>
        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "dstArrayElement")]
        public uint DstArrayElement;
/// <summary></summary>
        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "descriptorCount")]
        public uint DescriptorCount;
/// <summary></summary>
        [NativeName("Type", "VkDescriptorType")]
        [NativeName("Type.Name", "VkDescriptorType")]
        [NativeName("Name", "descriptorType")]
        public DescriptorType DescriptorType;
/// <summary></summary>
        [NativeName("Type", "size_t")]
        [NativeName("Type.Name", "size_t")]
        [NativeName("Name", "offset")]
        public UIntPtr Offset;
/// <summary></summary>
        [NativeName("Type", "size_t")]
        [NativeName("Type.Name", "size_t")]
        [NativeName("Name", "stride")]
        public UIntPtr Stride;
    }
}
