namespace Ambev.DeveloperEvaluation.Application.Handlers.Customer.CreateCustomer
{
    public class CreateCustomerResult
    {
        public long Id { get; set; }

        public CreateCustomerResult(long id)
        {
            Id = id;
        }
    }
}
