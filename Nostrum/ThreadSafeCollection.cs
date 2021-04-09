using Nostrum.Extensions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Data;
using System.Windows.Threading;

namespace Nostrum
{
    /// <summary>
    /// A <see cref="Collection{T}"/> which keeps a reference to its own <see cref="Dispatcher"/> and uses it to invoke operations on the relative thread.
    /// </summary>
    /// <typeparam name="T">the type of the items in the collection</typeparam>
    public class ThreadSafeCollection<T> : Collection<T>
    {
        private readonly Dispatcher _dispatcher;
        private readonly ReaderWriterLockSlim _lock;

        /// <summary>
        /// Default constructor. If the given dispatcher is null, <see cref="Dispatcher.CurrentDispatcher"/> is used.
        /// </summary>
        /// <param name="d"></param>
        public ThreadSafeCollection(Dispatcher? d = null)
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