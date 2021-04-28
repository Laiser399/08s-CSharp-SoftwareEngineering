using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Validators
{
    public class ValidateException : Exception
    {
        public ValidateException() : base() { }

        public ValidateException(string message) : base(message) { }
    }
}
