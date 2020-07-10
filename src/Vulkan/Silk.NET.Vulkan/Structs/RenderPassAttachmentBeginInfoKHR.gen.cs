// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using System.Runtime.InteropServices;
using System.Text;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Ultz.SuperInvoke;

#pragma warning disable 1591

namespace Silk.NET.Vulkan
{
    [NativeName("Name", "VkRenderPassAttachmentBeginInfoKHR")]
    public unsafe partial struct RenderPassAttachmentBeginInfoKHR
    {
        public RenderPassAttachmentBeginInfoKHR
        (
            StructureType sType = StructureType.RenderPassAttachmentBeginInfo,
            void* pNext = default,
            uint attachmentCount = default,
            ImageView* pAttachments = default
        )
        {
            SType = sType;
            PNext = pNext;
            AttachmentCount = attachmentCount;
            PAttachments = pAttachments;
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
        [NativeName("Name", "attachmentCount")]
        public uint AttachmentCount;
/// <summary></summary>
        [NativeName("Type", "VkImageView*")]
        [NativeName("Type.Name", "VkImageView")]
        [NativeName("Name", "pAttachments")]
        public ImageView* PAttachments;
    }
}
