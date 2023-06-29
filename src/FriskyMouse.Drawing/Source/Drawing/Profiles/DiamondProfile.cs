﻿#region License Information (MIT)
// This code is distributed under the MIT license. 
// Copyright (c) 2021-2023 FrostyBee
// See license.txt or https://mit-license.org/
#endregion

namespace FriskyMouse.Drawing.Ripples
{
    internal class DiamondProfile : BaseRippleProfile
    {
        private Pen _outlinePen;
        int _baseRadius = 10; // Needs to be parametrized.

        public DiamondProfile()
        {
            CreateProfileEntries();
        }

        private void CreateProfileEntries()
        {
            _outlinePen = new Pen(Color.DarkBlue, 4);
            // 1) Make the outer most ripple.
            AddRipple(
                new RippleEntry()
                {
                    IsExpandable = true,                    
                    ShapeType = ShapeType.Polygon,
                    InitialRadius = _baseRadius,
                    RadiusMultiplier = 2,
                    OutlinePen = _outlinePen,
                    IsFilled = false,
                    PolygonType = PolygonType.Diamond,
                    IsStyleable = true
                });            
        }
    }
}
