using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Validators.HumanValidators
{
    public class MinAgeValidator : BaseValidator<Human, uint>
    {
        public MinAgeValidator(uint minAge) : 
            base(human => human.Age, age =>
            {
                if (age < minAge)
                    throw new ValidateException($"Received age is lower than required.");
            })
        { }
    }
}
