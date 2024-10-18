using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Groups.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase, IApplicationUserController
    {
        private readonly IApplicationUserRepository _repository;
        public ApplicationUserController(IApplicationUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> Create(ApplicationUser user)
        {
            if(User.FindFirst(ClaimTypes.NameIdentifier)?.Value! != user.Id.ToString())
            {
                return Forbid();
            }

            await _repository.Create(user);

            return Ok("Usuário Cadastrado com Sucesso!");
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<string>> Delete(Guid id)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (id != Guid.Parse(userId))
                return Forbid();

            await _repository.Delete(id);

            return Ok("Cadastro de Usuário Removido com Sucesso!");
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ApplicationUser>> Get(Guid id)
        {
            ApplicationUser user = await _repository.Get(id);

            return Ok(user);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<string>> Update(ApplicationUser user)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (user.Id != Guid.Parse(userId))
                return Forbid();

            await _repository.Update(user);

            return Ok("Cadastro de Usuário Modificado com Sucesso!");
        }
    }
}
