using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Nostrum;

namespace Nostrum.Controls
{
    //TODO: check if this still works
    public partial class MaterialSwitch
    {
        private readonly DoubleAnimation _onAnim;
        private readonly DoubleAnimation _offAnim;

        private readonly ColorAnimation _fillOnAnim;
        private readonly ColorAnimation _fillOffAnim;

        public Color OffColor
        {
            get => (Color)GetValue(OffColorProperty);
            set => SetValue(OffColorProperty, value);
        }
        public static readonly DependencyProperty OffColorProperty =
            DependencyProperty.Register("OffColor", typeof(Color), typeof(MaterialSwitch),
                new PropertyMetadata(Colors.DarkSlateGray));

        public Color OnColor
        {
            get => (Color)GetValue(OnColorProperty);
            set => SetValue(OnColorProperty, value);
        }
        public static readonly DependencyProperty OnColorProperty =
            DependencyProperty.Register("OnColor", typeof(Color), typeof(MaterialSwitch),
                new PropertyMetadata(Colors.SlateGray));

        public bool Status
        {
            get => (bool)GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(bool), typeof(MaterialSwitch), new PropertyMetadata(false));

        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly DependencyPropertyWatcher<bool> _dpw;

        public MaterialSwitch()
        {
            InitializeComponent();

            _onAnim = AnimationFactory.CreateDoubleAnimation(150, 20, easing: true);
            _offAnim = AnimationFactory.CreateDoubleAnimation(150, 0, easing: true);

            _fillOnAnim = AnimationFactory.CreateColorAnimation(150, OnColor, easing: true);
            _fillOffAnim = AnimationFactory.CreateColorAnimation(150, OffColor, easing: true);

            _dpw = new DependencyPropertyWatcher<bool>(this, nameof(Status));
            _dpw.PropertyChanged += StatusWatcher_PropertyChanged;
        }

        private void StatusWatcher_PropertyChanged(object sender, EventArgs e)
        {
            if (Status)
                AnimateOn();
            else
                AnimateOff();
        }

        private void AnimateOn()
        {
            SwitchHead.RenderTransform.BeginAnimation(TranslateTransform.XProperty, _onAnim);
            SwitchHead.Fill.BeginAnimation(SolidColorBrush.ColorProperty, _fillOnAnim);
            SwitchBack.Fill.BeginAnimation(SolidColorBrush.ColorProperty, _fillOnAnim);
        }

        private void AnimateOff()
        {
            SwitchHead.RenderTransform.BeginAnimation(TranslateTransform.XProperty, _offAnim);
            SwitchHead.Fill.BeginAnimation(SolidColorBrush.ColorProperty, _fillOffAnim);
            SwitchBack.Fill.BeginAnimation(SolidColorBrush.ColorProperty, _fillOffAnim);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Status)
                AnimateOn();
            else
                AnimateOff();
        }
    }
}