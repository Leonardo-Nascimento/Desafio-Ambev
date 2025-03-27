using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Requests;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IStoreBranchRepository : IBaseRepository<StoreBranch>
    {
        Task<Page<StoreBranch>> GetAllStoreBranchsPaged(StoreBranchsFilters filters);

    }
}
