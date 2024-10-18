using CadastroUsuario.Domain.Interfaces.ApplicationServices;
using CadastroUsuario.Domain.Interfaces.Controllers;
using CadastroUsuario.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CadastroUsuario.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationalBackgroundController : ControllerBase, IEducationalBackgroundController
    {
        private readonly IEducationalBackgroundApplicationServices _applicationServices;
        public EducationalBackgroundController(IEducationalBackgroundApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }
        [HttpPost]
        [Authorize] // User Must be authorized to perform this action
        public async Task<ActionResult<string>> Create([FromBody] EducationalBackground background)
        {
            try
            {
                if(User.FindFirst(ClaimTypes.NameIdentifier)?.Value! != background.UserId.ToString())
                {
                    return Forbid();
                }

                await _applicationServices.Create(background);

                return Ok("Formação Cadastrada com Sucesso!");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<string>> Delete(Guid id)
        {
            try
            {
                EducationalBackground background = await _applicationServices.Get(id);

                if(User.FindFirst(ClaimTypes.NameIdentifier)?.Value! != background.UserId.ToString())
                {
                    return Forbid();
                }

                await _applicationServices.Delete(id);

                return Ok("Formação Deletada com Sucesso!");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("ListUsersEducationalBackgrounds")]
        [AllowAnonymous]
        public async Task<ActionResult<List<EducationalBackground>>> GetByUserId(Guid userId)
        {
            try
            {
                List<EducationalBackground> background = await _applicationServices.GetByUserId(userId);

                return Ok(background);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetById")]
        [AllowAnonymous]
        public async Task<ActionResult<EducationalBackground>> Index(Guid id)
        {
            try
            {
                EducationalBackground background = await _applicationServices.Get(id);

                return Ok(background);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<string>> Update([FromBody] EducationalBackground background)
        {
            try
            {
                if(User.FindFirst(ClaimTypes.NameIdentifier)?.Value! != background.UserId.ToString())
                {
                    return Forbid();
                }

                await _applicationServices.Update(background);

                return Ok("Dados de Formação Atualizados com Sucesso!");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
