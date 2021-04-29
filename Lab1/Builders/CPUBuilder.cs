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
    class CPUBuilder : ICPUBuilder
    {
        private const decimal _defaultFrequencyGGz = 2.1m;
        private const int _defaultCoresCount = 2;
        private const TechnicalProcess _defaultTechnicalProcess = TechnicalProcess._22nm;

        private decimal _frequencyGGz;
        private int _coresCount;
        private TechnicalProcess _technicalProcess;

        public CPU Result => new CPU(_coresCount, _frequencyGGz, _technicalProcess);

        public CPUBuilder()
        {
            Reset();
        }

        public void SetClockFrequencyGGz(decimal frequencyGGz)
        {
            _frequencyGGz = frequencyGGz;
        }

        public void SetCoresCount(int coresCount)
        {
            _coresCount = coresCount;
        }

        public void SetTechnicalProcess(TechnicalProcess technicalProcess)
        {
            _technicalProcess = technicalProcess;
        }

        public void Reset()
        {
            _frequencyGGz = _defaultFrequencyGGz;
            _coresCount = _defaultCoresCount;
            _technicalProcess = _defaultTechnicalProcess;
        }
    }
}
