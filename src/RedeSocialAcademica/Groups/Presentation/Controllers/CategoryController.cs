using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase, ICategoryController
    {
        private readonly ICategoryRepository _repository;
        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetByName")]
        [AllowAnonymous]
        public async Task<ActionResult<Category>> GetByName(string? name)
        {
            Category category = await _repository.GetByName(name);

            return Ok(category);
        }

        [HttpGet("Index")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Category>>> Index()
        {
            List<Category> categories = await _repository.GetAllCategories();

            return Ok(categories);
        }
    }
}
