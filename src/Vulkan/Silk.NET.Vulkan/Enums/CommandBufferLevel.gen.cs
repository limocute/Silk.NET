// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Vulkan
{
    [NativeName("Name", "VkCommandBufferLevel")]
    public enum CommandBufferLevel
    {
        [NativeName("Name", "VK_COMMAND_BUFFER_LEVEL_PRIMARY")]
        Primary = 0,
        [NativeName("Name", "VK_COMMAND_BUFFER_LEVEL_SECONDARY")]
        Secondary = 1,
    }
}
