using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface ICategoryController
    {
        Task<ActionResult<List<Category>>> Index();
        Task<ActionResult<Category>> GetByName(string? name);
    }
}
