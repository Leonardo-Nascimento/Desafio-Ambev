using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Product.GetProductById
{
    public class GetProductByIdCommand : IRequest<GetProductByIdResult>
    {
        public long Id { get; set; }

        public GetProductByIdCommand(long id)
        {
            Id = id;
        }
    }
}
