using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Nostrum.Extensions
{
    public static class DispatcherExtensions
    {
        /// <summary>
        /// Calls <see cref="Dispatcher.Invoke(DispatcherPriority, Delegate)"/> on this dispatcher if the calling thread is different from the thread of the dispatcher, else the action is executed directly.
        /// </summary>
        public static void InvokeIfRequired(this Dispatcher disp, Action action, DispatcherPriority priority)
        {
            if (disp.Thread != Thread.CurrentThread)
                disp.Invoke(priority, action);
            else
                action();
        }
        /// <summary>
        /// Calls <see cref="Dispatcher.InvokeAsync(Action, DispatcherPriority)"/> on this dispatcher if the calling thread is different from the thread of the dispatcher, else the action is executed directly.
        /// </summary>
        public static void InvokeAsyncIfRequired(this Dispatcher disp, Action method, DispatcherPriority priority)
        {
            if (disp.Thread != Thread.CurrentThread)
                disp.InvokeAsync(method, priority);
            else
                method();
        }

        /// <summary>
        /// Invokes an action on this dispatcher to check if it's alive and not deadlocked.
        /// </summary>
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
            return await Task.Delay(timeoutMs).ContinueWith(_ => result != TimeSpan.MaxValue);

        }
    }
}