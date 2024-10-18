using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Groups.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase, IAnswerController
    {
        private readonly IAnswerApplicationServices _applicationServices;
        public AnswerController(IAnswerApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> Create([FromBody] Answer answer)
        {
            await _applicationServices.Create(answer);

            return Ok("Resposta Enviada com Sucesso!");
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<string>> Delete(int id)
        {
            Answer answer = await _applicationServices.Get(id);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (answer.UserId != Guid.Parse(userId))
                return Forbid();

            await _applicationServices.Delete(id);

            return Ok("Resposta Removida Com Sucesso!");
        }

        [HttpGet("GetById")]
        [Authorize]
        public async Task<ActionResult<Answer>> Get(int id)
        {
            try
            {
                Answer answer = await _applicationServices.Get(id);

                return Ok(answer);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("Index")]
        [Authorize]
        public async Task<ActionResult<List<Answer>>> Index(int doubtId)
        {
            List<Answer> list = await _applicationServices.Index(doubtId);

            return Ok(list);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<string>> Update([FromBody] Answer answer)
        {
            Answer model = await _applicationServices.Get(answer.Id);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (model.UserId != Guid.Parse(userId))
                return Forbid();

            await _applicationServices.Update(answer);

            return Ok("Resposta Modificada Com Sucesso!");
        }
    }
}
