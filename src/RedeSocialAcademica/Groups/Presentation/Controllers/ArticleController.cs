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
    public class ArticleController : ControllerBase, IArticleController
    {
        private readonly IArticleApplicationServices _applicationServices;
        public ArticleController(IArticleApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> Create([FromBody] Article article)
        {
            await _applicationServices.Create(article);

            return Ok("Artigo Compartilhado Com Sucesso!");
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<string>> Delete(int id)
        {
            Article article = await _applicationServices.Get(id);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (article.UserId != Guid.Parse(userId))
                return Forbid();

            await _applicationServices.Delete(id);

            return Ok("Artigo Removido Com Sucesso!");
        }

        [HttpGet("GetById")]
        [Authorize]
        public async Task<ActionResult<Article>> Get(int id)
        {
            Article article = await _applicationServices.Get(id);

            return Ok(article);
        }

        [HttpGet("Index")]
        [Authorize]
        public async Task<ActionResult<List<Article>>> Index(int groupId)
        {
            List<Article> list = await _applicationServices.GetByGroup(groupId);

            return Ok(list);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<string>> Update([FromBody] Article article)
        {
            Article model = await _applicationServices.Get(article.Id);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (article.UserId != Guid.Parse(userId))
                return Forbid();

            await _applicationServices.Update(article);

            return Ok("Dados de Artigo Modificados com Sucesso!");
        }
    }
}
