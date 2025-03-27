using Ambev.DeveloperEvaluation.Application.ViewModel;

namespace Ambev.DeveloperEvaluation.WebApi.Common;

public class PaginatedResponse : ResultModel
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
}