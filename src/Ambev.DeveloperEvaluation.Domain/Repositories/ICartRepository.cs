using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Requests;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        Task<Page<Cart>> GetAllItensCartByCustomerIdPaged(long id, CartFilters filters);
        Task<Cart> GetCartById(long id);

        Task<List<Cart>> GetAllItensCartByCustomerId(long id);


    }
}
