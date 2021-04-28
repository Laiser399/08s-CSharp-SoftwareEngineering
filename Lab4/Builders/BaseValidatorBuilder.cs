using Lab4.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Builders
{
    public class BaseValidatorBuilder<T>
    {
        private IValidator<T> _root = null;
        public IValidator<T> Result => _root;

        private IValidator<T> _last = null;

        public void SetNext(IValidator<T> next)
        {
            if (_root is null)
            {
                _root = next;
                _last = next;
            }
            else
            {
                _last.SetNext(next);
                _last = next;
            }
        }

        public void Reset()
        {
            _root = null;
        }
    }
}
