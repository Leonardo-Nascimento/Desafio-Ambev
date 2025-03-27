using Ambev.DeveloperEvaluation.Application.Handlers.Customer.CreateCustomer;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Product.CreateProduct
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("O nome do cliente é obrigatório");
            RuleFor(x => x.CPF).Length(11).WithMessage("O CPF do cliente é obrigatório e deve conter 11 dígitos");
        }
    }
}
