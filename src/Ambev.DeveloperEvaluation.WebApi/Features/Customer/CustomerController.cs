using Ambev.DeveloperEvaluation.Application.Handlers.Customer.CreateCustomer;
using Ambev.DeveloperEvaluation.Application.Handlers.Customer.DeleteCustomer;
using Ambev.DeveloperEvaluation.Application.Handlers.Customer.GetAllCustomerPaged;
using Ambev.DeveloperEvaluation.Application.Handlers.Customer.GetCustomerById;
using Ambev.DeveloperEvaluation.Application.Handlers.Customer.UpdateCustomer;
using Ambev.DeveloperEvaluation.Application.ViewModel;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Models;
using Ambev.DeveloperEvaluation.Domain.Requests;
using Ambev.DeveloperEvaluation.Domain.Validation.FluentValidationExtension;
using Ambev.DeveloperEvaluation.WebApi.Common;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customer
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCustomerCommand> _validatorCreateCustomer;
        private readonly IValidator<GetCustomerByIdCommand> _validatorGetCustomerById;
        private readonly IValidator<DeleteCustomerCommand> _validatorDeleteCustomer;
        private readonly IValidator<UpdateCustomerCommand> _validatorUpdateCustomer;

        public CustomerController(IMediator mediator, IMapper mapper, IValidator<CreateCustomerCommand> validatorCreateCustomer, IValidator<GetCustomerByIdCommand> validatorGetCustomerById, IValidator<DeleteCustomerCommand> validatorDeleteCustomer, IValidator<UpdateCustomerCommand> validatorUpdateCustomer)
        {
            _mediator = mediator;
            _mapper = mapper;
            _validatorCreateCustomer = validatorCreateCustomer;
            _validatorGetCustomerById = validatorGetCustomerById;
            _validatorDeleteCustomer = validatorDeleteCustomer;
            _validatorUpdateCustomer = validatorUpdateCustomer;
        }

        [HttpPost("CreateCustomer")]
        [ProducesResponseType(typeof(CreateCustomerResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validationCreateCustomerResult = await _validatorCreateCustomer.ValidateAsync(request);

            if (!validationCreateCustomerResult.IsValid)
                return BadRequest(FluentValidationExtension.AddToModelState(validationCreateCustomerResult));

            var response = await _mediator.Send(request, cancellationToken);

            return Created(string.Empty, new ResultModel
            {
                Success = true,
                Message = "Customer created successfully",
                Data = _mapper.Map<CreateCustomerResult>(response)
            });
        }

        [HttpGet("GetAllCustomerPaged")]
        [ProducesResponseType(typeof(Page<GetAllCustomerPagedResult>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCustomerPaged([FromQuery] CustomerFilters filters, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllCustomerPagedCommand(filters), cancellationToken);

            return Created(string.Empty, new ResultModel
            {
                Success = true,
                Data = response.Result
            });
        }

        [HttpGet("GetCustomerById/{id}")]
        [ProducesResponseType(typeof(GetCustomerByIdResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomerById([FromRoute] long id, CancellationToken cancellationToken)
        {
            var validationGetCustomerByIdResult = await _validatorGetCustomerById.ValidateAsync(new GetCustomerByIdCommand(id));

            if (!validationGetCustomerByIdResult.IsValid)
                return BadRequest(FluentValidationExtension.AddToModelState(validationGetCustomerByIdResult));

            var response = await _mediator.Send(new GetCustomerByIdCommand(id), cancellationToken);

            var CustomerModel = _mapper.Map<CustomerModel>(response.CustomerModel);

            return Ok(CustomerModel);
        }

        [HttpDelete("DeleteCustomer/{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCustomer([FromRoute] long id, CancellationToken cancellationToken)
        {
            var validationGetCustomerByIdResult = await _validatorDeleteCustomer.ValidateAsync(new DeleteCustomerCommand(id));

            if (!validationGetCustomerByIdResult.IsValid)
                return BadRequest(FluentValidationExtension.AddToModelState(validationGetCustomerByIdResult));

            await _mediator.Send(new DeleteCustomerCommand(id), cancellationToken);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Customer deleted successfully"
            });
        }

        [HttpPut("UpdateCustomer")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand request)
        {
            var validation = await _validatorUpdateCustomer.ValidateAsync(request);

            if (!validation.IsValid)
                return BadRequest(FluentValidationExtension.AddToModelState(validation));

            var response = await _mediator.Send(request);

            return Ok(response);

        }
    }
}
