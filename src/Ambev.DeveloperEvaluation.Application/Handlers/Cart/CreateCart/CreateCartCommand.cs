using Ambev.DeveloperEvaluation.Application.ViewModel;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Cart.CreateCart
{
    public class CreateCartCommand : IRequest<ResultModel>
    {
        public CreateCartCommand()
        {
            
        }
        public long ProductId { get; set; }
        public long CustomerId { get; set; }
        public long StoreBranchId { get; set; }        
        public int Quantity { get; set; }
        public bool CloseOrder { get; set; }
    }
}
