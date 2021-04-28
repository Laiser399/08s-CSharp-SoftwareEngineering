using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Validators.HumanValidators
{
    public class DriverLicenseValidator : BaseValidator<Human, DriverLicense>
    {
        public DriverLicenseValidator(DriverLicense requiredDriverLicense) :
            base(human => human.DriverLicense, 
                license =>
                {
                    if ((license & requiredDriverLicense) != requiredDriverLicense)
                        throw new ValidateException("This license in not enough.");
                })
        { }
    }
}
