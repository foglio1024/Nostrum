using System.Windows;
using System.Windows.Media.Animation;

namespace Nostrum.WPF.Controls;

public class CornerRadiusAnimation : CornerRadiusAnimationBase
{
    public CornerRadius? From
    {
        get => (CornerRadius?)GetValue(FromProperty);
        set => SetValue(FromProperty, value);
    }

    public static readonly DependencyProperty FromProperty =
        DependencyProperty.Register("From",
                                    typeof(CornerRadius?),
                                    typeof(CornerRadiusAnimation),
                                    new PropertyMetadata(null));

    public CornerRadius To
    {
        get => (CornerRadius)GetValue(ToProperty);
        set => SetValue(ToProperty, value);
    }

    public static readonly DependencyProperty ToProperty =
        DependencyProperty.Register("To",
                                    typeof(CornerRadius),
                                    typeof(CornerRadiusAnimation),
                                    new PropertyMetadata(null));

    public IEasingFunction EasingFunction
    {
        get => (IEasingFunction)GetValue(EasingFunctionProperty);
        set => SetValue(EasingFunctionProperty, value);
    }

    public static readonly DependencyProperty EasingFunctionProperty =
        DependencyProperty.Register("EasingFunction",
                                    typeof(IEasingFunction),
                                    typeof(CornerRadiusAnimation),
                                    new PropertyMetadata(new QuadraticEase { EasingMode = EasingMode.EaseInOut }));

    protected override Freezable CreateInstanceCore()
    {
        return new CornerRadiusAnimation();
    }

    protected override CornerRadius GetCurrentValueCore(CornerRadius defaultOriginValue, CornerRadius defaultDestinationValue, AnimationClock animationClock)
    {
        var progress = animationClock.CurrentProgress ?? 0d;

        var easingFunction = EasingFunction;

        if (easingFunction != null)
        {
            progress = easingFunction.Ease(progress);
        }
        var from = From ?? defaultOriginValue;

        var result = new CornerRadius(
            from.TopLeft + (To.TopLeft - from.TopLeft) * progress,
            from.TopRight + (To.TopRight - from.TopRight) * progress,
            from.BottomRight + (To.BottomRight - from.BottomRight) * progress,
            from.BottomLeft + (To.BottomLeft - from.BottomLeft) * progress);

        return result;
    }
}
