using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Validators
{
    public interface IValidator<T>
    {
        void SetNext(IValidator<T> next);

        /// <exception cref="ValidateException"></exception>
        void Validate(T value);
    }
}
