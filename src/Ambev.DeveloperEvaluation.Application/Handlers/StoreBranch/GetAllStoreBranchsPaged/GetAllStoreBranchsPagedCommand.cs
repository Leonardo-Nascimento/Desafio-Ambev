using Ambev.DeveloperEvaluation.Application.ViewModel;
using Ambev.DeveloperEvaluation.Domain.Requests;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.GetAllStoreBranchsPaged
{
    public class GetAllStoreBranchsPagedCommand : IRequest<ResultModel>
    {
        public StoreBranchsFilters Filters { get; set; }

        public GetAllStoreBranchsPagedCommand(StoreBranchsFilters filters)
        {
            Filters = filters;
        }
    }
}
