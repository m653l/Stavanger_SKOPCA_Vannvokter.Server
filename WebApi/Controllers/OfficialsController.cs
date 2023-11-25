using Application.Officials.Commands;
using Application.Officials.Dtos;
using Application.Officials.Queries;
using Application.Producers.Commands;
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
    }
}
