using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Nostrum.WPF
{
    public class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Event fired via the <see cref="N"/> method when a property is changed.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Fires the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">the name of the changed property</param>
        /// <param name="delayMs">delay to wait beofore the <see cref="PropertyChanged"/> event is fired</param>
        [Obsolete($"Use {nameof(RaiseAndSetIfChanged)} instead.")]
        protected virtual void N([CallerMemberName] string? propertyName = null, int delayMs = 0)
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

        /// <summary>
        /// Calls the <see cref="N"/> method externally.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="delayMs"></param>
        public void ExN([CallerMemberName] string? propertyName = null, int delayMs = 0)
        {
            InvokePropertyChanged(propertyName, delayMs);
        }

        protected virtual void InvokePropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Compares the new value with the one currently stored in the backing field. Sets the new value and raises PropertyChanged if the values are different.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="backingField"></param>
        /// <param name="propertyName"></param>
        /// <param name="delayMs"></param>
        /// <returns>true if the value changed, false otherwise</returns>
        protected virtual bool RaiseAndSetIfChanged<T>(T value, ref T backingField, [CallerMemberName] string? propertyName = null, int delayMs = 0)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
            {
                return false;
            }

            backingField = value;

            InvokePropertyChanged(propertyName, delayMs);

            return true;
        }

        void InvokePropertyChanged(string? propertyName, int delayMs)
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
    }
}