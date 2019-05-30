using System.Windows.Threading;

namespace FoglioUtils.Extensions
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