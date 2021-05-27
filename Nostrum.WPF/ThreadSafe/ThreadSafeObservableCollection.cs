using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Data;
using System.Windows.Threading;
using Nostrum.WPF.Extensions;

namespace Nostrum.WPF.ThreadSafe
{
    /// <summary>
    /// An <see cref="ObservableCollection{T}"/> which keeps a reference to its own <see cref="Dispatcher"/> and uses it to invoke operations on the relative thread.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ThreadSafeObservableCollection<T> : ObservableCollection<T>
    {
        private readonly Dispatcher _dispatcher;
        private readonly ReaderWriterLockSlim _lock;

        /// <summary>
        /// Default constructor. If the given dispatcher is null, <see cref="Dispatcher.CurrentDispatcher"/> is used.
        /// </summary>
        /// <param name="d"></param>
        public ThreadSafeObservableCollection(Dispatcher? d = null)
        {
            _dispatcher = d ?? Dispatcher.CurrentDispatcher;
            _lock = new ReaderWriterLockSlim();
            BindingOperations.EnableCollectionSynchronization(this, _lock);
        }

        /// <inheritdoc />
        protected override void ClearItems()
        {
            _dispatcher.InvokeIfRequired(() =>
            {
                _lock.EnterWriteLock();
                try
                {
                    base.ClearItems();
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
            }, DispatcherPriority.DataBind);
        }

        /// <inheritdoc />
        protected override void InsertItem(int index, T item)
        {
            _dispatcher.InvokeIfRequired(() =>
            {
                if (index > Count)
                    return;
                _lock.EnterWriteLock();
                try
                {
                    base.InsertItem(index, item);
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
            }, DispatcherPriority.DataBind);
        }

        /// <inheritdoc />
        protected override void MoveItem(int oldIndex, int newIndex)
        {
            _dispatcher.InvokeIfRequired(() =>
            {
                _lock.EnterReadLock();
                var count = Count;
                _lock.ExitReadLock();
                if (oldIndex >= count | newIndex >= count | oldIndex == newIndex)
                    return;
                _lock.EnterWriteLock();
                try
                {
                    base.MoveItem(oldIndex, newIndex);
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
            }, DispatcherPriority.DataBind);
        }

        /// <inheritdoc />
        protected override void RemoveItem(int index)
        {
            _dispatcher.InvokeIfRequired(() =>
            {
                if (index >= Count)
                    return;
                _lock.EnterWriteLock();
                try
                {
                    base.RemoveItem(index);
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
            }, DispatcherPriority.DataBind);
        }

        /// <inheritdoc />
        protected override void SetItem(int index, T item)
        {
            _dispatcher.InvokeIfRequired(() =>
            {
                _lock.EnterWriteLock();
                try
                {
                    base.SetItem(index, item);
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
            }, DispatcherPriority.DataBind);
        }

        /// <summary>
        /// Creates a new <see cref="List{T}"/> from this collection.
        /// </summary>
        /// <returns>the newly created <see cref="List{T}"/></returns>
        public List<T> ToSyncList()
        {
            _lock.EnterReadLock();
            try
            {
                var list = new List<T>();
                list.AddRange(this);
                return list;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }
    }
}