using Ambev.DeveloperEvaluation.Application.Handlers.Customer.GetCustomerById;
using Ambev.DeveloperEvaluation.Application.ViewModel;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Models;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.GetStoreBranchById
{
    public class GetStoreBranchByIdHandler : IRequestHandler<GetStoreBranchByIdCommand, ResultModel>
    {
        private readonly IMapper _mapper;
        private readonly IStoreBranchRepository _storeBranchRepository;

        public GetStoreBranchByIdHandler(IStoreBranchRepository storeBranchRepository, IMapper mapper)
        {
            _storeBranchRepository = storeBranchRepository;
            _mapper = mapper;
        }

        public async Task<ResultModel> Handle(GetStoreBranchByIdCommand request, CancellationToken cancellationToken)
        {
            var output = new ResultModel();

            if (request.Id == 0)
                return output.ReturnErro($"Id deve ser maior que zero!");

            var storeBranch = await _storeBranchRepository.GetById(request.Id);

            if (storeBranch == null)
                return output.ReturnErro($"Customer with ID {request.Id} not found");

            var model = _mapper.Map<StoreBranchModel>(storeBranch);
            var result = new GetStoreBranchByIdResult(model);

            return output;
        }
    }
}
