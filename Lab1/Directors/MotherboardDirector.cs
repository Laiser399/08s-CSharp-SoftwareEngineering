using Lab1.Abstractions.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Abstractions.Components;

namespace Lab1.Directors
{
    class MotherboardDirector
    {
        private IMotherboardBuilder _builder;

        public MotherboardDirector(IMotherboardBuilder builder)
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
                    _builder.SetRAMCount(RAMCount._4);
                    _builder.BuildWiFi();
                    _builder.BuildBluetooth();
                    break;
                case PerformanceTemplate.Gaming:
                    _builder.SetRAMCount(RAMCount._6);
                    _builder.BuildSSDM2Slot();
                    _builder.BuildWiFi();
                    _builder.BuildBluetooth();
                    break;
            }
        }
    }
}
