using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Product.GetAllProductPaged
{
    public class GetAllProductPagedHandler : IRequestHandler<GetAllProductPagedCommand, GetAllProductPagedResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductPagedHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetAllProductPagedResult> Handle(GetAllProductPagedCommand request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetAllProductsPaged(request.Filters);

            if (!result.Data.Any())
            {
                throw new InvalidOperationException($"Nenhum produto foi encontrado!");
            }

            return new GetAllProductPagedResult(result);
        }
    }
}
