using CadastroUsuario.Domain.Interfaces.ApplicationServices;
using CadastroUsuario.Domain.Interfaces.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntermediateTokenController : ControllerBase, IIntermediateTokenController
    {
        private readonly IIntermediateTokenApplicationServices _appServices;
        public IntermediateTokenController(IIntermediateTokenApplicationServices applicationServices)
        {
            _appServices = applicationServices;
        }

        [Authorize (Policy = "IntermediateTokenAuthentication")]
        [HttpGet]
        public async Task<ActionResult<string>> GetByUserId(Guid id)
        {
            try
            {
                string token = await _appServices.GetToken(id);

                return Ok(token);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("RegenerateToken")]
        [Authorize("MainTokenAuthentication")]
        public async Task<ActionResult<string>> RegenerateToken(Guid id)
        {
            try
            {
                string response = await _appServices.RefreshIntermediateToken(id);

                return response;
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
