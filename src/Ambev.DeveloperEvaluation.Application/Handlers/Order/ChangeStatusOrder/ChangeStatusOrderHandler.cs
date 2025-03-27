using Ambev.DeveloperEvaluation.Application.ViewModel;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Order.ChangeStatusOrder
{
    public class ChangeStatusOrderHandler : IRequestHandler<ChangeStatusOrderCommand, ResultModel>
    {
        private readonly IOrderRepository _orderRepository;

        public ChangeStatusOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ResultModel> Handle(ChangeStatusOrderCommand request, CancellationToken cancellationToken)
        {
            var output = new ResultModel();

            var order = await _orderRepository.GetOrdersByCustomerId(request.Id);

            if (order == null)
                output.ReturnErro($"Product with ID {request.Id} not found");

            order.StatusSales = request.StatusSales;

            return output.Ok($"Pedido de cod {order.SalesCode} cancelado com sucesso");
        }
    }
}
