using Ambev.DeveloperEvaluation.Application.Handlers.Cart.CloseOrder;
using Ambev.DeveloperEvaluation.Application.Handlers.Order.ChangeStatusOrder;
using Ambev.DeveloperEvaluation.Application.Handlers.Order.GetAllOrdersByCustomerId;
using Ambev.DeveloperEvaluation.Application.ViewModel;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Order
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;


        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetAllOrdersByCustomerId/{id}")]
        [ProducesResponseType(typeof(Page<Domain.Entities.Order>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllOrdersByCustomerId([FromQuery] OrdertFilters filters, long id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllOrdersByCustomerIdCommand(id, filters), cancellationToken);

            return Ok(response.Data);
        }

        [HttpPut("ChangeStatusOrder/{customerId}/")]
        [ProducesResponseType(typeof(Page<Domain.Entities.Cart>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangeStatusOrder([FromQuery] bool CancelOrder, long customerId)
        {
            StatusSales status = CancelOrder ? StatusSales.Cancelled : StatusSales.NotCancelled;
            var response = await _mediator.Send(new ChangeStatusOrderCommand(customerId, status));

            return Ok(response.Data);
        }


    }
}
