﻿#region License Information (MIT)
// This code is distributed under the MIT license. 
// Copyright (c) 2021-2023 FrostyBee
// See license.txt or https://mit-license.org/
#endregion

using System.ComponentModel;
using FriskyMouse.Drawing.Attributes;

namespace FriskyMouse.Drawing.Ripples
{
    public enum RippleProfileType : uint
    {
        [Description("Fading Spotlight"), ConstructableEnum(typeof(SpotlightProfile))]
        Spotlight,
        [Description("Ice Cream"), ConstructableEnum(typeof(IceCreamProfile))]
        IceCream,
        [Description("Circle"), ConstructableEnum(typeof(CircleProfile))]
        Ripple,
        [Description("Square"), ConstructableEnum(typeof(SquareProfile))]
        Square,
        [Description("Hexagon"), ConstructableEnum(typeof(HexagonProfile))]
        Hexagon,
        [Description("Diamond"), ConstructableEnum(typeof(DiamondProfile))]
        Diamond,
        [Description("Sonar Pulse"), ConstructableEnum(typeof(SonarPulseProfile))]
        SonarPulse,
        [Description("Filled Sonar Pulse"), ConstructableEnum(typeof(FilledSonarPulseProfile))]
        FilledSonarPulse,
        [Description("Squared Pulse"), ConstructableEnum(typeof(SquaredPulseProfile))]
        SquaredPulse,
        [Description("Cherry Blossom"), ConstructableEnum(typeof(CherryBlossomProfile))]
        Cherry,
        [Description("Lollipop"), ConstructableEnum(typeof(ConcentricProfile))]
        Concentric,
        [Description("Star ripple"), ConstructableEnum(typeof(StarProfile))]
        Star,
        [Description("Crosshair"), ConstructableEnum(typeof(CrosshairProfile))]
        Crosshair
    }

    public enum ShapeType : uint
    {
        Ellipse,
        Rectangle,
        Polygon,
        Crosshair
    }

    public enum PolygonType : uint
    {
        Diamond,
        Hexagon,
        Star,
    }
}
