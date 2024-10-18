using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface IAssignmentController
    {
        Task<ActionResult<string>> Create([FromBody] Assignment assignment);
        Task<ActionResult<string>> Delete(int id);
        Task<ActionResult<Assignment>> Get(int id);
        Task<ActionResult<List<Assignment>>> Index(int groupId);
        Task<ActionResult<string>> Update([FromBody] Assignment assignment);
    }
}
