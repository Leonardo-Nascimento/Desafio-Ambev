namespace Ambev.DeveloperEvaluation.Domain.Requests
{
    public class CustomerFilters : BaseRequest
    {
        public string? CPF { get; set; }
        public string? Name { get; set; }
        public string? Order { get; set; }

    }
}
