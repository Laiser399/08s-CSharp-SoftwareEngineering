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
    class RAMBuilder : IRAMBuilder
    {
        private const int _defaultCapacityGB = 2;
        private const int _defaultFrequencyMGz = 1600;
        private const RAMType _defaultRAMType = RAMType.DDR3;

        private int _capacityGB = _defaultCapacityGB;
        private int _frequencyMGz = _defaultFrequencyMGz;
        private RAMType _type = _defaultRAMType;

        public RAM Result => new RAM(_capacityGB, _type, _frequencyMGz);

        public void SetCapacityGB(int capacity)
        {
            _capacityGB = capacity;
        }

        public void SetClockFrequencyMGz(int frequencyMGz)
        {
            _frequencyMGz = frequencyMGz;
        }

        public void SetRamType(RAMType type)
        {
            _type = type;
        }

        public void Reset()
        {
            _capacityGB = _defaultCapacityGB;
            _frequencyMGz = _defaultFrequencyMGz;
            _type = _defaultRAMType;
        }
    }
}
