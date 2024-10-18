using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Security.Claims;

namespace Groups.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationUsersController : ControllerBase, IConversationUserController
    {
        private readonly IConversationUserApplicationServices _applicationServices;
        public ConversationUsersController(IConversationUserApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }

        [HttpPost]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<string>> Create([FromBody] ConversationsUsers users)
        {
            await _applicationServices.Create(users);

            return Ok("Usuário Adicionado ao Grupo Com Sucesso!");
        }

        [HttpDelete]
        [Authorize("RequireBothTokens")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            ConversationsUsers users = await _applicationServices.Get(id);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if(users.UserId != Guid.Parse(userId) || users.ConversationRole == "Admin")
            {
                return Forbid("Você não Tem Permissão para remover esse usuário do Grupo!");
            }

            await _applicationServices.Delete(id);

            return Ok("Usuário Removido do Grupo Com Sucesso!");
        }

        [HttpGet("GetById")]
        [Authorize(Policy = "RequireBothTokens")]
        public async Task<ActionResult<ConversationsUsers>> Get(int id)
        {
            ConversationsUsers users = await _applicationServices.Get(id);

            return Ok(users);
        }

        [HttpGet("GetConversationUsers")]
        [Authorize(Policy = "RequireBothTokens")]
        public async Task<ActionResult<List<ConversationsUsers>>> GetUsersByConversationId(int conversationId)
        {
            List<ConversationsUsers> list = await _applicationServices.GetUsersByConversationId(conversationId);

            return Ok(list);
        }

        [HttpGet("Index")]
        [Authorize(Policy = "RequireBothTokens")]
        public async Task<ActionResult<List<ConversationsUsers>>> Index(int conversationId)
        {
            List<ConversationsUsers> listAdmins = await _applicationServices.Index(conversationId);

            return Ok(listAdmins);
        }

        [HttpPut]
        [Authorize(Policy = "RequireBothTokens")]
        public async Task<ActionResult<string>> Update([FromBody] ConversationsUsers users)
        {            
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (users.UserId != Guid.Parse(userId) || users.ConversationRole == "Admin")
            {
                return Forbid("Você não Tem Permissão para remover esse usuário do Grupo!");
            }

            await _applicationServices.Update(users);

            return Ok("Dados de Usuário Atualizados Com Sucesso.");

            throw new NotImplementedException();
        }
    }
}
