using Lab1.Abstractions.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Directors
{
    class CPUDirector
    {
        public ICPUBuilder _builder;

        public CPUDirector(ICPUBuilder builder)
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
                    _builder.SetCoresCount(4);
                    _builder.SetClockFrequencyGGz(3.1m);
                    _builder.SetTechnicalProcess(Abstractions.Components.TechnicalProcess._14nm);
                    break;
                case PerformanceTemplate.Gaming:
                    _builder.SetCoresCount(8);
                    _builder.SetClockFrequencyGGz(3.5m);
                    _builder.SetTechnicalProcess(Abstractions.Components.TechnicalProcess._7nm);
                    break;
            }
        }
    }
}
