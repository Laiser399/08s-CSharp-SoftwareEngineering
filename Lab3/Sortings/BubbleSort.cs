using Lab3.Sortings.Abstractions;
using Lab3.Sortings.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Sortings
{
    public class BubbleSort<T, K> : BaseSortStrategy<T, K>
    {
        public BubbleSort(KeySelector<T, K> keySelector, IComparer<K> comparer) :
            base(keySelector, comparer)
        { }

        public BubbleSort(KeySelector<T, K> keySelector, KeyComparer<K> comparer) :
            base(keySelector, comparer)
        { }

        // TODO where ICloneable or IPrototype
        public override void Sort(IList<T> items, SortDirection direction = SortDirection.Ascending)
        {
            KeyComparer<K> comparer = direction == SortDirection.Ascending 
                ? _comparer 
                : (a, b) => _comparer(b, a);

            for (int i = 1; i < items.Count; i++)
            {
                for (int j = 0; j < items.Count - i; j++)
                {
                    K key1 = _keySelector(items[j]);
                    K key2 = _keySelector(items[j + 1]);
                    if (comparer(key1, key2) > 0)
                    {
                        T tm = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = tm;
                    }
                }
            }
        }
    }
}
