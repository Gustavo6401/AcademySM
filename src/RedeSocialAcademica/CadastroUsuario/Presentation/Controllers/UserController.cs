using CadastroUsuario.Domain.Interfaces.ApplicationServices;
using CadastroUsuario.Domain.Interfaces.Controllers;
using CadastroUsuario.Domain.Models;
using CadastroUsuario.Domain.Models.ControllerModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace CadastroUsuario.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IUserController
    {
        private readonly IUserApplicationServices _applicationServices;
        public UserController(IUserApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Create([FromBody] ApplicationUser user)
        {
            string response = await _applicationServices.CreateAsync(user);

            return Ok(response);

            /*try
            {
                string response = await _applicationServices.CreateAsync(user);

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return BadRequest();
            }*/
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                if(User.Identity!.Name != id.ToString())
                {
                    return Unauthorized();
                }

                await _applicationServices.DeleteAsync(id);

                return Ok();
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

        /*[HttpGet("UserDetails")]
        [Authorize(Policy = "RequireBothTokens")]
        public async Task<ActionResult>*/

        [HttpGet("GetByEmail")]
        [AllowAnonymous]
        public async Task<ActionResult<ApplicationUser>> GetByEmail(string email)
        {
            try
            {
                ApplicationUser user = await _applicationServices.GetByEmail(email);

                if(user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ApplicationUser>> Index(Guid id)
        {
            try
            {
                ApplicationUser user = await _applicationServices.GetById(id);

                return Ok(user);
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

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginReturn>> Login(Login login)
        {
            try
            {
                LoginReturn loginReturn = await _applicationServices.Login(login);

                return Ok(loginReturn);
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

        [HttpPost("Logout")]
        [Authorize]
        public async Task<ActionResult<string>> Logout()
        {
            string result = await _applicationServices.Logout();

            return result;
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update([FromBody] ApplicationUser user)
        {
            try
            {
                if(User.FindFirst(ClaimTypes.NameIdentifier)?.Value! != user.Id.ToString())
                {
                    return Unauthorized();
                }

                await _applicationServices.Update(user);

                return Ok();
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

        [HttpGet("/UserDetails")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDetailsReturn>> UserDetails(Guid id)
        {
            UserDetailsReturn userDetails = await _applicationServices.UserDetails(id);

            return Ok(userDetails);
        }

        /// <summary>
        /// This endpoint is used whenever user is Creating or buying a new Group.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("/ModifyAuthCookie")]
        [Authorize]
        public async Task<ActionResult> ModifyAuthCookie([FromHeader] Guid userId)
        {
            if(User.FindFirst(ClaimTypes.NameIdentifier)?.Value! != userId.ToString())
            {
                return Unauthorized();
            }

            await _applicationServices.ModifyAuthCookie(userId);

            return Ok();
        }
    }
}