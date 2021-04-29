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
    class PowerSupplyBuilder : IPowerSupplyBuilder
    {
        private const Certificate80PLUS _defaultCertificate = Certificate80PLUS.White;
        private const int _defaultPowerW = 350;
        
        private Certificate80PLUS _certificate = _defaultCertificate;
        private int _powerW = _defaultPowerW;

        public PowerSupply Result => new PowerSupply(_powerW, _certificate);

        public void SetCertificate80PLUS(Certificate80PLUS certificate)
        {
            _certificate = certificate;
        }

        public void SetPowerW(int powerW)
        {
            _powerW = powerW;
        }

        public void Reset()
        {
            _certificate = _defaultCertificate;
            _powerW = _defaultPowerW;
        }
    }
}
