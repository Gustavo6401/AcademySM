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
    public class DoubtController : ControllerBase, IDoubtController
    {
        private readonly IDoubtApplicationServices _applicationServices;
        public DoubtController(IDoubtApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }

        [HttpPost]
        [Authorize(Policy = "RequireBothTokens")]
        public async Task<ActionResult<string>> Create([FromBody] Doubt doubt)
        {
            await _applicationServices.Create(doubt);

            return Ok("Dúvida Enviada Com Sucesso!");
        }

        [HttpDelete]
        [Authorize(Policy = "RequireBothTokens")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            Doubt doubt = await _applicationServices.Get(id);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (doubt.UserId != Guid.Parse(userId))
                return Forbid("Você Não Tem Permissão para Deletar esse Usuário do Grupo!");

            await _applicationServices.Delete(id);

            return Ok("Dúvida Removida com Sucesso!");
        }

        [HttpGet("GetById")]
        [Authorize(Policy = "RequireBothTokens")]
        public async Task<ActionResult<Doubt>> Get(int id)
        {
            Doubt doubt = await _applicationServices.Get(id);

            return Ok(doubt);
        }

        [HttpGet("Index")]
        [Authorize(Policy = "RequireBothTokens")]
        public async Task<ActionResult<List<Doubt>>> Index(int groupId)
        {
            List<Doubt> list = await _applicationServices.Index(groupId);

            return Ok(list);
        }

        [HttpPut]
        [Authorize(Policy = "RequireBothTokens")]
        public async Task<ActionResult<string>> Update([FromBody] Doubt doubt)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (doubt.UserId != Guid.Parse(userId))
                return Forbid("Você Não Tem Permissão para Deletar esse Usuário do Grupo!");

            await _applicationServices.Update(doubt);

            return Ok("Pergunta Modificada Com Sucesso!");
        }
    }
}
