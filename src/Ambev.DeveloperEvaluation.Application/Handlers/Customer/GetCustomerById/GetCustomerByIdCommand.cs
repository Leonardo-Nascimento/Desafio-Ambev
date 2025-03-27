using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Customer.GetCustomerById
{
    public class GetCustomerByIdCommand : IRequest<GetCustomerByIdResult>
    {
        public long Id { get; set; }

        public GetCustomerByIdCommand(long id)
        {
            Id = id;
        }
    }
}
