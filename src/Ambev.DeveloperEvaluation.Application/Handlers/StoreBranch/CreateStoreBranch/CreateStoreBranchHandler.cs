using Ambev.DeveloperEvaluation.Application.ViewModel;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.CreateStoreBranch
{
    public class CreateStoreBranchHandler : IRequestHandler<CreateStoreBranchCommand, ApiResponse>
    {
        private readonly IStoreBranchRepository _storeBranchRepository;
        private readonly IMapper _mapper;

        public CreateStoreBranchHandler(IStoreBranchRepository storeBranchRepository, IMapper mapper)
        {
            _storeBranchRepository = storeBranchRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(CreateStoreBranchCommand request, CancellationToken cancellationToken)
        {
            var output = new ResultModel();

            try
            {
                var storeBranch = _mapper.Map<Domain.Entities.StoreBranch>(request);

                var result = await _storeBranchRepository.Add(storeBranch);

                var response = new CreateStoreBranchResult(result.Id);

                return output.Result(response, "StoreBranch created successfully");
                    
            }
            catch (Exception ex)
            {
                return output.ReturnErro("Erro ao tentar cadastrar uma nova Filial: " + ex.Message);
            }
        }
    }
}
