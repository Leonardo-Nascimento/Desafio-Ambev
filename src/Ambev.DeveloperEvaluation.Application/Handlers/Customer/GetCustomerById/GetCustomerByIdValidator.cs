using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Customer.GetCustomerById
{
    public class GetCustomerByIdValidator : AbstractValidator<GetCustomerByIdCommand>
    {
        public GetCustomerByIdValidator()
        {
            RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Customer ID tem que ser maior que zero.");
        }
    }
}
