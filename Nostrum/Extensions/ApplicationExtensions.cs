using System;
using System.Reflection;
using System.Windows;

namespace Nostrum.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="Application"/> type.
    /// </summary>
    public static class ApplicationExtensions
    {
        /// <summary>
        /// Returns the version of the <see cref="Assembly"/> containing the currently running <see cref="Application"/>.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static Version GetVersion(this Application app)
        {
            return app.GetType().Assembly.GetName().Version ?? new Version();
        }
    }
}