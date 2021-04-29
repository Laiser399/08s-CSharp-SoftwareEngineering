using Lab1.Abstractions.Builders;
using Lab1.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Directors
{
    class RAMDirector
    {
        private IRAMBuilder _builder;

        public RAMDirector(IRAMBuilder builder)
        {
            _builder = builder;
        }

        public void Make(PerformanceTemplate template)
        {
            _builder.Reset();
            switch (template)
            {
                default:
                case PerformanceTemplate.Low:
                    break;
                case PerformanceTemplate.Office:
                    _builder.SetCapacityGB(4);
                    _builder.SetRamType(RAMType.DDR3);
                    _builder.SetClockFrequencyMGz(2666);
                    break;
                case PerformanceTemplate.Gaming:
                    _builder.SetCapacityGB(8);
                    _builder.SetRamType(RAMType.DDR4);
                    _builder.SetClockFrequencyMGz(3200);
                    break;
            }
        }
    }
}
