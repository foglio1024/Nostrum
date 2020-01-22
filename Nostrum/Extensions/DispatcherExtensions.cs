using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Nostrum.Extensions
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

        public static async Task<bool> IsAlive(this Dispatcher d, int timeoutMs)
        {
            var sw = new Stopwatch();
            sw.Start();
            var result = TimeSpan.MaxValue;
            _ = d.InvokeAsync(() =>
              {
                  sw.Stop();
                  result = sw.Elapsed;
              });
            return await Task.Delay(timeoutMs).ContinueWith(t => result != TimeSpan.MaxValue);

        }
    }
}