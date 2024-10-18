using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Groups.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostVoteController : ControllerBase, IPostVoteController
    {
        private readonly IPostVoteApplicationServices _applicationServices;
        private readonly IPostRepository _repository;
        public PostVoteController(IPostVoteApplicationServices applicationServices, IPostRepository repository)
        {
            _applicationServices = applicationServices;
            _repository = repository;
        }
        [HttpPost]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult> Create([FromBody] PostVote vote)
        {
            await _applicationServices.Create(vote);

            return Ok();
        }

        [HttpDelete]
        [Authorize(Policy = "RequireBothTokens")]
        public async Task<ActionResult> Delete(int id)
        {
            PostVote vote = await _applicationServices.Get(id);
            Post post = await _repository.Get(vote.PostId);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (post.UserId != Guid.Parse(userId))
                return Forbid("Você Não Tem Permissão Para Deletar Esse Voto!");

            await _applicationServices.Delete(id);

            return Ok();
        }

        [HttpGet("GetAllVotes")]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<List<PostVote>>> GetAllPostVotes(int postId)
        {
            List<PostVote> vote = await _applicationServices.GetAllPostVotes(postId);

            return Ok(vote);
        }

        [HttpGet("Index")]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<int>> Index(int postId)
        {
            int count = await _applicationServices.Index(postId);

            return Ok(count);
        }

        [HttpPut]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult> Update([FromBody] PostVote vote)
        {
            Post post = await _repository.Get(vote.PostId);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (post.UserId != Guid.Parse(userId))
                return Forbid("Você Não Tem Permissão Para Deletar Esse Voto!");

            await _applicationServices.Update(vote);

            return Ok();
        }
    }
}
