using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Requests;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<Page<Customer>> GetAllCustomersPaged(CustomerFilters filters);
    }
}
