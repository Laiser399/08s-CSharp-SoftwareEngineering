using Lab1.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Abstractions.Builders
{
    interface IGPUBuilder
    {
        void SetMemoryCapacityGB(int capacityGB);
        void SetMemoryType(GPUMemoryType memoryType);
        void SetBitWidth(BitWidth bitWidth);
        void Reset();
    }
}
