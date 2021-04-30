using Lab3.Sortings.Abstractions;
using Lab3.Sortings.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Sortings
{
    public class MergeSort<T, K> : BaseSortStrategy<T, K>
    {
        public MergeSort(KeySelector<T, K> keySelector, IComparer<K> comparer) :
            base(keySelector, comparer)
        { }

        public MergeSort(KeySelector<T, K> keySelector, KeyComparer<K> comparer) :
            base(keySelector, comparer)
        { }

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
            if (count == 2)
            {
                K key1 = _keySelector(items[start]);
                K key2 = _keySelector(items[start + 1]);
                if (comparer(key1, key2) > 0)
                {
                    T tm = items[start];
                    items[start] = items[start + 1];
                    items[start + 1] = tm;
                }
            }
            else
            {
                int leftCount = count / 2;
                int rightCount = count - leftCount;
                Recursion(items, start, leftCount, comparer);
                Recursion(items, start + leftCount, rightCount, comparer);
                Merge(items, start, leftCount, rightCount, comparer);
            }
        }

        private void Merge(IList<T> items, int start, int leftCount, int rightCount, KeyComparer<K> comparer)
        {
            T[] left = new T[leftCount];
            T[] right = new T[rightCount];
            for (int i = 0; i < leftCount; i++)
                left[i] = items[start + i];
            for (int i = 0; i < rightCount; i++)
                right[i] = items[start + leftCount + i];

            int iLeft = 0;
            int iRight = 0;
            int offset = 0;
            while (iLeft < leftCount && iRight < rightCount)
            {
                K key1 = _keySelector(left[iLeft]);
                K key2 = _keySelector(right[iRight]);
                if (comparer(key1, key2) < 0)
                {
                    items[start + offset] = left[iLeft];
                    iLeft++;
                }
                else
                {
                    items[start + offset] = right[iRight];
                    iRight++;
                }
                offset++;
            }

            while (iLeft < leftCount)
            {
                items[start + offset] = left[iLeft];
                iLeft++;
                offset++;
            }

            while (iRight < rightCount)
            {
                items[start + offset] = right[iRight];
                iRight++;
                offset++;
            }
        }
    }
}
