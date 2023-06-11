﻿using System.Drawing;
using FriskyMouse.HelpersLib.Extensions;
using FriskyMouse.HelpersLib.Helpers;

namespace FriskyMouse.HelpersLib.Drawing
{
    /// <summary>
    /// Represents a single expanding ripple.
    /// </summary>
    public class SonarPulseProfile : BaseProfile
    {
        private SolidBrush _innerBrush;
        private Pen _outerPen;
        private Pen _middlePen;
        public SonarPulseProfile()
        {
            InitProfileEntries();
        }

        private void InitProfileEntries()
        {
            _innerBrush = new SolidBrush(Color.Crimson);
            _outerPen = new Pen(Color.DarkRed.WithOpacity(250), 3);
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
                });
            // 2) Make the middle ripple. 
            AddRipple(   
                new RippleEntry()
                {
                    IsExpandable = false,
                    IsFade = false,
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, 9),
                    ShapeType = ShapeType.Ellipse,
                    InitialRadius = 9,
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
                    Bounds = DrawingHelper.CreateRectangle(Width, Height, 8),
                    ShapeType = ShapeType.Ellipse,
                    InitialRadius = 8,
                    RadiusMultiplier = 2,
                    FillBrush = _innerBrush,
                    IsFilled = true,
                });
        }
    }
}