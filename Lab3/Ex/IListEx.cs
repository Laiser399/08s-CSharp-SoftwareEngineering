using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Ex
{
    public static class IListEx
    {
        public static void Shuffle<T>(this IList<T> items, Random random = null)
        {
            if (random is null)
                random = new Random();

            for (int i = 0; i < items.Count; i++)
            {
                int index = random.Next(0, items.Count);
                T tm = items[index];
                items[index] = items[i];
                items[i] = tm;
            }
        }
    }
}
