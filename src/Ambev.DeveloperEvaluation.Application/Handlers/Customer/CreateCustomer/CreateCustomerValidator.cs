using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Customer.CreateCustomer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Name não pode ser vazio.");

            RuleFor(x => x.CPF)
            .NotEmpty()
            .NotNull()
            .Length(11)
            .WithMessage("Cpf não pode ser vazio e deve ter 11 digitos.");
        }
    }
}
