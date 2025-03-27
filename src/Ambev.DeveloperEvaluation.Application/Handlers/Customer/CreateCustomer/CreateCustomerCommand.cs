using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Customer.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CreateCustomerResult>
    {
        public string CPF { get; set; }
        public string Name { get; set; }

    }
}
