using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Customer.GetAllCustomerPaged
{
    public class GetAllCustomerPagedHandler : IRequestHandler<GetAllCustomerPagedCommand, GetAllCustomerPagedResult>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomerPagedHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<GetAllCustomerPagedResult> Handle(GetAllCustomerPagedCommand request, CancellationToken cancellationToken)
        {
            var result = await _customerRepository.GetAllCustomersPaged(request.Filters);

            if (!result.Data.Any())
            {
                throw new InvalidOperationException($"Nenhum cliente foi encontrado!");
            }


            return new GetAllCustomerPagedResult(result);
        }
    }
}
