using Ambev.DeveloperEvaluation.Application.ViewModel;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.GetAllStoreBranchsPaged
{
    public class GetAllStoreBranchsPagedHandler : IRequestHandler<GetAllStoreBranchsPagedCommand, ResultModel>
    {
        private readonly IStoreBranchRepository _storeBranchRepository;

        public GetAllStoreBranchsPagedHandler(IStoreBranchRepository storeBranchRepository)
        {
            _storeBranchRepository = storeBranchRepository;
        }

        public async Task<ResultModel> Handle(GetAllStoreBranchsPagedCommand request, CancellationToken cancellationToken)
        {
            var output = new ResultModel();

            var response = await _storeBranchRepository.GetAllStoreBranchsPaged(request.Filters);

            if (!response.Data.Any())
                return output.ReturnErro("Não foi encontrado distritos cadastrados");


            return output.Result(response);

        }
    }
}
