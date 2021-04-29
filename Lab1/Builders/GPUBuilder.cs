using Lab1.Abstractions.Builders;
using Lab1.Abstractions.Components;
using Lab1.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Builders
{
    class GPUBuilder : IGPUBuilder
    {
        private const BitWidth _defaultBitWidth = BitWidth._128bit;
        private const int _defaultCapacityGB = 2;
        private const GPUMemoryType _defaultMemoryType = GPUMemoryType.GDDR3;

        private BitWidth _bitWidth = _defaultBitWidth;
        private int _capacityGB = _defaultCapacityGB;
        private GPUMemoryType _memoryType = _defaultMemoryType;

        public GPU Result => new GPU(_capacityGB, _memoryType, _bitWidth);

        public void SetBitWidth(BitWidth bitWidth)
        {
            _bitWidth = bitWidth;
        }

        public void SetMemoryCapacityGB(int capacityGB)
        {
            _capacityGB = capacityGB;
        }

        public void SetMemoryType(GPUMemoryType memoryType)
        {
            _memoryType = memoryType;
        }

        public void Reset()
        {
            _bitWidth = _defaultBitWidth;
            _capacityGB = _defaultCapacityGB;
            _memoryType = _defaultMemoryType;
        }
    }
}
