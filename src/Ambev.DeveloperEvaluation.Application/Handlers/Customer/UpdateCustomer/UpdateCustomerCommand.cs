using Ambev.DeveloperEvaluation.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Customer.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<ApiResponse>
    {
        public long Id { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
    }
}
