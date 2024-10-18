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
    public class ConversationController : ControllerBase, IConversationController
    {
        private readonly IConversationApplicationServices _applicationServices;
        private readonly IConversationUserApplicationServices _conversationUserApplicationServices;
        public ConversationController(IConversationApplicationServices applicationServices,
                                      IConversationUserApplicationServices conversationUserApplicationServices)
        {
            _applicationServices = applicationServices;
            _conversationUserApplicationServices = conversationUserApplicationServices;
        }

        [HttpPost]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<string>> Create([FromBody] Conversation conversation)
        {
            await _applicationServices.Create(conversation);

            return Ok("Conversa Criada Com Sucesso!");
        }

        [HttpDelete]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            List<ConversationsUsers> users = await _conversationUserApplicationServices.GetUsersByConversationId(id);

            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            foreach (var item in users)
            {
                if (item.UserId == Guid.Parse(userId) && item.ConversationRole == "Admin")
                    return Forbid("Você Não Tem Autorização para Deletar essa Conversa.");
            }

            await _applicationServices.Delete(id);

            return Ok("Conversa Deletada com Sucesso!");
        }

        [HttpGet("/Index")]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<Conversation>> Get(int id)
        {
            Conversation conversation = await _applicationServices.Get(id);

            return Ok(conversation);
        }

        [HttpGet("GetByName")]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<Conversation>> GetByName(string name)
        {
            Conversation conversation = await _applicationServices.GetByName(name);

            return Ok(conversation);
        }

        [HttpPut]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<string>> Update([FromBody] Conversation conversation)
        {
            List<ConversationsUsers> users = await _conversationUserApplicationServices.GetUsersByConversationId(conversation.Id);

            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            foreach (var item in users)
            {
                if (item.UserId == Guid.Parse(userId) && item.ConversationRole == "Admin")
                    return Forbid("Você Não Tem Autorização para Modificar dados dessa Conversa.");
            }

            await _applicationServices.Update(conversation);

            return Ok("Dados de Conversa Atualizados Com Sucesso!");
        }
    }
}
