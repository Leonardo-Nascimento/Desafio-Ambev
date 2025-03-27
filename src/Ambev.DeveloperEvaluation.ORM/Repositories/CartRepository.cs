using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Requests;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        private readonly DefaultContext _context;

        public CartRepository(DefaultContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Cart>> GetAllItensCartByCustomerId(long id)
        {
            var result = await _context.Cart
                    .Include(x => x.Product)
                    .Include(x => x.Customer)
                    .Where(x => x.CustomerId == id 
                           && x.CloseOrder == false  
                           && x.DeletionDate == null)
                    .ToListAsync();

            return result;
        }

        public async Task<Page<Cart>> GetAllItensCartByCustomerIdPaged(long id, CartFilters filters)
        {
            var result = _context.Cart
                                .Include(x => x.Product)
                                .Include(x => x.Customer)
                                .Where(x => x.CustomerId == id && x.DeletionDate == null);

            var total = await result.CountAsync();


            var data = await result
                .Skip((filters.Page - 1) * filters.PageSize)
                .Take(filters.PageSize)
                .AsNoTracking()
                .ToListAsync();

            return new Page<Cart>(filters.Page, filters.PageSize, data, total);
        }

        public async Task<Cart> GetCartById(long id)
        {
            var cart = await _context.Cart
                                .Include(x => x.Product)
                                .Include(x => x.Customer)
                                .Where(x => x.Id == id && x.DeletionDate == null)
                                .FirstOrDefaultAsync();
            return cart;
        }
    }
}
