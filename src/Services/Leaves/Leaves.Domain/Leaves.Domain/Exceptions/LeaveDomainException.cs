using System;
using System.Collections.Generic;
using System.Text;

namespace Leaves.Domain.Exceptions
{
    public class LeaveDomainException : Exception
    {
        public LeaveDomainException()
        { }

        public LeaveDomainException(string message)
            : base(message)
        { }

        public LeaveDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
