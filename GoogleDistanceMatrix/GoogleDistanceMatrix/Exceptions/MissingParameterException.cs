using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDistanceMatrix.Exceptions
{
    public class MissingParameterException : Exception
    {
        public MissingParameterException() : base()
        {

        }
        public MissingParameterException(string message) :  base(message)
        {

        }
        public MissingParameterException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
