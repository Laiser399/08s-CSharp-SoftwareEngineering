using Lab1.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Abstractions.Builders
{
    interface IRAMBuilder
    {
        void SetCapacityGB(int capacity);
        void SetRamType(RAMType type);
        void SetClockFrequencyMGz(int frequency);
        void Reset();
    }
}
