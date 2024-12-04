using CadastroUsuario.Domain.Interfaces.ApplicationServices;
using CadastroUsuario.Domain.Interfaces.Controllers;
using CadastroUsuario.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CadastroUsuario.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController : ControllerBase, ILinksController
    {
        private readonly ILinksApplicationServices _applicationServices;
        public LinksController(ILinksApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> Add([FromBody] Links? links)
        {
            if(User.FindFirst(ClaimTypes.NameIdentifier)?.Value! != links!.UserId.ToString())
            {
                return BadRequest();
            }

            await _applicationServices.Create(links!);

            return Ok("Link Adicionado com Sucesso!");
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<string>> Delete(int id)
        {
            Links? links = await _applicationServices.Get(id)!;

            if(User.FindFirst(ClaimTypes.NameIdentifier)?.Value! != links.UserId.ToString())
            {
                return Forbid();
            }

            await _applicationServices.Delete(id);

            return Ok("Link Deletado com Sucesso!");
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Links>>? Get(int id)
        {
            Links? links = await _applicationServices.Get(id)!;

            return Ok(links!);
        }

        [HttpGet("index")]
        public async Task<ActionResult<List<Links>>>? Index(Guid id)
        {
            List<Links>? links = await _applicationServices.GetByUserId(id)!;

            return Ok(links!);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<string>> Update(Links? links)
        {
            if (User.FindFirst(ClaimTypes.NameIdentifier)?.Value! != links!.UserId.ToString())
            {
                return Forbid();
            }

            await _applicationServices.Update(links!);

            return Ok("Link Modificado com Sucesso");
        }
    }
}
