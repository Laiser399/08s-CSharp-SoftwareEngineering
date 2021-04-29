using Lab1.Abstractions.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Directors
{
    class GPUDirector
    {
        private IGPUBuilder _builder;

        public GPUDirector(IGPUBuilder builder)
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
                    _builder.SetMemoryCapacityGB(2);
                    _builder.SetMemoryType(Abstractions.Components.GPUMemoryType.GDDR5);
                    _builder.SetBitWidth(Abstractions.Components.BitWidth._192bit);
                    break;
                case PerformanceTemplate.Gaming:
                    _builder.SetMemoryCapacityGB(6);
                    _builder.SetMemoryType(Abstractions.Components.GPUMemoryType.GDDR6);
                    _builder.SetBitWidth(Abstractions.Components.BitWidth._256bit);
                    break;
            }
        }
    }
}
