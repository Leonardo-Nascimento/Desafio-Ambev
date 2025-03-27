namespace Ambev.DeveloperEvaluation.Domain.Requests
{
    public class StoreBranchsFilters : BaseRequest
    {
        public string? NameBranch { get; set; }

        public string? Order { get; set; }

    }
}
