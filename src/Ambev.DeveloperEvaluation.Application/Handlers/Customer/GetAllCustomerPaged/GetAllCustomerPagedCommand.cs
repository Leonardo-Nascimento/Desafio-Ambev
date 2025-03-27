using Ambev.DeveloperEvaluation.Domain.Requests;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Customer.GetAllCustomerPaged
{
    public class GetAllCustomerPagedCommand : IRequest<GetAllCustomerPagedResult>
    {
        public CustomerFilters Filters { get; set; }

        public GetAllCustomerPagedCommand(CustomerFilters filters)
        {
            Filters = filters;
        }
    }
}
