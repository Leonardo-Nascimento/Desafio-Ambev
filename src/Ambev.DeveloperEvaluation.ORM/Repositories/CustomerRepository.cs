using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Requests;
using Ambev.DeveloperEvaluation.ORM.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly DefaultContext _context;

        public CustomerRepository(DefaultContext context):base(context)
        {
            _context = context;
        }

        public async Task<Page<Customer>> GetAllCustomersPaged(CustomerFilters filters)
        {
            var result = _context.Customer
                                .WhereIf(!string.IsNullOrWhiteSpace(filters.Name), x => EF.Functions.Like(x.Name, $"%{filters.Name}%"))
                                .WhereIf(!string.IsNullOrWhiteSpace(filters.CPF), x => x.CPF == filters.CPF)
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
                return new Page<Customer>(filters.Page, filters.PageSize, listOrdered.ToList(), total);

            }

            return new Page<Customer>(filters.Page, filters.PageSize, data, total);
        }

        private async Task<IEnumerable<Customer>> OrderResult(IQueryable<Customer> list, string order, string propertie)
        {
            if (propertie == "name")
            {
                if (order == "asc")
                {
                    return list.OrderBy(x => x.Name);
                }
                else
                {
                    return list.OrderByDescending(x => x.Name);
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
