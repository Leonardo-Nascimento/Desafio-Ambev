using Ambev.DeveloperEvaluation.Application.Handlers.Product.CreateProduct;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("O nome do produto não pode ser vazio");
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("O preço não pode ser zero");
            RuleFor(p => p.ProductCategory).NotNull().WithMessage("O tipo de produto não pode ser vazio");

        }
    }
}
