using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace FoglioUtils.Extensions
{
    public static class ItemsControlExtensions
    {
        public static void RefreshTemplate(this ItemsControl el, string resName)
        {
            el?.Dispatcher?.BeginInvoke(new Action(() =>
            {
                el.ItemTemplateSelector = null;
                el.ItemTemplateSelector = Application.Current.FindResource(resName) as DataTemplateSelector;
            }), DispatcherPriority.Background);
        }
        public static void RefreshTemplate(this ItemsControl el, DataTemplateSelector selector)
        {
            el?.Dispatcher?.BeginInvoke(new Action(() =>
            {
                el.ItemTemplateSelector = null;
                el.ItemTemplateSelector = selector;
            }), DispatcherPriority.Background);
        }
    }
}