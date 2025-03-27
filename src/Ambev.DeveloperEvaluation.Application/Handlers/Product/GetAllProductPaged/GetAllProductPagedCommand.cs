using Ambev.DeveloperEvaluation.Domain.Requests;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Product.GetAllProductPaged
{
    public class GetAllProductPagedCommand : IRequest<GetAllProductPagedResult>
    {
        public ProductFilters Filters { get; set; }

        public GetAllProductPagedCommand(ProductFilters filters)
        {
            Filters = filters;
        }
    }
}
