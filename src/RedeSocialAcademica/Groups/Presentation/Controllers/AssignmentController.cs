using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase, IAssignmentController
    {
        private readonly IAssignmentApplicationServices _applicationServices;
        public AssignmentController(IAssignmentApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> Create([FromBody] Assignment assignment)
        {
            string role = User.FindFirst($"GroupRole-{assignment.GroupId}")?.Value!;

            if(role != "Professor")
            {
                return Forbid();
            }

            await _applicationServices.Create(assignment);

            return Ok("Tarefa Cadastrada Com Sucesso!");
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<string>> Delete(int id)
        {
            Assignment assignment = await _applicationServices.Get(id);

            string role = User.FindFirst($"GroupRole-{assignment.GroupId}")?.Value!;

            if (role != "Professor")
            {
                return Forbid();
            }

            await _applicationServices.Delete(id);

            return Ok("Tarefa Removida com Sucesso!");
        }

        [HttpGet("GetById")]
        [Authorize]
        public async Task<ActionResult<Assignment>> Get(int id)
        {
            Assignment assignment = await _applicationServices.Get(id);

            return Ok(assignment);
        }

        [HttpGet("Index")]
        [Authorize]
        public async Task<ActionResult<List<Assignment>>> Index(int groupId)
        {
            List<Assignment> list = await _applicationServices.Index(groupId);

            return Ok(list);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<string>> Update([FromBody] Assignment assignment)
        {
            string role = User.FindFirst($"GroupRole-{assignment.GroupId}")?.Value!;

            if (role != "Professor")
            {
                return Forbid();
            }

            await _applicationServices.Update(assignment);

            return Ok("Dados de Tarefa Atualizados com Sucesso!");
        }
    }
}
