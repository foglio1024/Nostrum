using System;
using System.Windows;
using System.Windows.Media;

namespace Nostrum.Extensions
{
    public static class DependencyObjectExtensions
    {
        /// <summary>
        /// Tries to find a visual parent of type <typeparamref name="TParent "/> starting from this <see cref="DependencyObject"/>. Returns null if not found.
        /// </summary>
        public static TParent? FindVisualParent<TParent>(this DependencyObject? sender) where TParent : DependencyObject
        {
            if (sender == null)
            {
                return null;
            }
            if (VisualTreeHelper.GetParent(sender) is TParent)
            {
                return VisualTreeHelper.GetParent(sender) as TParent;
            }

            var parent = VisualTreeHelper.GetParent(sender);
            return FindVisualParent<TParent>(parent);
        }

        /// <summary>
        /// Tries to find a visual child of type <typeparamref name="TChild "/> starting from this <see cref="DependencyObject"/>. Returns null if not found.
        /// </summary>
        public static TChild? FindVisualChild<TChild>(this DependencyObject obj) where TChild : DependencyObject
        {
#pragma warning disable 618
            return GetChild<TChild>(obj);
#pragma warning restore 618
        }

        [Obsolete("Use FindVisualChild<TChild>() instead")]
        public static TChild? GetChild<TChild>(this DependencyObject obj) where TChild : DependencyObject
        {
            DependencyObject? child = null;
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                child = VisualTreeHelper.GetChild(obj, i);
                if (child.GetType() == typeof(TChild))
                {
                    break;
                }
                else
                {
                    child = GetChild<TChild>(child);
                    if (child != null && child.GetType() == typeof(TChild))
                    {
                        break;
                    }
                }
            }

            return child as TChild;
        }
    }
}
