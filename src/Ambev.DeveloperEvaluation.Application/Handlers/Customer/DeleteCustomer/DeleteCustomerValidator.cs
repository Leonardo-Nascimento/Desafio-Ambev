using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Customer.DeleteCustomer
{
    public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerValidator()
        {
            RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Customer ID não pode ser zero.");
        }
    }
}
