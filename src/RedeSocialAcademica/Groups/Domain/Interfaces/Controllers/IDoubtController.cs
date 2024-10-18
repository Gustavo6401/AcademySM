using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface IDoubtController
    {
        Task<ActionResult<string>> Create([FromBody] Doubt doubt);
        Task<ActionResult<string>> Delete(int id);
        Task<ActionResult<Doubt>> Get(int id);
        Task<ActionResult<List<Doubt>>> Index(int groupId);
        Task<ActionResult<string>> Update([FromBody] Doubt doubt);
    }
}
