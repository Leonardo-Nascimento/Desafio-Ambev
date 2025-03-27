using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Cart : BaseEntity
    {
        [ForeignKey("ProductId")]
        public long ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("CustomerId")]
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int Quantity { get; set; }
        public decimal TotalValue { get; set; }
        public decimal Discount { get; set; }
        public bool CloseOrder { get; set; }
        public StatusItem StatusItem { get; set; }


        public void CalculateDiscount(Cart cart, int quantity, decimal totalValue)
        {
            decimal value = 0;

            if (quantity > 4 && quantity <= 9)
            {
                value = totalValue - (totalValue * 10 / 100);
                cart.Discount = 10;
                cart.TotalValue =  value;
            }
            else if (quantity >= 10 && quantity <= 20)
            {
                value = totalValue - (totalValue * 20 / 100);
                cart.Discount = 20;
                cart.TotalValue = value;
            }

        }



    }
}
