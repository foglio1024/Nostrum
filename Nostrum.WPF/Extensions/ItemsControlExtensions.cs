using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Nostrum.WPF.Extensions
{
    public static class ItemsControlExtensions
    {
        /// <summary>
        /// Refreshes the <see cref="ItemsControl.ItemTemplateSelector"/> retrieving it by name from the Application resources.
        /// </summary>
        public static void RefreshTemplate(this ItemsControl el, string resName)
        {
            el.Dispatcher?.InvokeAsync(() =>
            {
                el.ItemTemplateSelector = null;
                el.ItemTemplateSelector = Application.Current.FindResource(resName) as DataTemplateSelector;
            }, DispatcherPriority.Background);
        }

        /// <summary>
        /// Refreshes the <see cref="ItemsControl.ItemTemplateSelector"/> using the given <paramref name="selector"/>.
        /// </summary>
        public static void RefreshTemplate(this ItemsControl el, DataTemplateSelector selector)
        {
            el.Dispatcher?.InvokeAsync(() =>
            {
                el.ItemTemplateSelector = null;
                el.ItemTemplateSelector = selector;
            }, DispatcherPriority.Background);
        }
    }
}