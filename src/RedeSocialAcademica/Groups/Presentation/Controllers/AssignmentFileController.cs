using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentFileController : ControllerBase, IAssignmentFileController
    {
        private readonly IAssignmentFileRepository _repository;
        private readonly IAssignmentRepository _assignmentRepository;
        public AssignmentFileController(IAssignmentFileRepository repository, IAssignmentRepository assignmentRepository)
        {
            _repository = repository;
            _assignmentRepository = assignmentRepository;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create([FromBody] AssignmentFile file)
        {
            Assignment assignment = await _assignmentRepository.Get(file.AssignmentId);

            string role = User.FindFirst($"GroupRole-{assignment.GroupId}")?.Value!;

            if (role != "Professor")
            {
                return Forbid();
            }

            await _repository.Create(file);

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<string>> Delete(int id)
        {
            AssignmentFile file = await _repository.Get(id);
            Assignment assignment = await _assignmentRepository.Get(file.AssignmentId);

            string role = User.FindFirst($"GroupRole-{assignment.GroupId}")?.Value!;

            if(role != "Professor")
            {
                return Forbid();
            }

            await _repository.Delete(id);

            return Ok("Arquivo Removido com Sucesso!");
        }

        [HttpGet("GetById")]
        [Authorize]
        public async Task<ActionResult<AssignmentFile>> Get(int id)
        {
            AssignmentFile file = await _repository.Get(id);

            return Ok(file);
        }

        [HttpGet("Index")]
        [Authorize]
        public async Task<ActionResult<List<AssignmentFile>>> Index(int assignmentId)
        {
            List<AssignmentFile>? list = await _repository.GetAllAssignmentFiles(assignmentId);

            return Ok(list!);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update([FromBody] AssignmentFile file)
        {
            Assignment assignment = await _assignmentRepository.Get(file.AssignmentId);

            string role = User.FindFirst($"GroupRole-{assignment.GroupId}")?.Value!;

            if (role != "Professor")
            {
                return Forbid();
            }

            await _repository.Update(file);

            return Ok();
        }
    }
}
