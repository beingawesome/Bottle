using System;
using System.Collections.Generic;
using System.Text;

namespace Bottle
{
    public class Error
    {
        private const string UnexpectedError = "An unexpected error occurred.";

        public Error(string message) : this(message, null) { }

        public Error(Exception exception) : this(UnexpectedError, exception) { }

        public Error(string message, Exception exception)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
            Exception = exception;
        }

        public string Message { get; }
        public Exception Exception { get; }
    }
}
