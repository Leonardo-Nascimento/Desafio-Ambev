using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Requests;
using Ambev.DeveloperEvaluation.ORM.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class StoreBranchRepository : BaseRepository<StoreBranch>, IStoreBranchRepository
    {
        private readonly DefaultContext _context;

        public StoreBranchRepository(DefaultContext context):base(context)
        {
            _context = context;
        }

        public async Task<Page<StoreBranch>> GetAllStoreBranchsPaged(StoreBranchsFilters filters)
        {
            var result = _context.StoreBranche
                    .WhereIf(!string.IsNullOrWhiteSpace(filters.NameBranch), x => EF.Functions.Like(x.NameBranch, $"%{filters.NameBranch}%"))
                    .Where(x => x.DeletionDate == null);

            var total = await result.CountAsync();


            var data = await result
                .Skip((filters.Page - 1) * filters.PageSize)
                .Take(filters.PageSize)
                .AsNoTracking()
                .ToListAsync();


            if (!string.IsNullOrEmpty(filters.Order))
            {
                var order = GetOder(filters.Order);
                var propertie = GetPropertie(filters.Order);
                var listOrdered = await OrderResult(result, order, propertie);
                return new Page<StoreBranch>(filters.Page, filters.PageSize, listOrdered.ToList(), total);

            }

            return new Page<StoreBranch>(filters.Page, filters.PageSize, data, total);
        }

        private async Task<IEnumerable<StoreBranch>> OrderResult(IQueryable<StoreBranch> list, string order, string propertie)
        {
            if (propertie == "namebranch")
            {
                if (order == "asc")
                {
                    return list.OrderBy(x => x.NameBranch);
                }
                else
                {
                    return list.OrderByDescending(x => x.NameBranch);
                }
            }
            return list;
        }

        private string GetOder(string orderPropertie)
        {
            var order = orderPropertie.Split(" ")[1].ToLower();
            return order;
        }

        private string GetPropertie(string orderPropertie)
        {
            var order = orderPropertie.Split(" ")[0].ToLower();
            return order;
        }
    }
}
