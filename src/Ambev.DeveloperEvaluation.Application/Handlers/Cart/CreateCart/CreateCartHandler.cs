using Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.CreateStoreBranch;
using Ambev.DeveloperEvaluation.Application.ViewModel;
using Ambev.DeveloperEvaluation.Domain.Models;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Cart.CreateCart
{
    public class CreateCartHandler : IRequestHandler<CreateCartCommand, ResultModel>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateCartHandler(ICartRepository cartRepository, IMapper mapper, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task<ResultModel> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var output = new ResultModel();

            try
            {
                var cart = _mapper.Map<Domain.Entities.Cart>(request);

                var valueProduct = _productRepository.GetById(request.ProductId).Result.Price;
                cart.TotalValue = valueProduct * request.Quantity;

                cart.CalculateDiscount(cart, cart.Quantity, cart.TotalValue);

                var result = await _cartRepository.Add(cart);

                var response = new CreateStoreBranchResult(result.Id);

                if (cart.CloseOrder)
                {
                    var order = new Domain.Entities.Order(request.CustomerId,
                                  request.StoreBranchId,
                                  Domain.Enums.StatusSales.NotCancelled,
                                  cart.TotalValue, cart.Discount
                                  );

                    order.SalesCode = Guid.NewGuid().ToString().Substring(0, 7);

                    await _orderRepository.Add(order);

                    var model = _mapper.Map<OrderModel>(order);
                    
                    return output.Result(model, "Order created successfully");

                }

                return output.Result(response, "Cart created successfully");

            }
            catch (Exception ex)
            {
                return output.ReturnErro("Erro ao tentar adicionar itens no carrinho: " + ex.Message);
            }
        }
    }
}
