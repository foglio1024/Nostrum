using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace FoglioUtils
{
    public static class AnimationFactory
    {
        public static DoubleAnimation CreateDoubleAnimation(int ms, double to, double from = double.NaN, bool easing = false, EventHandler completed = null, int framerate = 60)
        {
            var ret = new DoubleAnimation
            {
                Duration = TimeSpan.FromMilliseconds(ms),
                To = to
            };
            if (!double.IsNaN(from)) ret.From = from;
            if (easing) ret.EasingFunction = new QuadraticEase();
            if (completed != null) ret.Completed += completed;
            Timeline.SetDesiredFrameRate(ret, framerate);
            return ret;
        }
    }
}
