using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product(string name, decimal price, ProductCategory productCategory)
        {
            Name = name;
            Price = price;
            ProductCategory = productCategory;
        }

        public Product(long id, string name, decimal price, ProductCategory productCategory)
        {
            SetId(id);
            Name = name;
            Price = price;
            ProductCategory = productCategory;
            CreationDate = DateTime.Now.Date;
        }

        public Product()
        {
            
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategory ProductCategory { get; set; }
        
    }
}
