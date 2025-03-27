using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly DefaultContext _context;

        public ProductRepository(DefaultContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Page<Product>> GetAllProductsPaged(ProductFilters filters)
        {
            var result = _context.Product
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
                return new Page<Product>(filters.Page, filters.PageSize, listOrdered.ToList(), total);

            }

            return new Page<Product>(filters.Page, filters.PageSize, data, total);
        }

        private async Task<IEnumerable<Product>> OrderResult(IQueryable<Product> list, string order, string propertie)
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

            if (propertie == "price")
            {
                if (order == "asc")
                {
                    return list.OrderBy(x => x.Price);
                }
                else
                {
                    return list.OrderByDescending(x => x.Price);
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
