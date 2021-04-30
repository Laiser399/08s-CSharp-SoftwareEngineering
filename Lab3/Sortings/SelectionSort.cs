using Lab3.Sortings.Abstractions;
using Lab3.Sortings.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Sortings
{
    public class SelectionSort<T, K> : BaseSortStrategy<T, K>
    {
        public SelectionSort(KeySelector<T, K> keySelector, IComparer<K> comparer) :
            base(keySelector, comparer)
        { }

        public SelectionSort(KeySelector<T, K> keySelector, KeyComparer<K> comparer) :
            base(keySelector, comparer)
        { }

        public override void Sort(IList<T> items, SortDirection direction = SortDirection.Ascending)
        {
            KeyComparer<K> comparer = direction == SortDirection.Ascending
                ? _comparer
                : (a, b) => _comparer(b, a);

            for (int i = 0; i < items.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < items.Count; j++)
                {
                    K key1 = _keySelector(items[j]);
                    K key2 = _keySelector(items[min]);
                    if (comparer(key1, key2) < 0)
                        min = j;
                }

                T tm = items[i];
                items[i] = items[min];
                items[min] = tm;
            }
        }
    }
}
