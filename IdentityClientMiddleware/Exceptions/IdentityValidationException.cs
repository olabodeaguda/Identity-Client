using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityClientMiddleware.Exceptions
{
    public class IdentityValidationException : Exception
    {
        public IdentityValidationException(string message) : base(message)
        {
        }
    }
}
