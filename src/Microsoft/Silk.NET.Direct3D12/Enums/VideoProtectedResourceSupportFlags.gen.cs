// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Direct3D12
{
    [NativeName("Name", "D3D12_VIDEO_PROTECTED_RESOURCE_SUPPORT_FLAGS")]
    public enum VideoProtectedResourceSupportFlags
    {
        [NativeName("Name", "D3D12_VIDEO_PROTECTED_RESOURCE_SUPPORT_FLAG_NONE")]
        VideoProtectedResourceSupportFlagNone = 0x0,
        [NativeName("Name", "D3D12_VIDEO_PROTECTED_RESOURCE_SUPPORT_FLAG_SUPPORTED")]
        VideoProtectedResourceSupportFlagSupported = 0x1,
    }
}
