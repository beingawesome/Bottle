using System;
using System.Collections.Generic;
using System.Text;

namespace Bottle
{
    public abstract class ErrorContainer
    {
        internal ErrorContainer() { }

        public bool IsSuccess => !Errors.HasErrors;

        public ErrorCollection Errors { get; } = new ErrorCollection();
    }
}
