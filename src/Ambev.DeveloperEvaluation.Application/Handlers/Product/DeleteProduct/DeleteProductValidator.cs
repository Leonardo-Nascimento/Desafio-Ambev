using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Product.DeleteProduct
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Produto ID não pode ser zero.");
        }
    }
}
