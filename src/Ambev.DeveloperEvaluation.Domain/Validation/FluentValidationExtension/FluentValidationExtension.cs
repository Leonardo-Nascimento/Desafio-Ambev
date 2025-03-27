using FluentValidation.Results;

namespace Ambev.DeveloperEvaluation.Domain.Validation.FluentValidationExtension
{
    public static class FluentValidationExtension
    {
        public static IEnumerable<string> AddToModelState(this ValidationResult result)
        {            
            return result.Errors.Select(x => x.ErrorMessage);
        }
    }
}