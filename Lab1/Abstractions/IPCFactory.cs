using Lab1.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Abstractions
{
    interface IPCFactory
    {
        IComputer Make(PerformanceTemplate template);
    }
}
