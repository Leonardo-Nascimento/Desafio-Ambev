using Ambev.DeveloperEvaluation.Application.ViewModel;
using Ambev.DeveloperEvaluation.Domain.Requests;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Order.GetAllOrdersByCustomerId
{
    public class GetAllOrdersByCustomerIdCommand : IRequest<ResultModel>
    {
        public long Id { get; set; }
        public OrdertFilters OrdertFilters { get; set; }

        public GetAllOrdersByCustomerIdCommand(long id, OrdertFilters ordertFilters)
        {
            Id = id;
            OrdertFilters = ordertFilters;
        }
    }
}
