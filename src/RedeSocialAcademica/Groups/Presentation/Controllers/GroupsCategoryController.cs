using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsCategoryController : ControllerBase, IGroupCategoryController
    {
        private readonly IGroupCategoryRepository _repository;
        public GroupsCategoryController(IGroupCategoryRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] CategoryGroups categoryGroups)
        {
            await _repository.Create(categoryGroups);

            return Ok("Categoria adicionada ao Grupo com Sucesso!");
        }
    }
}
