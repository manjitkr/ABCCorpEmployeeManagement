using ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Commands.CreateEmployeeRecord;
using ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Commands.DeleteEmployeeRecord;
using ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Commands.UpdateEmployeeRecord;
using ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Queries.Common;
using ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Queries.GetAllEmployeeRecords;
using ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Queries.GetEmployeeRecordDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ABCCorp.EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRecordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeRecordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<EmployeeRecordController>
        [HttpGet]
        [Authorize(Roles = "ActiveAppUser")]
        public async Task<ActionResult<List<EmployeeRecordDetailsDto>>> Get(
            [FromQuery] string? filterFirstName = null,
            [FromQuery] string? filterLastName = null,
            [FromQuery] string? filterDateCreated = null,
            [FromQuery] string? filterDateModified = null,
            [FromQuery] string? sortBy = null,
            [FromQuery] string? sortDirection = null,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var query = new GetAllEmployeeRecordsQuery
            {
                FilterFirstName = filterFirstName,
                FilterLastName = filterLastName,
                FilterDateCreated = filterDateCreated,
                FilterDateModified = filterDateModified,
                SortBy = sortBy,
                SortDirection = sortDirection,
                Page = page,
                PageSize = pageSize
            };

            var employeeRecords = await _mediator.Send(query);
            return Ok(employeeRecords);
        }

        // GET api/<EmployeeRecordController>/5
        [Authorize(Roles = "ActiveAppUser")]
        [HttpGet("{id}")]
        public async  Task<ActionResult<EmployeeRecordDetailsDto>> Get(int id)
        {
            var employeeRecords = await _mediator.Send(new GetEmployeeRecordDetailsRequest(id));
            return Ok(employeeRecords);
        }

        // POST api/<EmployeeRecordController>

        [Authorize(Roles = "ActiveAppUser")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public async Task<ActionResult<int>> Post([FromBody] CreateEmployeeRecordCommand command)
        {
           var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = result });

        }

        // PUT api/<EmployeeRecordController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Put([FromBody] UpdateEmployeeRecordCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<EmployeeRecordController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteEmployeeRecordCommand (id));
            return NoContent();
        }
    }

}
