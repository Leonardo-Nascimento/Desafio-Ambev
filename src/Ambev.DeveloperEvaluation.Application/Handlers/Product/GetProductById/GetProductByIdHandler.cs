using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Product.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdCommand, GetProductByIdResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetProductByIdResult> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
        {

            var product = await _productRepository.GetById(request.Id);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {request.Id} not found");

            return new GetProductByIdResult(product);

        }
    }
}
