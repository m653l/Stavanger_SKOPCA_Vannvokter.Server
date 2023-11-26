using Application.Articles.Commands;
using Application.Articles.Dtos;
using Application.Articles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArtilesController : ControllerBase
    {
        private ISender _mediator = null!;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        [HttpGet("{articleId}", Name = "GetArticleById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ArticleDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ArticleDto>> GetById([Required] int articleId)
        {
            return await Mediator.Send(new GetArticleQuery(articleId));
        }

        [HttpPost(Name = "CreateArticle")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Create(CreateArticleCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut(Name = "UpdateArticle")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Update(UpdateArticleCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{articleId}", Name = "DeleteArticleById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteById([Required] int articleId)
        {
            await Mediator.Send(new DeleteArticleCommand(articleId));
            return Ok();
        }


        [HttpGet(Name = "GetAllArticlesById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ArticleDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ArticleDto>>> GetById()
        {
            return await Mediator.Send(new GetAllArticlesQuery());
        }
    }
}
