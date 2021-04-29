using Lab1.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Abstractions.Builders
{
    interface IRAMBuilder
    {
        void SetCapacity(int capacityMB);
        void SetRamType(RAMType type);
        void SetClockFrequencyMGz(int frequency);
    }
}
