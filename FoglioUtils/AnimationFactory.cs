﻿using System;
using System.Windows;
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
        public static ThicknessAnimation CreateThicknessAnimation(int ms, Thickness to, bool easing = false, EventHandler completed = null, int framerate = 60)
        {
            var ret = new ThicknessAnimation
            {
                Duration = TimeSpan.FromMilliseconds(ms),
                To = to
            };
            if (easing) ret.EasingFunction = new QuadraticEase();
            if (completed != null) ret.Completed += completed;
            Timeline.SetDesiredFrameRate(ret, framerate);
            return ret;
        }
        public static ThicknessAnimation CreateThicknessAnimation(int ms, Thickness to, Thickness from, bool easing = false, EventHandler completed = null, int framerate = 60)
        {
            var ret = CreateThicknessAnimation(ms, to, easing, completed, framerate);
            ret.From = from;
            return ret;
        }

        public static ColorAnimation CreateColorAnimation(int ms)
        {
            return new ColorAnimation {Duration = TimeSpan.FromMilliseconds(ms)};
        }
    }
}
