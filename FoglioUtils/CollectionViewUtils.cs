using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;

namespace FoglioUtils
{
    public static class CollectionViewUtils
    {
        public static void Holder(object sender, EventArgs ev) { }

        public static ICollectionView InitView(Predicate<object> filter, IEnumerable source, IEnumerable<SortDescription> sortDescr)
        {
            var view = new CollectionViewSource { Source = source }.View;
            view.Filter = filter;
            foreach (var sd in sortDescr)
            {
                view.SortDescriptions.Add(sd);
            }

            view.CollectionChanged += Holder;
            return view;
        }

        public static ICollectionViewLiveShaping InitLiveView<T>(Predicate<object> predicate, IEnumerable<T> source, string[] filters, SortDescription[] sortFilters)
        {
            var cv = new CollectionViewSource { Source = source }.View;
            cv.Filter = predicate;
            if (!(cv is ICollectionViewLiveShaping liveView)) return null;
            if (!liveView.CanChangeLiveFiltering) return null;
            if (filters.Length > 0)
            {
                foreach (var filter in filters)
                {
                    liveView.LiveFilteringProperties.Add(filter);
                }
                liveView.IsLiveFiltering = true;
            }

            if (sortFilters.Length <= 0) return liveView;

            foreach (var filter in sortFilters)
            {
                ((ICollectionView)liveView).SortDescriptions.Add(filter);
                liveView.LiveSortingProperties.Add(filter.PropertyName);
            }

            liveView.IsLiveSorting = true;
            ((ICollectionView)liveView).CollectionChanged += Holder;

            return liveView;
        }
    }
}
