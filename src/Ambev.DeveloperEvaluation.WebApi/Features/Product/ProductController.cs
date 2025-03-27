using Ambev.DeveloperEvaluation.Domain.Requests;
using Ambev.DeveloperEvaluation.WebApi.Common;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Models;
using Ambev.DeveloperEvaluation.Domain.Validation.FluentValidationExtension;
using Ambev.DeveloperEvaluation.Application.Handlers.Product.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Handlers.Product.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Handlers.Product.GetAllProductPaged;
using Ambev.DeveloperEvaluation.Application.Handlers.Product.GetProductById;
using Ambev.DeveloperEvaluation.Application.ViewModel;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IValidator<GetProductByIdCommand> _validatorGetProductById;
        private readonly IValidator<DeleteProductCommand> _validatorDeleteProduct;

        public ProductController(IMediator mediator, IMapper mapper, IValidator<GetProductByIdCommand> validatorGetProductById, IValidator<DeleteProductCommand> validatorDeleteProduct)
        {
            _mediator = mediator;
            _mapper = mapper;
            _validatorGetProductById = validatorGetProductById;
            _validatorDeleteProduct = validatorDeleteProduct;
        }

        [HttpPost("CreateProduct")]
        [ProducesResponseType(typeof(CreateProductResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateProductCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ResultModel
            {
                Success = true,
                Message = "Product created successfully",
                Data = _mapper.Map<CreateProductResult>(response)
            });
        }

        [HttpGet("GetAllProductPaged")]
        [ProducesResponseType(typeof(GetAllProductPagedResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllProductPaged([FromQuery] ProductFilters filters, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllProductPagedCommand(filters), cancellationToken);

            return Created(string.Empty, new ResultModel
            {
                Success = true,                
                Data = response
            });
        }

        [HttpGet("GetProductById/{id}")]
        [ProducesResponseType(typeof(GetProductByIdResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductById([FromRoute] long id, CancellationToken cancellationToken)
        {
            var validationGetProductByIdResult = await _validatorGetProductById.ValidateAsync(new GetProductByIdCommand(id));

            if (!validationGetProductByIdResult.IsValid)
                return BadRequest(FluentValidationExtension.AddToModelState(validationGetProductByIdResult));

            var response = await _mediator.Send(new GetProductByIdCommand(id), cancellationToken);

            var productModel = _mapper.Map<ProductModel>(response.Product);

            return Ok(productModel);
        }

        [HttpDelete("DeleteProduct/{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct([FromRoute] long id, CancellationToken cancellationToken)
        {
            var validationGetProductByIdResult = await _validatorDeleteProduct.ValidateAsync(new DeleteProductCommand(id));

            if (!validationGetProductByIdResult.IsValid)
                return BadRequest(FluentValidationExtension.AddToModelState(validationGetProductByIdResult));

            await _mediator.Send(new DeleteProductCommand(id), cancellationToken);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Product deleted successfully"
            });
        }


    }
}
