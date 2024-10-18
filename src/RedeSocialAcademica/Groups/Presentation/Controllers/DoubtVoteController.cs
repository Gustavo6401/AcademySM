using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Groups.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoubtVoteController : ControllerBase, IDoubtVoteController
    {
        private readonly IDoubtVoteApplicationServices _applicationServices;
        public DoubtVoteController(IDoubtVoteApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }
        [HttpPost]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<string>> Create([FromBody] DoubtVote vote)
        {
            await _applicationServices.Create(vote);

            return Ok();
        }

        [HttpDelete]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            DoubtVote vote = await _applicationServices.Get(id);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if(vote.UserId != Guid.Parse(userId))
            {
                return Forbid("Você Não Pode Remover Esse UpVote.");
            }

            await _applicationServices.Delete(id);

            return Ok();
        }

        [HttpGet("GetByDoubt")]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<List<DoubtVote>>> GetByDoubt(int doubtId)
        {
            List<DoubtVote> list = await _applicationServices.GetByDoubt(doubtId);

            return Ok(list);
        }

        [HttpGet("Index")]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<int>> Index(int doubtId)
        {
            int totalVotes = await _applicationServices.Index(doubtId);

            return Ok(totalVotes);
        }

        [HttpPut]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<string>> Update([FromBody] DoubtVote vote)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (vote.UserId != Guid.Parse(userId))
            {
                return Forbid("Você Não Pode Remover Esse UpVote.");
            }

            await _applicationServices.Update(vote);

            return Ok();
        }
    }
}
