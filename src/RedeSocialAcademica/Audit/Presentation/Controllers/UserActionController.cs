using Audit.Domain.Interfaces.ApplicationServices;
using Audit.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Audit.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserActionController : ControllerBase
    {
        private readonly IUserActionApplicationServices _applicationServices;
        public UserActionController(IUserActionApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<string>> AuthorizeUserAction(UserAction action)
        {
            try
            {
                string result = await _applicationServices.ValidateUserAction(action);

                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
