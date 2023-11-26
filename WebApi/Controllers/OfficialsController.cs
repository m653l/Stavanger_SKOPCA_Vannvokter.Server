using Application.Officials.Commands;
using Application.Officials.Dtos;
using Application.Officials.Queries;
using Application.Submissions.Dtos;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OfficialsController : ControllerBase
    {
        private ISender _mediator = null!;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        [HttpGet("{officialId}", Name = "GetOfficialById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OfficialDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OfficialDto>> GetById([Required] int officialId)
        {
            return await Mediator.Send(new GetOfficialQuery(officialId));
        }

        [HttpPost(Name = "CreateOfficial")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Create(CreateOfficialCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut(Name = "UpdateOfficial")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Update(UpdateOfficialCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet(Name = "GetAllSubmissions")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SubmissionDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<SubmissionDto>>> GetAllSubmissions()
        {
            return await Mediator.Send(new GetAllSubmissionsQuery());
        }

        [HttpGet(Name = "GetSubmissionsByType")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SubmissionDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<SubmissionDto>>> GetSubmissionsByType([Required] SubmissionType submissionType)
        {
            return await Mediator.Send(new GetSubmissionsByType(submissionType));
        }

        [HttpDelete("{officialId}", Name = "DeleteOfficialById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteById([Required] int officialId)
        {
            await Mediator.Send(new DeleteOfficialCommand(officialId));
            return Ok();
        }
    }
}
