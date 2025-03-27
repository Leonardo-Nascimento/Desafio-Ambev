using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Customer.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResult>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CreateCustomerResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = new Domain.Entities.Customer(request.Name, request.CPF);

                var result = await _customerRepository.Add(product);

                return new CreateCustomerResult(result.Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar cadastrar um novo produto: " + ex.Message);
            }

        }
    }
}
