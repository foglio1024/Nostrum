using System.ComponentModel;
using Nostrum.Factories;

namespace Nostrum.Extensions
{
    public static class ICollectionViewExtensions
    {
        public static void Free(this ICollectionView view)
        {
            view.CollectionChanged -= CollectionViewFactory.Holder;
        }
    }
}