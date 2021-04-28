using Lab3.Sortings.Abstractions;
using Lab3.Sortings.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Sortings
{
    public class QuickSort<T, K> : BaseSortStrategy<T, K>
    {
        public QuickSort(KeySelector<T, K> keySelector, IComparer<K> comparer) :
            base(keySelector, comparer)
        { }

        public QuickSort(KeySelector<T, K> keySelector, KeyComparer<K> comparer) :
            base(keySelector, comparer)
        { }

        // TODO where ICloneable or IPrototype
        public override void Sort(IList<T> items, SortDirection direction = SortDirection.Ascending)
        {
            KeyComparer<K> comparer = direction == SortDirection.Ascending
                ? _comparer
                : (a, b) => _comparer(b, a);

            Recursion(items, 0, items.Count, comparer);
        }

        private void Recursion(IList<T> items, int start, int count, KeyComparer<K> comparer)
        {
            if (count <= 1)
                return;

            int bearing = start + count - 1;
            int i = start;
            while (i < bearing)
            {
                K key1 = _keySelector(items[i]);
                K key2 = _keySelector(items[bearing]);
                if (comparer(key1, key2) >= 0)
                {
                    T tm = items[i];
                    items[i] = items[bearing - 1];
                    items[bearing - 1] = items[bearing];
                    items[bearing] = tm;

                    bearing--;
                }
                else
                {
                    i++;
                }
            }

            Recursion(items, start, bearing - start, comparer);
            Recursion(items, bearing + 1, start + count - bearing - 1, comparer);
        }
    }
}
