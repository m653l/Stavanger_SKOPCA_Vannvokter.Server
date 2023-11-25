using Application.Producers.Commands;
using Application.Submitions.Commands;
using Application.Submitions.Dtos;
using Application.Submitions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubmitionsController : ControllerBase
    {
        private ISender _mediator = null!;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        [HttpPost(Name = "CreateSubmition")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Create([FromBody] CreateSubmitionCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut(Name = "UpdateSubmition")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Update(UpdateProducerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("{submitionId}", Name = "GetSubmitionById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubmissionDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SubmissionDto>> GetById([Required] int submitionId)
        {
            return await Mediator.Send(new GetSubmissionQuery(submitionId));
        }

        [HttpGet(Name ="GetSubmissionsByDate")]
        public async Task<ActionResult<List<SubmissionDto>>> GetByDate(DateTime fromDate, DateTime untilDate)
        {
            return await Mediator.Send(new GetSubmissionsByDateQuery(fromDate, untilDate));
        }
    }
}
