using System;
using System.Threading;
using System.Windows.Threading;

namespace FoglioUtils.Extensions
{
    public static class DispatcherExtensions
    {
        public static void InvokeIfRequired(this Dispatcher disp, Action dotIt, DispatcherPriority priority)
        {
            if (disp.Thread != Thread.CurrentThread)
                disp.Invoke(priority, dotIt);
            else
                dotIt();
        }
        public static void InvokeAsyncIfRequired(this Dispatcher disp, Action dotIt, DispatcherPriority priority)
        {
            if (disp.Thread != Thread.CurrentThread)
                disp.InvokeAsync(dotIt, priority);
            else
                dotIt();
        }
    }
}