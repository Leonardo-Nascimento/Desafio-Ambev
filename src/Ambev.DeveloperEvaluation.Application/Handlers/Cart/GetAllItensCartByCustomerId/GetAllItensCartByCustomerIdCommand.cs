using Ambev.DeveloperEvaluation.Application.ViewModel;
using Ambev.DeveloperEvaluation.Domain.Requests;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Cart.GetAllItensCartByCustomerId
{
    public class GetAllItensCartByCustomerIdCommand : IRequest<ResultModel>
    {
        public long Id { get; set; }
        public CartFilters Filters { get; set; }

        public GetAllItensCartByCustomerIdCommand(long id, CartFilters filters)
        {
            Id = id;
            Filters = filters;
        }
    }
}
