using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Seed
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(

                   new Product(1,"Feijão Camil", 12.0m, Domain.Enums.ProductCategory.Meats),
                   new Product(2,"Farinha Amarela", 10.0m, Domain.Enums.ProductCategory.Grains),
                   new Product(3,"Melância", 8.50m, Domain.Enums.ProductCategory.Fruits),
                   new Product(4,"Coca-Cola", 10.90m, Domain.Enums.ProductCategory.Drinks),
                   new Product(5,"Chocolate-Garoto", 7.20m, Domain.Enums.ProductCategory.Sweets),
                   new Product(6,"Requeijão", 6.0m, Domain.Enums.ProductCategory.ColdCuts)

            );
        }
    }
}
