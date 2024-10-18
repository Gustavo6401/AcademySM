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
    public class PostController : ControllerBase, IPostController
    {
        private readonly IPostApplicationServices _applicationServices;
        public PostController(IPostApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }

        [HttpPost]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<string>> Create([FromBody] Post post)
        {
            await _applicationServices.Create(post);

            return Ok("Post Realizado Com Sucesso!");
        }

        [HttpDelete]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            Post post = await _applicationServices.Get(id);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (post.UserId != Guid.Parse(userId))
                return Forbid("Você Não Tem Permissão Para Deletar Esse Post.");

            await _applicationServices.Delete(id);

            return Ok("Post Deletado Com Sucesso!");
        }

        [HttpGet("GetById")]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<Post>> Get(int id)
        {
            Post post = await _applicationServices.Get(id);

            return Ok(post);
        }

        [HttpGet("Index")]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<List<Post>>> Index(int groupId)
        {
            List<Post> list = await _applicationServices.Index(groupId);

            return list;
        }

        [HttpPut]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<string>> Update([FromBody] Post post)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (post.UserId != Guid.Parse(userId))
                return Forbid("Você Não Tem Permissão Para Deletar Esse Post.");

            await _applicationServices.Update(post);

            return Ok("Post Atualizado Com Sucesso!");
        }
    }
}
