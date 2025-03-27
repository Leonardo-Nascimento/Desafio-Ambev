using Ambev.DeveloperEvaluation.Application.ViewModel;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Order.GetAllOrdersByCustomerId
{
    public class GetAllOrdersByCustomerIdHandler : IRequestHandler<GetAllOrdersByCustomerIdCommand, ResultModel>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersByCustomerIdHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ResultModel> Handle(GetAllOrdersByCustomerIdCommand request, CancellationToken cancellationToken)
        {
            var output = new ResultModel();

            var orders = await _orderRepository.GetAllOrdersByCustomerId(request.Id, request.OrdertFilters);
            if (!orders.Data.Any())
                return output.ReturnErro("Não foi encontrado nenhum pedido desse cliente.");

            return output.Result(orders);

        }
    }
}
