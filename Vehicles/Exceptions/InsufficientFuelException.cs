using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Exceptions
{
    public class InsufficientFuelException : Exception
    {
        public InsufficientFuelException(string message)
            : base(message)
        {

        }
    }
}
