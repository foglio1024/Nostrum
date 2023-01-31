using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Nostrum.WPF.Controls;

public abstract class CornerRadiusAnimationBase : AnimationTimeline
{
    public override sealed Type TargetPropertyType
    {
        get
        {
            ReadPreamble();
            return typeof(CornerRadius);
        }
    }

    public override sealed object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
    {
        ReadPreamble();

        if (animationClock == null)
        {
            throw new ArgumentNullException(nameof(animationClock));
        }

        if (animationClock.CurrentState == ClockState.Stopped)
        {
            return defaultDestinationValue;
        }

        return GetCurrentValueCore((CornerRadius)defaultOriginValue, (CornerRadius)defaultDestinationValue, animationClock);
    }

    protected abstract CornerRadius GetCurrentValueCore(CornerRadius defaultOriginValue, CornerRadius defaultDestinationValue, AnimationClock animationClock);
}
