// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Direct3D11
{
    [NativeName("Name", "D3D11_COLOR_WRITE_ENABLE")]
    public enum ColorWriteEnable
    {
        [NativeName("Name", "D3D11_COLOR_WRITE_ENABLE_RED")]
        ColorWriteEnableRed = 0x1,
        [NativeName("Name", "D3D11_COLOR_WRITE_ENABLE_GREEN")]
        ColorWriteEnableGreen = 0x2,
        [NativeName("Name", "D3D11_COLOR_WRITE_ENABLE_BLUE")]
        ColorWriteEnableBlue = 0x4,
        [NativeName("Name", "D3D11_COLOR_WRITE_ENABLE_ALPHA")]
        ColorWriteEnableAlpha = 0x8,
        [NativeName("Name", "D3D11_COLOR_WRITE_ENABLE_ALL")]
        ColorWriteEnableAll = 0xF,
    }
}
