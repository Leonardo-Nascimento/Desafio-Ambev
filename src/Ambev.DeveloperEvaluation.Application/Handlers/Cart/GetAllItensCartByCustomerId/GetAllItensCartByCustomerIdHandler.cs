using Ambev.DeveloperEvaluation.Application.ViewModel;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Cart.GetAllItensCartByCustomerId
{
    public class GetAllItensCartByCustomerIdHandler : IRequestHandler<GetAllItensCartByCustomerIdCommand, ResultModel>
    {
        private readonly ICartRepository _cartRepository;

        public GetAllItensCartByCustomerIdHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<ResultModel> Handle(GetAllItensCartByCustomerIdCommand request, CancellationToken cancellationToken)
        {
            var output = new ResultModel();

            var response = await _cartRepository.GetAllItensCartByCustomerIdPaged(request.Id, request.Filters);

            if (!response.Data.Any())
                return output.ReturnErro("Não foi encontrado distritos cadastrados");


            return output.Result(response);
        }
    }
}
