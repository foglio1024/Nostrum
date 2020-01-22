using System.ComponentModel;

namespace Nostrum.Extensions
{
    public static class ICollectionViewExtensions
    {
        public static void Free(this ICollectionView view)
        {
            view.CollectionChanged -= CollectionViewUtils.Holder;
        }
    }
}