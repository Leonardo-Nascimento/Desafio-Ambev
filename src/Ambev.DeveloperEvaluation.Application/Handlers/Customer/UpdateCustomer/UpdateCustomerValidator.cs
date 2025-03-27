using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Customer.UpdateCustomer
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("ID tem que ser maior que zero.");

            RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Name não pode ser vazio.");

            RuleFor(x => x.CPF)
            .NotEmpty()
            .NotNull()
            .Length(111)
            .WithMessage("Cpf não pode ser vazio e deve ter 11 digitos.");
        }
    }
}
