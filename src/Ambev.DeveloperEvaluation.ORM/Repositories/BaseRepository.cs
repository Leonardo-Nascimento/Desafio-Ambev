using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DefaultContext _context;

        public BaseRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T Objeto)
        {
            try
            {
                _context.Add(Objeto);
                _context.SaveChanges();
                return Objeto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> Delete(T Objeto)
        {
            try
            {
                _context.Remove(Objeto);
                _context.SaveChanges();
                return Objeto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Page<T>> GetAll(int page = 1, int pageSize = 25)
        {
            var total = await _context.Set<T>()
                .CountAsync();

            var data = await _context.Set<T>()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            return new Page<T>(page, pageSize, data, total);
        }

        public async Task<T> GetById(long Id)
        {
            var result = await _context.FindAsync<T>(Id);

            if (result != null && result.DeletionDate == null)
                return result;

            return null;
        }

        public async Task<T> Update(T Objeto)
        {
            _context.Update(Objeto);
            _context.SaveChanges();
            return Objeto;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>()
                                 .Where(x => x.DeletionDate == null)
                                 .ToListAsync();
        }

        public async Task<bool> Exists(long id)
        {
            return await _context.Set<T>()
                        .Where(x => x.Id == id && x.DeletionDate == null)
                        .AnyAsync();
        }



    }
}

