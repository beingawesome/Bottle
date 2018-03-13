using Bottle.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bottle.Validation
{
    internal class FailedValidationResult : MessageResult
    {
        public FailedValidationResult(IEnumerable<ValidationResult> errors) => Errors = errors;

        public IEnumerable<ValidationResult> Errors { get; }

        public override CommandResult AsCommandResult() => Append(new CommandResult());

        public override QueryResult<T> AsQueryResult<T>() => Append(new QueryResult<T>());

        private T Append<T>(T container) where T : ErrorContainer
        {
            foreach (var error in Errors)
            {
                foreach (var member in error.MemberNames)
                {
                    container.Errors.Add(member, new Error(error.ErrorMessage));
                }
            }
            
            return container;
        }
    }
}
