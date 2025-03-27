using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Response;
using FluentValidation.Results;

namespace Ambev.DeveloperEvaluation.Application.ViewModel
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public IEnumerable<ValidationErrorDetail> Errors { get; set; } = [];


    }
}