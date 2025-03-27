using Ambev.DeveloperEvaluation.Application.Handlers.Cart.CloseOrder;
using Ambev.DeveloperEvaluation.Application.Handlers.Cart.CreateCart;
using Ambev.DeveloperEvaluation.Application.Handlers.Cart.GetAllItensCartByCustomerId;
using Ambev.DeveloperEvaluation.Application.ViewModel;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Requests;
using Ambev.DeveloperEvaluation.Domain.Validation.FluentValidationExtension;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCartCommand> _createCartValidator;


        public CartController(IMediator mediator, IMapper mapper, IValidator<CreateCartCommand> createCartValidator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _createCartValidator = createCartValidator;
        }

        [HttpPost("AddItensToCart")]
        [ProducesResponseType(typeof(ResultModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResultModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddItensToCart([FromBody] CreateCartCommand request, CancellationToken cancellationToken)
        {
            var validationCreateCartResult = await _createCartValidator.ValidateAsync(request);

            if (!validationCreateCartResult.IsValid)
                return BadRequest(FluentValidationExtension.AddToModelState(validationCreateCartResult));

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet("GetAllItensCartByCustomerId/{id}")]
        [ProducesResponseType(typeof(Page<Domain.Entities.Cart>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllItensCartByCustomerId([FromQuery] CartFilters filters , long id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllItensCartByCustomerIdCommand(id, filters), cancellationToken);

            return Ok(response);
        }

        [HttpPut("CloseOrder/{customerId}/{storeBranchId}")]
        [ProducesResponseType(typeof(Page<Domain.Entities.Cart>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CloseOrder(long customerId, long storeBranchId)
        {
            var response = await _mediator.Send(new CloseOrderCommand(customerId, storeBranchId));

            return Ok(response.Data);
        }

        //[HttpGet("GetCartById/{id}")]
        //[ProducesResponseType(typeof(GetCartByIdResult), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetCartById([FromRoute] long id, CancellationToken cancellationToken)
        //{

        //    var response = await _mediator.Send(new GetCartByIdCommand(id), cancellationToken);

        //    return Ok(response.Data);
        //}

        //[HttpDelete("DeleteCart/{id}")]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> DeleteCart([FromRoute] long id, CancellationToken cancellationToken)
        //{

        //    await _mediator.Send(new DeleteCartCommand(id), cancellationToken);

        //    return Ok("Cart deleted successfully");

        //}

        //[HttpPut("UpdateCart")]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> UpdateCart([FromBody] UpdateCartCommand request)
        //{
        //    var validationCreateCartResult = await _updateCartValidator.ValidateAsync(request);

        //    if (!validationCreateCartResult.IsValid)
        //        return BadRequest(FluentValidationExtension.AddToModelState(validationCreateCartResult));

        //    var response = await _mediator.Send(request);

        //    return Ok(response.Message);

        //}
    }
}
