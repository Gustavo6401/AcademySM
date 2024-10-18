using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface IApplicationUserController
    {
        Task<ActionResult<string>> Create(ApplicationUser user);
        Task<ActionResult<string>> Delete(Guid id);
        Task<ActionResult<ApplicationUser>> Get(Guid id);
        Task<ActionResult<string>> Update(ApplicationUser user);
    }
}
