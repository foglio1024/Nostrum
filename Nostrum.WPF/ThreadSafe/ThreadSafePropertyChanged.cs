using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using Nostrum.WPF.Extensions;

namespace Nostrum.WPF.ThreadSafe
{
    /// <summary>
    /// An object which keeps a reference to a <see cref="Dispatcher"/> and invokes <see cref="INotifyPropertyChanged.PropertyChanged"/> notifications on the relative thread if needed.
    /// </summary>
    public class ThreadSafePropertyChanged : INotifyPropertyChanged
    {
        protected Dispatcher? _dispatcher;

        /// <summary>
        /// Event fired via the <see cref="N"/> method when a property is changed.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Returns the underlying <see cref="Dispatcher"/>.
        /// </summary>
        /// <returns></returns>
        public Dispatcher? GetDispatcher()
        {
            return _dispatcher;
        }

        /// <summary>
        /// Sets a new <see cref="Dispatcher"/>.
        /// </summary>
        /// <param name="newDispatcher"></param>
        public void SetDispatcher(Dispatcher newDispatcher)
        {
            _dispatcher = newDispatcher;
        }

        /// <summary>
        /// Fires the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">the name of the changed property</param>
        protected void N([CallerMemberName] string? propertyName = null)
        {
            if (_dispatcher == null) SetDispatcher(Dispatcher.CurrentDispatcher);
            _dispatcher!.InvokeAsyncIfRequired(() =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)), DispatcherPriority.DataBind);
        }

        /// <summary>
        /// Calls the <see cref="N"/> method externally.
        /// </summary>
        /// <param name="propertyName"></param>
        public void ExN([CallerMemberName] string? propertyName = null)
        {
            N(propertyName);
        }
    }
}