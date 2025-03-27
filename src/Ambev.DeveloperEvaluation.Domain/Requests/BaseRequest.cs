namespace Ambev.DeveloperEvaluation.Domain.Requests
{
    public abstract class BaseRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 25;
    }
}
