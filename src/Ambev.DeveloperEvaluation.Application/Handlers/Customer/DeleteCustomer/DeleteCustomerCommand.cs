using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Customer.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<DeleteCustomerResult>
    {
        public long Id { get; set; }

        public DeleteCustomerCommand(long id)
        {
            Id = id;
        }
    }
}
