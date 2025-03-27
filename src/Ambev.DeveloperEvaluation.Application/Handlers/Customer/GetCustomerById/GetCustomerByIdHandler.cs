using Ambev.DeveloperEvaluation.Domain.Models;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Customer.GetCustomerById
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdCommand, GetCustomerByIdResult>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<GetCustomerByIdResult> Handle(GetCustomerByIdCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetById(request.Id);

            if (customer == null)
                throw new KeyNotFoundException($"Customer with ID {request.Id} not found");

            var model = _mapper.Map<CustomerModel>(customer);

            return new GetCustomerByIdResult(model);
        }
    }
}
