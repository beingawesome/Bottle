using System;
using System.Collections.Generic;
using System.Linq;
using Bottle;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Microsoft.AspNetCore.Mvc
{
    public static class ModelStateDictionaryExtensions
    {
        public static ModelStateDictionary Merge(this ModelStateDictionary modelState, ErrorContainer container)
        {
            foreach (var group in container.Errors)
            {
                foreach (var error in group)
                {
                    modelState.AddModelError(group.Key, error.Message);
                }
            }

            return modelState;
        }
    }
}
