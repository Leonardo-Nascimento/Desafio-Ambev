using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Customer.DeleteCustomer
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerResult>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<DeleteCustomerResult> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var product = await _customerRepository.GetById(request.Id);

            if (product == null)
                throw new KeyNotFoundException($"Customer with ID {request.Id} not found");

            product.DeletionDate = DateTime.UtcNow;
            await _customerRepository.Update(product);

            return new DeleteCustomerResult();
        }
    }
}
