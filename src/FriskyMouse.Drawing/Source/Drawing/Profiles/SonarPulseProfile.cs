﻿using FriskyMouse.Drawing.Extensions;
using FriskyMouse.Drawing.Helpers;

namespace FriskyMouse.Drawing.Ripples
{
    /// <summary>
    /// Represents a single expanding ripple.
    /// </summary>
    public class SonarPulseProfile : BaseRippleProfile
    {
        private SolidBrush _innerBrush;
        private Pen _outerPen;
        private Pen _middlePen;
        public SonarPulseProfile()
        {
            CreateProfileEntries();
        }

        private void CreateProfileEntries()
        {
            _innerBrush = new SolidBrush(Color.Crimson);
            _outerPen = new Pen(Color.DeepPink, 4);
            _middlePen = new Pen(Color.Yellow, 3);

            // 1) Make the outer ripple.
            AddRipple(
                new RippleEntry()
                {
                    IsExpandable = true,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, 15),
                    ShapeType = ShapeType.Ellipse,
                    InitialRadius = BaseRadius,
                    RadiusMultiplier = 3,                    
                    OutlinePen = _outerPen,
                    IsFilled = false,
                    IsStyleable = true
                });
            // 2) Make the middle ripple. 
            AddRipple(   
                new RippleEntry()
                {
                    IsExpandable = false,
                    IsFade = false,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, 10),
                    ShapeType = ShapeType.Ellipse,
                    InitialRadius = 10,
                    RadiusMultiplier = 2,
                    OutlinePen = _middlePen,
                    IsFilled = false,
                });
            // 3) Make the most inner ripple. It must drawn last.
            AddRipple(
                new RippleEntry()
                {
                    IsExpandable = false,
                    IsFade = false,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, 9),
                    ShapeType = ShapeType.Ellipse,
                    InitialRadius = 9,
                    RadiusMultiplier = 2,
                    FillBrush = _innerBrush,
                    IsFilled = true,
                });
        }
    }
}
