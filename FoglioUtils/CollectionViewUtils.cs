using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;

namespace FoglioUtils
{
    public static class CollectionViewUtils
    {
        public static void Holder(object sender, EventArgs ev) { }

        public static ICollectionView InitView<T>(IEnumerable<T> source, Predicate<T> predicate = null, IEnumerable<SortDescription> sortDescr = null)
        {
            var view = new CollectionViewSource { Source = source }.View;
            if (predicate == null) view.Filter = null;
            else view.Filter = o => predicate.Invoke((T)o);

            if (sortDescr != null)
            {
                foreach (var sd in sortDescr)
                {
                    view.SortDescriptions.Add(sd);
                }
            }

            view.CollectionChanged += Holder;
            return view;
        }

        public static ICollectionViewLiveShaping InitLiveView<T>(IEnumerable<T> source, Predicate<T> predicate = null, string[] filters = null, SortDescription[] sortFilters = null)
        {
            var cv = new CollectionViewSource { Source = source }.View;

            if (predicate == null) cv.Filter = null;
            else cv.Filter = o => predicate.Invoke((T)o);

            if (!(cv is ICollectionViewLiveShaping liveView)) return null;
            if (!liveView.CanChangeLiveFiltering) return null;
            if (filters?.Length > 0)
            {
                foreach (var filter in filters)
                {
                    liveView.LiveFilteringProperties.Add(filter);
                }
                liveView.IsLiveFiltering = true;
            }
            ((ICollectionView)liveView).CollectionChanged += Holder;

            if (sortFilters == null || sortFilters.Length <= 0) return liveView;

            foreach (var filter in sortFilters)
            {
                ((ICollectionView)liveView).SortDescriptions.Add(filter);
                liveView.LiveSortingProperties.Add(filter.PropertyName);
            }

            liveView.IsLiveSorting = true;

            return liveView;
        }
    }
}
