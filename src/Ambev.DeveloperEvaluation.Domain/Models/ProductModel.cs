using Ambev.DeveloperEvaluation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Models
{
    public class ProductModel
    {
        public ProductModel(long id, string name, decimal price, ProductCategory productCategory, DateTime creationDate, DateTime? updateDate, DateTime? deletionDate)
        {
            Id = id;
            Name = name;
            Price = price;
            ProductCategory = productCategory;
            CreationDate = creationDate;
            UpdateDate = updateDate;
            DeletionDate = deletionDate;
        }

        public ProductModel()
        {
            
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
