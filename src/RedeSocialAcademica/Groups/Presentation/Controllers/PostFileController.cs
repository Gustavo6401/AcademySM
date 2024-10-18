using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Infra.Repository.SqlServer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Groups.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostFileController : ControllerBase, IPostFileController
    {
        private readonly IPostFileRepository _repository;
        private readonly IPostRepository _postRepository;
        public PostFileController(IPostFileRepository repository, IPostRepository postRepository)
        {
            _repository = repository;
            _postRepository = postRepository;
        }
        [HttpPost]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult> Create([FromBody] PostFile file)
        {
            await _repository.Create(file);

            return Ok();
        }

        [HttpDelete]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            PostFile file = await _repository.Get(id);
            Post post = await _postRepository.Get(file.PostId);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (post.UserId != Guid.Parse(userId))
                return Forbid("Você Não Tem a Permissão de Deletar esse Arquivo!");

            await _repository.Delete(id);

            return Ok("Arquivo Removido Com Sucesso!");
        }

        [HttpGet("GetOne")]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<PostFile>> Get(int id)
        {
            PostFile file = await _repository.Get(id);

            return Ok(file);
        }

        [HttpGet("Index")]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<List<PostFile>>> Index(int postId)
        {
            List<PostFile> list = await _repository.GetAllPostFiles(postId);

            return Ok(list);
        }

        [HttpPut]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult> Update([FromBody] PostFile file)
        {
            Post post = await _postRepository.Get(file.PostId);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (post.UserId != Guid.Parse(userId))
                return Forbid("Você Não Tem a Permissão de Deletar esse Arquivo!");

            await _repository.Update(file);

            return Ok();
        }
    }
}
