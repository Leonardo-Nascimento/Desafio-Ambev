using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Product.GetProductById
{
    public class GetProductByIdResult
    {
        public Domain.Entities.Product Product { get; set; }

        public GetProductByIdResult(Domain.Entities.Product product)
        {
            Product = product;
        }
    }
}
