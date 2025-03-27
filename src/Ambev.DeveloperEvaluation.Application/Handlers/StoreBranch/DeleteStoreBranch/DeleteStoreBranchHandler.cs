using Ambev.DeveloperEvaluation.Application.Handlers.Customer.DeleteCustomer;
using Ambev.DeveloperEvaluation.Application.ViewModel;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.DeleteStoreBranch
{
    public class DeleteStoreBranchHandler : IRequestHandler<DeleteStoreBranchCommand, ResultModel>
    {
        private readonly IStoreBranchRepository _storeBranchRepository;

        public DeleteStoreBranchHandler(IStoreBranchRepository storeBranchRepository)
        {
            _storeBranchRepository = storeBranchRepository;
        }

        public async Task<ResultModel> Handle(DeleteStoreBranchCommand request, CancellationToken cancellationToken)
        {
            var output = new ResultModel();
            if (request.Id == 0)
                return output.ReturnErro($"Id não pode ser zero!");

            var storeBranch = await _storeBranchRepository.GetById(request.Id);

            if (storeBranch == null)
                return output.ReturnErro($"Customer with ID {request.Id} not found");

            storeBranch.DeletionDate = DateTime.UtcNow;
            await _storeBranchRepository.Update(storeBranch);


            return output.Ok("StoreBranch deleted successfully");
        }
    }
}
