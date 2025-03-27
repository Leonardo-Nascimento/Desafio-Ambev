namespace Ambev.DeveloperEvaluation.Application.Handlers.Product.CreateProduct
{
    public class CreateProductResult
    {
        public long Id { get; set; }

        public CreateProductResult(long id)
        {
            Id = id;
        }
    }
}
