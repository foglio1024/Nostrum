using System.Windows;

namespace Nostrum.Extensions
{
    public static class FrameworkElementExtensions
    {
        /// <summary>
        /// Returns the DataContext of the <see cref="FrameworkElement"/>, casting it to <typeparamref name="T"/>.
        /// Returns null if the cast fails.
        /// </summary>
        /// <typeparam name="T">return type</typeparam>
        /// <returns>the DataContext casted to T</returns>
        public static T? GetDataContext<T>(this FrameworkElement fe) where T : class
        {
            return fe.DataContext is not T t ? null : t;
        }
    }
}