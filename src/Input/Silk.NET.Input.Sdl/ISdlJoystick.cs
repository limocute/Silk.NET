﻿// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

namespace Silk.NET.Input.Sdl
{
    internal interface ISdlJoystick
    {
        int ActualIndex { get; set; }
        int InstanceId { get; }
    }
}
