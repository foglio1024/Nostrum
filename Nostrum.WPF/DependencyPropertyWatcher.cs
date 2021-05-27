using System;
using System.Windows;
using System.Windows.Data;

namespace Nostrum.WPF
{
    /// <summary>
    /// Class used to get notification when a <see cref="DependencyProperty"/> value of the given <see cref="DependencyObject"/> changes.
    /// </summary>
    /// <typeparam name="T">the property value type</typeparam>
    public class DependencyPropertyWatcher<T> : DependencyObject, IDisposable
    {
        /// <summary>
        /// Property internally used for binding.
        /// </summary>
        public T Value => (T)GetValue(ValueProperty);
        /// <summary>
        /// Property internally used for binding.
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                "Value",
                typeof(object),
                typeof(DependencyPropertyWatcher<T>),
                new PropertyMetadata(null, OnPropertyChanged));

        /// <summary>
        /// The target <see cref="DependencyObject"/>.
        /// </summary>
        public DependencyObject Target { get; private set; }

        /// <summary>
        /// Property changed event handler.
        /// </summary>
        public event EventHandler? PropertyChanged;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="target">the target <see cref="DependencyObject"/></param>
        /// <param name="propertyPath">the property path to use for internal binding</param>
        public DependencyPropertyWatcher(DependencyObject target, string propertyPath)
        {
            Target = target;
            BindingOperations.SetBinding(
                this,
                ValueProperty,
                new Binding() { Source = target, Path = new PropertyPath(propertyPath), Mode = BindingMode.OneWay });
        }


        private static void OnPropertyChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            var source = (DependencyPropertyWatcher<T>)sender;
            source.PropertyChanged?.Invoke(source, EventArgs.Empty);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            ClearValue(ValueProperty);
        }
    }
}
