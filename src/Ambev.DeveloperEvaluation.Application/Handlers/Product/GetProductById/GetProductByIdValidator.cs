using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Product.GetProductById
{
    public class GetProductByIdValidator : AbstractValidator<GetProductByIdCommand>
    {
        public GetProductByIdValidator()
        {
            RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Produto ID tem que ser maior que zero.");
        }
    }
}
