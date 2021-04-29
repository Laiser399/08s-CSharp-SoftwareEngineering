using Lab1.Abstractions.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Directors
{
    class HDDDirector
    {
        private IHDDBuilder _builder;

        public HDDDirector(IHDDBuilder builder)
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
                    _builder.SetCapacityGB(1024);
                    _builder.SetRotationFrequency(Abstractions.Components.RotationFrequency._7200);
                    _builder.SetClipboardVolume(Abstractions.Components.ClipboardVolume._64mb);
                    break;
                case PerformanceTemplate.Gaming:
                    _builder.SetCapacityGB(2048);
                    _builder.SetRotationFrequency(Abstractions.Components.RotationFrequency._10000);
                    _builder.SetClipboardVolume(Abstractions.Components.ClipboardVolume._128mb);
                    break;
            }
        }
    }
}
