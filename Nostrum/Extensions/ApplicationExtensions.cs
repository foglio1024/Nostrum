using System;

namespace Nostrum.Extensions
{
    public static class ApplicationExtensions
    {
        public static System.Version GetVersion(this System.Windows.Application app)
        {
            return app.GetType().Assembly.GetName().Version ?? new Version();
        }
    }
}