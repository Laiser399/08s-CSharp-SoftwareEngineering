using Lab4.Validators;
using Lab4.Validators.HumanValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Builders
{
    public class HumanValidatorBuilder : BaseValidatorBuilder<Human>
    {
        public void SetMinAge(uint minAge)
        {
            SetNext(new MinAgeValidator(minAge));
        }

        public void SetName(string name)
        {
            SetNext(new ExactNameValidator(name));
        }

        public void SetDriverLicense(DriverLicense driverLicense)
        {
            SetNext(new DriverLicenseValidator(driverLicense));
        }
    }
}
