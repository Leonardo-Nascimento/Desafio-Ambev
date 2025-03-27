using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Requests;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly DefaultContext _context;        

        public OrderRepository(DefaultContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Page<Order>> GetAllOrdersByCustomerId(long id, OrdertFilters filters)
        {
            var result = _context.Order
                                .Include(x => x.StoreBranch)
                                .Include(x => x.Customer)
                                .Where(x => x.CustomerId == id 
                                && x.StatusSales == Domain.Enums.StatusSales.NotCancelled
                                && x.DeletionDate == null
                                );

            var total = await result.CountAsync();


            var data = await result
                .Skip((filters.Page - 1) * filters.PageSize)
                .Take(filters.PageSize)
                .AsNoTracking()
                .ToListAsync();

            return new Page<Order>(filters.Page, filters.PageSize, data, total);
        }

        public async Task<Order> GetOrdersByCustomerId(long id)
        {
            var result = await _context.Order
                                .Include(x => x.StoreBranch)
                                .Include(x => x.Customer)
                                .Where(x => x.Id == id 
                                && x.StatusSales == Domain.Enums.StatusSales.NotCancelled
                                && x.DeletionDate == null)
                                .FirstOrDefaultAsync();
            return result;
        }
    }
}
