using MediatR;
using Microsoft.AspNetCore.Builder;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Product.DeleteProduct
{
    public class DeleteProductCommand : IRequest<DeleteProductResult>
    {
        public long Id { get; set; }

        public DeleteProductCommand(long id)
        {
            Id = id;
        }
    }
}
