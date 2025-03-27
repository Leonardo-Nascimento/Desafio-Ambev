using Ambev.DeveloperEvaluation.Application.ViewModel;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Customer.UpdateCustomer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, ApiResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ApiResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var output = new ResultModel();

            try
            {
                var customer = await _customerRepository.GetById(request.Id);

                if (customer == null)
                    return output.Ok("Customer não encontrado:" + request.Id);


                customer.Name = request.Name;
                customer.CPF = request.CPF;

                await _customerRepository.Update(customer);

                return output.Ok("Cliente atualizada com sucesso");
            }
            catch (Exception ex)
            {
                return output.ReturnErro("Erro ao tentar atualizar Cliente: " + ex.Message);
            }
        }
    }
}
