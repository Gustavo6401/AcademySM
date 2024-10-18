using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Security.Claims;

namespace Groups.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase, IUserGroupController
    {
        private readonly IUserGroupApplicationServices _applicationServices;
        public UserGroupController(IUserGroupApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> Create([FromBody] GroupsUsers users)
        {
            await _applicationServices.Create(users);

            return Ok("Cadastrado no Grupo com Sucesso!");
        }
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<string>> Delete(int id)
        {
            GroupsUsers user = await _applicationServices.Get(id);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (user.UserId != Guid.Parse(userId))
                return Forbid("Você Não Tem Permissão Para Remover Esse Usuário do Grupo");

            await _applicationServices.Delete(id);

            return Ok("Usuário Removido do Grupo com Sucesso!");
        }

        [HttpGet("GetByGroupId")]
        [Authorize]
        public async Task<ActionResult<List<GroupsUsers>>> GetByGroupId(int groupId)
        {
            List<GroupsUsers> list = await _applicationServices.GetByGroupId(groupId);

            return Ok(list);
        }

        [HttpGet("GetByUserId")]
        [AllowAnonymous]
        public async Task<ActionResult<List<GroupsUsers>>> GetByUserId(Guid userId)
        {
            List<GroupsUsers> list = await _applicationServices.GetByUserId(userId);

            return Ok(list);
        }

        [HttpGet("Index")]
        [Authorize]
        public async Task<ActionResult<GroupsUsers>> Index(int id)
        {
            GroupsUsers users = await _applicationServices.Get(id);

            return Ok(users);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<string>> Update([FromBody] GroupsUsers users)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (users.UserId != Guid.Parse(userId))
                return Forbid("Você Não Tem Permissão Para Editar os Dados desse Usuário.");

            await _applicationServices.Update(users);

            return Ok("Dados de Usuário Modificados com Sucesso!");
        }
    }
}
