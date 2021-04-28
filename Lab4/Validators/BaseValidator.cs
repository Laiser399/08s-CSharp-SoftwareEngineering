using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Validators
{
    public class BaseValidator<T, A> : IValidator<T>
    {
        private Func<T, A> _fieldDelegate;
        private Action<A> _validateField;
        private IValidator<T> _next = null;

        public BaseValidator(Func<T, A> valueDelegate, Action<A> validateValue)
        {
            _fieldDelegate = valueDelegate;
            _validateField = validateValue;
        }

        public void SetNext(IValidator<T> next)
        {
            _next = next;
        }

        public void Validate(T value)
        {
            _validateField(_fieldDelegate(value));
            _next?.Validate(value);
        }
    }
}
