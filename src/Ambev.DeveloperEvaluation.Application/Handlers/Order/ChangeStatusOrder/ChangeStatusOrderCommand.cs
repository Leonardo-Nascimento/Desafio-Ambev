using Ambev.DeveloperEvaluation.Application.ViewModel;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Order.ChangeStatusOrder
{
    public class ChangeStatusOrderCommand : IRequest<ResultModel>
    {
        public long Id { get; set; }
        public StatusSales StatusSales { get; set; }



        public ChangeStatusOrderCommand(long id, StatusSales statusSales)
        {
            Id = id;
            StatusSales = statusSales;
        }
    }
}
