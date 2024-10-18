using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Groups.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentSentController : ControllerBase, IAssignmentSentController
    {
        private readonly IAssignmentSentApplicationServices _applicationServices;
        private readonly IAssignmentApplicationServices _assignmentApplicationServices;
        public AssignmentSentController(IAssignmentSentApplicationServices applicationServices, IAssignmentApplicationServices assignmentApplicationServices)
        {
            _applicationServices = applicationServices;
            _assignmentApplicationServices = assignmentApplicationServices;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> Create([FromBody] AssignmentSent sent)
        {
            sent.DateSent = DateTime.Now;

            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if(userId != Convert.ToString(sent.UserId))
            {
                return Forbid();
            }

            await _applicationServices.Create(sent);

            return Ok("Envio Realizado com Sucesso!");
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<string>> Delete(int id)
        {
            AssignmentSent sent = await _applicationServices.Get(id);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (sent.UserId != Guid.Parse(userId))
                return Forbid();

            await _applicationServices.Delete(id);

            return Ok("Envio Abortado Com Sucesso!");
        }

        [HttpGet("GetById")]
        [Authorize]
        public async Task<ActionResult<AssignmentSent>> Get(int id)
        {
            AssignmentSent assignment = await _applicationServices.Get(id);

            return Ok(assignment);
        }

        [HttpPut("Grade")]
        [Authorize]
        public async Task<ActionResult<string>> GiveAGrade(float grade, int id)
        {
            AssignmentSent assignmentSent = await _applicationServices.Get(id);
            Assignment assignment = await _assignmentApplicationServices.Get(assignmentSent.AssignmentId);
            
            string role = User.FindFirst($"GroupsRole-{assignment.GroupId}")?.Value!;

            if(role != "Professor")
            {
                return Forbid();
            }

            // Essa parte ficou foda! !!
            await _applicationServices.GiveAGrade(grade, id);

            return Ok("Nota do Aluno Atribuída com Sucesso!");
        }

        [HttpGet("Index")]
        [Authorize]
        public async Task<ActionResult<List<AssignmentSent>>> Index(int assignmentId)
        {
            List<AssignmentSent> assignments = await _applicationServices.Index(assignmentId);

            return Ok(assignments);
        }

        [HttpPut("Update")]
        [Authorize]
        public async Task<ActionResult<string>> Update([FromBody] AssignmentSent sent)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            if (sent.UserId != Guid.Parse(userId))
                return Forbid();

            sent.DateSent = DateTime.Now;

            await _applicationServices.Update(sent);

            return Ok("Envio Modificado com Sucesso!");
        }
    }
}
