using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Product.GetAllProductPaged
{
    public class GetAllProductPagedResult
    {
        public Page<Domain.Entities.Product> Page { get; set; }

        public GetAllProductPagedResult(Page<Domain.Entities.Product> page)
        {
            Page = page;
        }
    }
}
