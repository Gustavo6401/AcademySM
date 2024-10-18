using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Models.SqlServerModels;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Groups.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase, ICommentController
    {
        private readonly ICommentApplicationServices _applicationServices;
        public CommentController(ICommentApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }

        [HttpPost]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult> Create([FromBody] Comment comment)
        {
            await _applicationServices.Create(comment);

            return Ok();
        }

        [HttpDelete]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult> Delete(int id)
        {
            Comment comment = await _applicationServices.Get(id);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (comment.UserId != Guid.Parse(userId))
                return Forbid("Você Não tem Permissão para Deletar Esse Artigo.");

            await _applicationServices.Delete(id);

            return Ok();
        }

        [HttpGet("GetById")]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<Comment>> Get(int id)
        {
            Comment comment = await _applicationServices.Get(id);

            return Ok(comment);
        }

        [HttpGet("Index")]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<List<Comment>>> Index(int postId)
        {
            List<Comment> list = await _applicationServices.Index(postId);

            return Ok(list);
        }

        [HttpPut]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult> Update([FromBody] Comment comment)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (comment.UserId != Guid.Parse(userId))
                return Forbid("Você Não tem Permissão para Deletar Esse Artigo.");

            await _applicationServices.Update(comment);

            return Ok();
        }
    }
}
