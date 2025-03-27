using Ambev.DeveloperEvaluation.Application.ViewModel;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Cart.CloseOrder
{
    public class CloseOrderHandler : IRequestHandler<CloseOrderCommand, ResultModel>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;

        public CloseOrderHandler(ICartRepository cartRepository, IOrderRepository orderRepository)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
        }

        public async Task<ResultModel> Handle(CloseOrderCommand request, CancellationToken cancellationToken)
        {
            var output = new ResultModel();

            var cartList = await _cartRepository.GetAllItensCartByCustomerId(request.CustomerId);

            decimal totalValue = 0;
            decimal totalDiscount = 0;

            foreach (var item in cartList)
            {
                item.CloseOrder = true;
                await _cartRepository.Update(item);

                totalValue = totalValue + item.TotalValue;
                totalDiscount = totalDiscount + item.Discount;
            }

            var order = new Domain.Entities.Order(request.CustomerId, 
                                  request.StoreBranchId, 
                                  Domain.Enums.StatusSales.NotCancelled, 
                                  totalValue, totalDiscount
                                  );

            order.SalesCode = Guid.NewGuid().ToString().Substring(0,7);

            await _orderRepository.Add(order);

            return output.Ok("Pedido Fechado");
        }
    }
}
