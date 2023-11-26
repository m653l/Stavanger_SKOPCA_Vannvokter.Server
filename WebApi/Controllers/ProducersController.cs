using Application.Producers.Commands;
using Application.Producers.Dtos;
using Application.Producers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private ISender _mediator = null!;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        [HttpPost(Name = "CreateProducer")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Create(CreateProducerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut(Name = "UpdateProducer")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Update(UpdateProducerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("{producerId}", Name = "GetProducerById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProducerDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProducerDto>> GetById([Required] int producerId)
        {
            return await Mediator.Send(new GetProducerQuery(producerId));
        }

        [HttpDelete("{producerId}", Name = "DeleteProducerById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteById([Required] int producerId)
        {
            await Mediator.Send(new DeleteProducerCommand(producerId));
            return Ok();
        }
    }
}
