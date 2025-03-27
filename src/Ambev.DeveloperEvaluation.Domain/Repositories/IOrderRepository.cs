using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Requests;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Page<Order>> GetAllOrdersByCustomerId(long id, OrdertFilters filters);
        Task<Order> GetOrdersByCustomerId(long id);
    }
}
