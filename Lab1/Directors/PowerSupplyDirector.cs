using Lab1.Abstractions.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Abstractions.Components;

namespace Lab1.Directors
{
    class PowerSupplyDirector
    {
        private IPowerSupplyBuilder _builder;

        public PowerSupplyDirector(IPowerSupplyBuilder builder)
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
                    _builder.SetPowerW(500);
                    _builder.SetCertificate80PLUS(Certificate80PLUS.Gold);
                    break;
                case PerformanceTemplate.Gaming:
                    _builder.SetPowerW(800);
                    _builder.SetCertificate80PLUS(Certificate80PLUS.Titanium);
                    break;
            }
        }
    }
}
