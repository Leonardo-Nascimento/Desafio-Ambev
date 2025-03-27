using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Models;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Customer.GetAllCustomerPaged
{
    public class GetAllCustomerPagedResult
    {
        public GetAllCustomerPagedResult(Page<Domain.Entities.Customer> result)
        {
            Result = result;
        }

        public Page<Domain.Entities.Customer> Result { get; set; }
    }
}
