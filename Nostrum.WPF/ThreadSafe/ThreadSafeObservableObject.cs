using Nostrum.WPF.Extensions;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace Nostrum.WPF.ThreadSafe
{
    /// <summary>
    /// An object which keeps a reference to a <see cref="Dispatcher"/> and invokes <see cref="INotifyPropertyChanged.PropertyChanged"/> notifications on the relative thread if needed.
    /// </summary>
    public class ThreadSafeObservableObject : ObservableObject
    {
        protected Dispatcher? _dispatcher;

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

        /// <inheritdoc />
        protected override sealed void N([CallerMemberName] string? propertyName = null, int delayMs = 0)
        {
            if (_dispatcher == null) SetDispatcher(Dispatcher.CurrentDispatcher);

            base.N(propertyName, delayMs);
        }

        /// <inheritdoc />
        protected override sealed void InvokePropertyChanged(string? propertyName)
        {
            _dispatcher!.InvokeAsyncIfRequired(() => base.InvokePropertyChanged(propertyName), DispatcherPriority.DataBind);
        }
    }
}