using Groups.Domain.Models.SqlServerModels.Aggregations;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface IGroupCategoryController
    {
        Task<ActionResult<string>> Create(CategoryGroups categoryGroups);
    }
}
