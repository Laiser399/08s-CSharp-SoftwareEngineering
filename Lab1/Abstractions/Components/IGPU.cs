using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Abstractions.Components
{
    enum GPUMemoryType
    {
        GDDR3,
        GDDR5,
        GDDR6
    }

    enum BitWidth
    {
        _128bit,
        _192bit,
        _256bit
    }

    interface IGPU
    {
        int MemoryCapacityGB { get; }
        GPUMemoryType MemoryType { get; }
        BitWidth BitWidth { get; }
    }
}
