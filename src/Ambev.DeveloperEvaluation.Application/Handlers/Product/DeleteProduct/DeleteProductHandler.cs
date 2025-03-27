using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Product.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResult>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            var product = await _productRepository.GetById(request.Id);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {request.Id} not found");

            product.DeletionDate = DateTime.UtcNow;
            await _productRepository.Update(product);

            return new DeleteProductResult();
        }
    }
}
