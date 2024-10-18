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
    public class AnswerVoteController : ControllerBase, IAnswerVoteController
    {
        private readonly IAnswerVoteApplicationServices _applicationServices;
        public AnswerVoteController(IAnswerVoteApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create([FromBody] AnswerVote vote)
        {
            await _applicationServices.Create(vote);

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            AnswerVote vote = await _applicationServices.Get(id);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (vote.UserId != Guid.Parse(userId))
                return Forbid();

            await _applicationServices.Delete(id);

            return Ok();
        }

        [HttpGet("GetVotes")]
        [Authorize]
        public async Task<ActionResult<List<AnswerVote>>> GetVotes(int answerId)
        {
            List<AnswerVote> list = await _applicationServices.GetByAnswerId(answerId);

            return Ok(list);
        }

        [HttpGet("Index")]
        [Authorize]
        public async Task<ActionResult<int>> Index(int answerId)
        {
            int total = await _applicationServices.Index(answerId);

            return Ok(total);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update([FromBody] AnswerVote vote)
        {
            AnswerVote model = await _applicationServices.Get(vote.Id);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (model.UserId != Guid.Parse(userId))
                return Forbid("Você Não tem Permissão para Remover Essa Resposta.");

            await _applicationServices.Update(vote);

            return Ok();
        }
    }
}
