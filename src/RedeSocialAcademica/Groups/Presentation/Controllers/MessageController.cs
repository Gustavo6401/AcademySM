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
    public class MessageController : ControllerBase, IMessageController
    {
        private readonly IMessageApplicationServices _applicationServices;
        public MessageController(IMessageApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }

        [HttpPost]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult> Create([FromBody] Message message)
        {
            await _applicationServices.Create(message);

            return Ok();
        }

        [HttpDelete]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult> Delete(int id)
        {
            Message message = await _applicationServices.Get(id);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (message.UserId != Guid.Parse(userId))
                return Forbid("Você Não Tem Permissão de Remover a Mensagem de Outro Usuário!");

            if (message.DateSent >= DateTime.Now.AddMinutes(15))
                return Forbid("A Mensagem Já Foi Enviada A Mais de 15 Minutos. Não é Possível Apagar.");

            await _applicationServices.Delete(id);

            return Ok();
        }

        [HttpGet("GetById")]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<Message>> Get(int id)
        {
            Message message = await _applicationServices.Get(id);

            return Ok(message);
        }

        [HttpGet("Index")]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<List<Message>>> Index(int page, int conversationId)
        {
            List<Message> list = await _applicationServices.Index(page, conversationId);

            return Ok(list);
        }

        [HttpPut]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult> Update([FromBody] Message message)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (message.UserId != Guid.Parse(userId))
                return Forbid("Você Não Tem Permissão de Editar a Mensagem de Outro Usuário!");

            if (message.DateSent >= DateTime.Now.AddMinutes(15))
                return Forbid("A Mensagem Já Foi Enviada A Mais de 15 Minutos. Não é Possível Editar.");

            await _applicationServices.Update(message);

            return Ok();
        }
    }
}
