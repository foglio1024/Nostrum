using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using FoglioUtils.Extensions;

namespace FoglioUtils
{
    public class TSPropertyChanged : INotifyPropertyChanged
    {
        protected Dispatcher Dispatcher;
        public event PropertyChangedEventHandler PropertyChanged;

        public Dispatcher GetDispatcher()
        {
            return Dispatcher;
        }
        public void SetDispatcher(Dispatcher newDispatcher)
        {
            Dispatcher = newDispatcher;
        }

        protected void N([CallerMemberName] string v = null)
        {
            if (Dispatcher == null) SetDispatcher(Dispatcher.CurrentDispatcher);
            Dispatcher.InvokeAsyncIfRequired(() =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v)), DispatcherPriority.DataBind);
        }

        public void ExN([CallerMemberName] string v = null) => N(v);
    }
}
