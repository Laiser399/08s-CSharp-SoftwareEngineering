using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Sortings.Abstractions
{
    public interface ISortStrategy<T>
    {
        void Sort(IList<T> items, SortDirection direction = SortDirection.Ascending);
    }
}
