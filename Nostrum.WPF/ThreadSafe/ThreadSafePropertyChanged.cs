using System;

namespace Nostrum.WPF.ThreadSafe
{
    //// TODO: remove
    [Obsolete("Use " + nameof(ThreadSafeObservableObject) + " instead.")]
    public class ThreadSafePropertyChanged : ThreadSafeObservableObject { }
}