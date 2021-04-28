using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Validators.HumanValidators
{
    public class ExactNameValidator : BaseValidator<Human, string>
    {
        public ExactNameValidator(string exactName) : 
            base(human => human.Name, name =>
            {
                if (!name.Equals(exactName))
                    throw new ValidateException("Wrong name.");
            })
        { }
    }
}
