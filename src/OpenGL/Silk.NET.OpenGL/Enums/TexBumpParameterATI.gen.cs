// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.OpenGL
{
    [NativeName("Name", "TexBumpParameterATI")]
    public enum TexBumpParameterATI
    {
        [NativeName("Name", "GL_BUMP_ROT_MATRIX_ATI")]
        BumpRotMatrixAti = 0x8775,
    }
}
