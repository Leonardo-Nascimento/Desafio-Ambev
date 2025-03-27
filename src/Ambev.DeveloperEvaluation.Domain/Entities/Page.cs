namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Page<T> where T : class
    {
        public int Total { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public IList<T> Data { get; }

        public Page(int currentPage, int pageSize, List<T> data, int total)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            Data = data;
            Total = total;
        }
    }
}
