using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Product.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var product = new Domain.Entities.Product(request.Name, request.Price, request.ProductCategory);

                var result = await _productRepository.Add(product);

                return new CreateProductResult(result.Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar cadastrar um novo produto: " + ex.Message);
            }
        }



    }
}

