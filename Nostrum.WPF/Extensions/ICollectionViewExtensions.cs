using System.ComponentModel;
using Nostrum.WPF.Factories;

namespace Nostrum.WPF.Extensions
{
    public static class ICollectionViewExtensions
    {
        /// <summary>
        /// Unsubscribes the <see cref="ICollectionView"/> from the <see cref="CollectionViewFactory.Holder"/> static handler.
        /// </summary>
        public static void Free(this ICollectionView view)
        {
            view.CollectionChanged -= CollectionViewFactory.Holder;
        }
    }
}