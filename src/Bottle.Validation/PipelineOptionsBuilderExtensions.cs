using Bottle.Configuration;
using Bottle.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Bottle.Validation
{
    public static class PipelineOptionsBuilderExtensions
    {
        public static PipelineOptionsBuilder UseValidation(this PipelineOptionsBuilder builder)
        {
            builder.Use(() =>
            {
                return Middleware;

                async Task<MessageResult> Middleware(MessageContext context, MessageDelegate next)
                {
                    var validation = new ValidationContext(context.Message, context.Services, null);
                    var errors = new List<ValidationResult>();

                    Validator.TryValidateObject(context.Message, validation, errors, true);

                    if(errors.Count > 0) return new FailedValidationResult(errors);

                    return await next(context).ConfigureAwait(false);
                }
            });


            return builder;
        }
    }
}
