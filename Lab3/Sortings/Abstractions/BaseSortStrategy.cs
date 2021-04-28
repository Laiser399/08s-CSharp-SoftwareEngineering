using Lab3.Sortings.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Sortings.Abstractions
{
    public abstract class BaseSortStrategy<T, K> : ISortStrategy<T>
    {
        protected KeySelector<T, K> _keySelector;
        protected KeyComparer<K> _comparer;

        public BaseSortStrategy(KeySelector<T, K> keySelector, IComparer<K> comparer) :
            this(keySelector, (a, b) => comparer.Compare(a, b))
        { }

        public BaseSortStrategy(KeySelector<T, K> keySelector, KeyComparer<K> comparer)
        {
            _keySelector = keySelector;
            _comparer = comparer;
        }

        public abstract void Sort(IList<T> items, SortDirection direction = SortDirection.Ascending);
    }
}
