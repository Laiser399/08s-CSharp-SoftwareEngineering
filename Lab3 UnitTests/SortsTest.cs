using Lab3;
using Lab3.Ex;
using Lab3.Sortings;
using Lab3.Sortings.Abstractions;
using Lab3.Sortings.Delegates;
using System;
using System.Collections.Generic;
using Xunit;

namespace Lab3_UnitTests
{
    public class SortsTest
    {
        private List<SomeItem> _items = new List<SomeItem>();
        private Random _random = new Random(123);

        private KeySelector<SomeItem, (int, double)> _keySelector;
        private KeyComparer<(int, double)> _keyComparer;

        public SortsTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                _items.Add(new SomeItem(_random.Next(), _random.NextDouble()));
            }
            SomeItem u = _items[0];
            _items.Add(new SomeItem(u.First, u.Second));
            _items.Add(new SomeItem(_random.Next(), u.Second));
            _items.Add(new SomeItem(u.First, _random.NextDouble()));

            _keySelector = unit => (unit.First, unit.Second);
            _keyComparer = (a, b) =>
            {
                int compareRes = a.Item1.CompareTo(b.Item1);
                if (compareRes != 0)
                    return compareRes;
                else
                    return a.Item2.CompareTo(b.Item2);
            };
        }

        [Fact]
        public void BubbleTest()
        {
            ISortStrategy<SomeItem> sortStrategy = 
                new BubbleSort<SomeItem, (int, double)>(_keySelector, _keyComparer);

            MainTest(_items, sortStrategy);
        }

        [Fact]
        public void InsertionTest()
        {
            ISortStrategy<SomeItem> sortStrategy =
                new InsertionSort<SomeItem, (int, double)>(_keySelector, _keyComparer);

            MainTest(_items, sortStrategy);
        }

        [Fact]
        public void SelectionTest()
        {
            ISortStrategy<SomeItem> sortStrategy =
                new SelectionSort<SomeItem, (int, double)>(_keySelector, _keyComparer);

            MainTest(_items, sortStrategy);
        }

        [Fact]
        public void MergeTest()
        {
            ISortStrategy<SomeItem> sortStrategy =
                new MergeSort<SomeItem, (int, double)>(_keySelector, _keyComparer);

            MainTest(_items, sortStrategy);
        }

        [Fact]
        public void HeapTest()
        {
            ISortStrategy<SomeItem> sortStrategy =
                new HeapSort<SomeItem, (int, double)>(_keySelector, _keyComparer);

            MainTest(_items, sortStrategy);
        }

        [Fact]
        public void QuickTest()
        {
            ISortStrategy<SomeItem> sortStrategy =
                new QuickSort<SomeItem, (int, double)>(_keySelector, _keyComparer);

            MainTest(_items, sortStrategy);
        }

        private void MainTest<T>(IList<T> items, ISortStrategy<T> sortStrategy)
        {
            items.Shuffle(_random);
            sortStrategy.Sort(items);
            for (int i = 0; i < _items.Count - 1; i++)
            {
                var k1 = _keySelector(_items[i]);
                var k2 = _keySelector(_items[i + 1]);
                Assert.True(_keyComparer(k1, k2) <= 0, 
                    $"On asc. i = {i}. Items: {_items[i]}, {_items[i + 1]}");
            }

            items.Shuffle(_random);
            sortStrategy.Sort(items, SortDirection.Descending);
            for (int i = 0; i < _items.Count - 1; i++)
            {
                var k1 = _keySelector(_items[i]);
                var k2 = _keySelector(_items[i + 1]);
                Assert.True(_keyComparer(k1, k2) >= 0,
                    $"On desc. i = {i}. Items: {_items[i]}, {_items[i + 1]}");
            }
        }

    }
}
