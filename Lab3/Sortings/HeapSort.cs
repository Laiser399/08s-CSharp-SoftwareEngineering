using Lab3.Sortings.Abstractions;
using Lab3.Sortings.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Sortings
{
    public class HeapSort<T, K> : BaseSortStrategy<T, K>
    {
        public HeapSort(KeySelector<T, K> keySelector, IComparer<K> comparer) :
            base(keySelector, comparer)
        { }

        public HeapSort(KeySelector<T, K> keySelector, KeyComparer<K> comparer) :
            base(keySelector, comparer)
        { }

        // TODO where ICloneable or IPrototype
        public override void Sort(IList<T> items, SortDirection direction = SortDirection.Ascending)
        {
            KeyComparer<K> comparer = direction == SortDirection.Ascending
                ? _comparer
                : (a, b) => _comparer(b, a);

            for (int i = items.Count / 2 - 1; i > -1; i--)
                Heapify(items, i, items.Count, comparer);

            for (int i = 0; i < items.Count - 1; i++)
            {
                T tm = items[items.Count - 1 - i];
                items[items.Count - 1 - i] = items[0];
                items[0] = tm;

                Heapify(items, 0, items.Count - 1 - i, comparer);
            }
        }

        private void Heapify(IList<T> items, int i, int itemsCount, KeyComparer<K> comparer)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;

            if (left < itemsCount)
            {
                K largestKey = _keySelector(items[largest]);
                K leftKey = _keySelector(items[left]);
                if (comparer(leftKey, largestKey) > 0)
                    largest = left;
            }
            if (right < itemsCount)
            {
                K largestKey = _keySelector(items[largest]);
                K rightKey = _keySelector(items[right]);
                if (comparer(rightKey, largestKey) > 0)
                    largest = right;
            }

            if (largest != i)
            {
                T tm = items[largest];
                items[largest] = items[i];
                items[i] = tm;
                Heapify(items, largest, itemsCount, comparer);
            }
        }
    }
}
