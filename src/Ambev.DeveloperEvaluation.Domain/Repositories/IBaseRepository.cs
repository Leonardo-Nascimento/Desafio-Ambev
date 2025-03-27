namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Add(T Objeto);
        Task<T> Update(T Objeto);
        Task<T> Delete(T Objeto);
        Task<T> GetById(long Id);
        //Task<Page<T>> GetAll(int page = 1, int pageSize = 25);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Exists(long id);
    }
}
