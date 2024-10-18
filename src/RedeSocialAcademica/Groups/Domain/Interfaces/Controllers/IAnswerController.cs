using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface IAnswerController
    {
        Task<ActionResult<string>> Create([FromBody] Answer answer);
        Task<ActionResult<string>> Delete(int id);
        Task<ActionResult<Answer>> Get(int id);
        Task<ActionResult<List<Answer>>> Index(int doubtId);
        Task<ActionResult<string>> Update([FromBody] Answer answer);
    }
}
