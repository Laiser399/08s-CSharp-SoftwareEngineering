using Lab1.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Components
{
    record GPU(int MemoryCapacityGB, GPUMemoryType MemoryType, BitWidth BitWidth) : IGPU
    {
    }
}
