using Application.Producers.Commands;
using Application.Submissions.Commands;
using Application.Submissions.Dtos;
using Application.Submissions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubmissionsController : ControllerBase
    {
        private ISender _mediator = null!;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        [HttpPost(Name = "CreateSubmission")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Create([FromBody] CreateSubmissionCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut(Name = "UpdateSubmission")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Update(UpdateProducerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("{SubmissionId}", Name = "GetSubmissionById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubmissionDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SubmissionDto>> GetById([Required] int SubmissionId)
        {
            return await Mediator.Send(new GetSubmissionQuery(SubmissionId));
        }

        [HttpGet(Name ="GetSubmissionsByDate")]
        public async Task<ActionResult<List<SubmissionDto>>> GetByDate(DateTime fromDate, DateTime untilDate)
        {
            return await Mediator.Send(new GetSubmissionsByDateQuery(fromDate, untilDate));
        }

        [HttpDelete("{submissionId}", Name = "DeleteSubmissionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteById([Required] int submissionId)
        {
            await Mediator.Send(new DeleteSubmissionCommand(submissionId));
            return Ok();
        }
    }
}
