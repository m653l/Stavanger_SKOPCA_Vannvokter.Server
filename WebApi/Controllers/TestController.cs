using Application.Commands;
using Domain.Aggregates;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Shared;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetTest/{id}")]
        public async Task<ActionResult<Test>> GetTest(int id)
        {
            Test result = await _mediator.Send(new GetTestCommand(id));

            return Ok(result);
        }

        [HttpPost(Name = "CreateTest")]
        public async Task<ActionResult<Test>> CreateTest(Test test)
        {
            await _mediator.Send(new CreateTestCommand(test));

            return Ok();
        }
    }
}
