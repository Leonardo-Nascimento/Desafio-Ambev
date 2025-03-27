using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Product.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductResult>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
