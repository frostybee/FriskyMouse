﻿#region License Information (MIT)
// This code is distributed under the MIT license. 
// Copyright (c) 2021-2023 FrostyBee
// See license.txt or https://mit-license.org/
#endregion

using System.ComponentModel;

namespace FriskyMouse.Drawing.Animation
{
    /// <summary>
    /// Defines the direction of the animation.
    /// </summary>
    public enum AnimationDirection : uint
    {
        [Description("In")]
        In, // The animation will progress outward.
        [Description("Out")]
        Out, // The animation will progress inward.
        [Description("In Out In")]
        InOutIn //Same as In, but changes to InOutOut if finished.     
    }
}
