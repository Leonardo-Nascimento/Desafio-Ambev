using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Requests;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Page<Product>> GetAllProductsPaged(ProductFilters filters);
    }
}
