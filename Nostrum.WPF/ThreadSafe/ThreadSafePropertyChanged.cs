using Nostrum.WPF.Extensions;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Threading;

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
        /// <param name="delayMs">delay to wait beofore the <see cref="PropertyChanged"/> event is fired</param>
        protected void N([CallerMemberName] string? propertyName = null, int delayMs = 0)
        {
            if (delayMs > 0)
            {
                Task.Factory.StartNew(async () =>
                {
                    await Task.Delay(delayMs);
                    InvokePropertyChanged(propertyName);
                });
            }
            else
            {
                InvokePropertyChanged(propertyName);
            }
        }

        private void InvokePropertyChanged(string? propertyName)
        {
            if (_dispatcher == null) SetDispatcher(Dispatcher.CurrentDispatcher);
            _dispatcher!.InvokeAsyncIfRequired(() =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)), DispatcherPriority.DataBind);
        }

        /// <summary>
        /// Calls the <see cref="N"/> method externally.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="delayMs"></param>
        public void ExN([CallerMemberName] string? propertyName = null, int delayMs = 0)
        {
            N(propertyName, delayMs);
        }
    }
}