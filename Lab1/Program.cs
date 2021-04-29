using Lab1.Abstractions;
using Lab1.Abstractions.Components;
using System;
using System.Collections.Generic;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            IPCFactory factory = DefaultPCFactory.Instance;

            IComputer low = factory.Make(PerformanceTemplate.Low);
            IComputer office = factory.Make(PerformanceTemplate.Office);
            IComputer gaming = factory.Make(PerformanceTemplate.Gaming);

            Console.WriteLine(low);
            Console.WriteLine();
            Console.WriteLine(office);
            Console.WriteLine();
            Console.WriteLine(gaming);
            Console.WriteLine();
        }
    }
}
