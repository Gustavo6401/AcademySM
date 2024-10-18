using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Groups.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerCommentController : ControllerBase, IAnswerCommentController
    {
        private readonly IAnswerCommentApplicationServices _applicationServices;
        public AnswerCommentController(IAnswerCommentApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create([FromBody] AnswerComment comment)
        {
            await _applicationServices.Create(comment);

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            AnswerComment comment = await _applicationServices.Get(id);

            // ClaimTypes.NameIdentifier - UserId
            // User.Identity.Name - Access Cookie
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (comment.UserId != Guid.Parse(userId))
                return Forbid();

            await _applicationServices.Delete(id);

            return Ok();
        }

        [HttpGet("GetById")]
        [Authorize]
        public async Task<ActionResult<AnswerComment>> Get(int id)
        {
            AnswerComment comment = await _applicationServices.Get(id);

            return Ok(comment);
        }

        [HttpGet("Index")]
        [Authorize]
        public async Task<ActionResult<List<AnswerComment>>> Index(int answerId)
        {
            List<AnswerComment> list = await _applicationServices.Index(answerId);

            return Ok(list);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update([FromBody] AnswerComment comment)
        {
            AnswerComment model = await _applicationServices.Get(comment.Id);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (model.UserId != Guid.Parse(userId))
                return Forbid();

            await _applicationServices.Update(comment);

            return Ok();
        }
    }
}
