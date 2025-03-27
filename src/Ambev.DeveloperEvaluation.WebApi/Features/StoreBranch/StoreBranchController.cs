using Ambev.DeveloperEvaluation.Application.Handlers.Customer.CreateCustomer;
using Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.CreateStoreBranch;
using Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.DeleteStoreBranch;
using Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.GetAllStoreBranchsPaged;
using Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.GetStoreBranchById;
using Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.UpdateStoreBranch;
using Ambev.DeveloperEvaluation.Application.ViewModel;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Requests;
using Ambev.DeveloperEvaluation.Domain.Validation.FluentValidationExtension;
using Ambev.DeveloperEvaluation.WebApi.Common;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.StoreBranch
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreBranchController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateStoreBranchCommand> _createStoreBranchValidator;
        private readonly IValidator<UpdateStoreBranchCommand> _updateStoreBranchValidator;


        public StoreBranchController(IMediator mediator, IMapper mapper, IValidator<CreateStoreBranchCommand> createStoreBranchValidator, IValidator<UpdateStoreBranchCommand> updateStoreBranchValidator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _createStoreBranchValidator = createStoreBranchValidator;
            _updateStoreBranchValidator = updateStoreBranchValidator;
        }

        [HttpPost("CreateStoreBranch")]
        [ProducesResponseType(typeof(CreateStoreBranchResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResultModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateStoreBranch([FromBody] CreateStoreBranchCommand request, CancellationToken cancellationToken)
        {
            var validationCreateStoreBranchResult = await _createStoreBranchValidator.ValidateAsync(request);

            if (!validationCreateStoreBranchResult.IsValid)
                return BadRequest(FluentValidationExtension.AddToModelState(validationCreateStoreBranchResult));

            var response = await _mediator.Send(request, cancellationToken);
            return Created(string.Empty, response);
        }

        [HttpGet("GetAllStoreBranchsPaged")]
        [ProducesResponseType(typeof(Page<Domain.Entities.StoreBranch>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllStoreBranchsPaged([FromQuery] StoreBranchsFilters filters, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllStoreBranchsPagedCommand(filters), cancellationToken);

            return Ok(response.Data);
        }

        [HttpGet("GetStoreBranchById/{id}")]
        [ProducesResponseType(typeof(GetStoreBranchByIdResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStoreBranchById([FromRoute] long id, CancellationToken cancellationToken)
        {
           
            var response = await _mediator.Send(new GetStoreBranchByIdCommand(id), cancellationToken);

            return Ok(response.Data);
        }

        [HttpDelete("DeleteStoreBranch/{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStoreBranch([FromRoute] long id, CancellationToken cancellationToken)
        {          

            await _mediator.Send(new DeleteStoreBranchCommand(id), cancellationToken);

            return Ok("StoreBranch deleted successfully");
           
        }

        [HttpPut("UpdateStoreBranch")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStoreBranch([FromBody] UpdateStoreBranchCommand request)
        {
            var validationCreateStoreBranchResult = await _updateStoreBranchValidator.ValidateAsync(request);

            if (!validationCreateStoreBranchResult.IsValid)
                return BadRequest(FluentValidationExtension.AddToModelState(validationCreateStoreBranchResult));

            var response = await _mediator.Send(request);

            return Ok(response.Message);

        }
    }
}
