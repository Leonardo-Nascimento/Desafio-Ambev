using Ambev.DeveloperEvaluation.Application.ViewModel;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.UpdateStoreBranch
{
    public class UpdateStoreBranchHandler : IRequestHandler<UpdateStoreBranchCommand, ResultModel>
    {
        private readonly IStoreBranchRepository _storeBranchRepository;

        public UpdateStoreBranchHandler(IStoreBranchRepository storeBranchRepository)
        {
            _storeBranchRepository = storeBranchRepository;
        }

        public async Task<ResultModel> Handle(UpdateStoreBranchCommand request, CancellationToken cancellationToken)
        {
            var output = new ResultModel();

            try
            {
                var storeBranch = await _storeBranchRepository.GetById(request.Id);

                if (storeBranch == null)
                    return output.ReturnErro("Filial não encontrada:" + request.Id);

                storeBranch.NameBranch = request.NameBranch;
                storeBranch.Number = request.Number;
                storeBranch.CEP = request.CEP;
                storeBranch.State = request.State;
                storeBranch.City = request.City;
                storeBranch.UpdateDate = DateTime.Now;

                await _storeBranchRepository.Update(storeBranch);

                return output.Ok("Filial atualizada com sucesso");
            }
            catch (Exception ex)
            {
                return output.ReturnErro("Erro ao tentar atualizar Filial: " + ex.Message);
            }
        }
    }
}
