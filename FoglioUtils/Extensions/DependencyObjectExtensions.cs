using System.Windows;
using System.Windows.Media;

namespace FoglioUtils.Extensions
{
    public static class DependencyObjectExtensions
    {
        public static T FindVisualParent<T>(this DependencyObject sender) where T : DependencyObject
        {
            if (sender == null)
            {
                return null;
            }
            else if (VisualTreeHelper.GetParent(sender) is T)
            {
                return VisualTreeHelper.GetParent(sender) as T;
            }
            else
            {
                var parent = VisualTreeHelper.GetParent(sender);
                return FindVisualParent<T>(parent);
            }
        }

        public static T GetChild<T>(this DependencyObject obj) where T : DependencyObject
        {
            DependencyObject child = null;
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                child = VisualTreeHelper.GetChild(obj, i);
                if (child.GetType() == typeof(T))
                {
                    break;
                }
                else
                {
                    child = GetChild<T>(child);
                    if (child != null && child.GetType() == typeof(T))
                    {
                        break;
                    }
                }
            }

            return child as T;
        }

    }
}
