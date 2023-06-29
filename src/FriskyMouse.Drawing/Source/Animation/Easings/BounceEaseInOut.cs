#region License Information (MIT)
// This code is distributed under the MIT license. 
// Copyright (c) 2021-2023 FrostyBee
// See license.txt or https://mit-license.org/
#endregion

namespace FriskyMouse.Drawing.Animation
{
    /// <summary>
    /// Eases a <see cref="double"/> value 
    /// using a piecewise simulated bounce function.
    /// </summary>
    public class BounceEaseInOut : Easing
    {
        /// <inheritdoc/>
        public override double Ease(double progress)
        {
            double p = progress;
            if (p < 0.5d)
            {
                return 0.5f * (1 - BounceEaseUtils.Bounce(1 - (p * 2)));
            }
            else
            {
                return 0.5f * BounceEaseUtils.Bounce(p * 2 - 1) + 0.5f;
            }
        }
    }
}
