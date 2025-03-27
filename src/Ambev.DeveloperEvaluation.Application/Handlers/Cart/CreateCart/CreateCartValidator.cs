using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Cart.CreateCart
{
    public class CreateCartValidator : AbstractValidator<CreateCartCommand>
    {
        public CreateCartValidator()
        {
            RuleFor(x => x.ProductId).NotNull().GreaterThan(0).WithMessage("O campo ProductId não pode ser vazio ou zero!");
            RuleFor(x => x.CustomerId).NotNull().GreaterThan(0).WithMessage("O campo CustomerId não pode ser vazio ou zero!");
            RuleFor(x => x.Quantity).NotNull().GreaterThan(0).WithMessage("O campo Quantity não pode ser vazio nem zero!");

        }
    }
}
