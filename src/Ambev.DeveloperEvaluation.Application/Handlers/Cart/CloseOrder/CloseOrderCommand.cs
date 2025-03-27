using Ambev.DeveloperEvaluation.Application.ViewModel;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Cart.CloseOrder
{
    public class CloseOrderCommand : IRequest<ResultModel>
    {
        public long CustomerId { get; set; }
        public long StoreBranchId { get; set; }

        public CloseOrderCommand(long customerId, long storeBranchId)
        {
            CustomerId = customerId;
            StoreBranchId = storeBranchId;
        }
    }
}
