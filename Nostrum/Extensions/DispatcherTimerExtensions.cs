using System.Windows.Threading;

namespace Nostrum.Extensions
{
    public static class DispatcherTimerExtensions
    {
        public static void Refresh(this DispatcherTimer t)
        {
            t.Stop();
            t.Start();
        }
    }
}