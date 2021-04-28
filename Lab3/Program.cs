using Lab3.Ex;
using Lab3.Sortings;
using Lab3.Sortings.Abstractions;
using Lab3.Sortings.Delegates;
using System;
using System.Collections.Generic;

namespace Lab3
{
    public record SomeItem(int First, double Second);

    class CloneableList<T> : List<T>, ICloneable
    {
        public object Clone()
        {
            CloneableList<T> clone = new CloneableList<T>();
            foreach (T item in this)
                clone.Add(item);
            return clone;
        }
    }

    class Program
    {
        enum SortType
        {
            Bubble,
            Insertion,
            Selection,
            Merge,
            Heap,
            Quick
        }

        private static Random _random = new Random(123);

        static void Main(string[] args)
        {
            KeySelector<SomeItem, (int, double)> keySelector = unit => (unit.First, unit.Second);
            KeyComparer<(int, double)> keyComparer = (a, b) =>
            {
                int compareRes = a.Item1.CompareTo(b.Item1);
                if (compareRes != 0)
                    return compareRes;
                else
                    return a.Item2.CompareTo(b.Item2);
            };

            List<SomeItem> items = new List<SomeItem>()
            {
                new SomeItem(0, 0.1),
                new SomeItem(1, 0),
                new SomeItem(1, 0),
                new SomeItem(1, -2.5),
                new SomeItem(30, 0.5),
                new SomeItem(1, -3.2),
                new SomeItem(-5, 666.666),
                new SomeItem(-10, 55),
                new SomeItem(12, 33),
                new SomeItem(56, 23),
                new SomeItem(2, 2),
                new SomeItem(3, 3),
            };

            Random random = new Random(132);
            items.Shuffle(random);
            Console.WriteLine("Shuffled:");
            Print(items);

            ISortStrategy<SomeItem> sortStrategy = GetStategy(keySelector, keyComparer, SortType.Selection);
            sortStrategy.Sort(items);

            Console.WriteLine("Sorted:");
            Print(items);
        }

        private static void Print<T>(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static ISortStrategy<T> GetStategy<T, K>(KeySelector<T, K> keySelector, 
            KeyComparer<K> keyComparer, SortType sortType)
        {
            switch (sortType)
            {
                default:
                case SortType.Bubble:
                    return new BubbleSort<T, K>(keySelector, keyComparer);
                case SortType.Insertion:
                    return new InsertionSort<T, K>(keySelector, keyComparer);
                case SortType.Selection:
                    return new SelectionSort<T, K>(keySelector, keyComparer);
                case SortType.Merge:
                    return new MergeSort<T, K>(keySelector, keyComparer);
                case SortType.Heap:
                    return new HeapSort<T, K>(keySelector, keyComparer);
                case SortType.Quick:
                    return new QuickSort<T, K>(keySelector, keyComparer);
            }
        }
    }
}
