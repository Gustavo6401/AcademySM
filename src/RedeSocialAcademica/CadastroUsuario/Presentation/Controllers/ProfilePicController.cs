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
    public class ProfilePicController : ControllerBase, IProfilePicController
    {
        private readonly IProfilePicApplicationServices _applicationServices;
        public ProfilePicController(IProfilePicApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> Create([FromBody] ProfilePic picture)
        {
            try
            {
                if(User.FindFirst(ClaimTypes.NameIdentifier)?.Value! != picture.UserId.ToString())
                {
                    return Forbid();
                }

                await _applicationServices.Create(picture);

                return Ok("Foto de Perfil Cadastrada Com Sucesso!");
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
                ProfilePic picture = await _applicationServices.Get(id);

                if(User.FindFirst(ClaimTypes.NameIdentifier)?.Value! != picture.UserId.ToString())
                {
                    return Forbid();
                }

                await _applicationServices.Delete(id);

                return Ok("Foto de Perfil Deletada com Sucesso!");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetLastProfilePicture")]
        [AllowAnonymous]
        public async Task<ActionResult<ProfilePic>> GetLastProfilePic(Guid userId)
        {
            try
            {
                ProfilePic? profile = await _applicationServices.Get(userId);

                return Ok(profile);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetProfilePicture")]
        [Authorize]
        public async Task<ActionResult<List<ProfilePic>>> GetProfilePicturesByUserId(Guid userId)
        {
            try
            {
                List<ProfilePic>? profile = await _applicationServices.GetByUserId(userId);

                return Ok(profile);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ProfilePic>> Index(Guid id)
        {
            try
            {
                ProfilePic? profile = await _applicationServices.GetById(id);

                return Ok(profile);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
