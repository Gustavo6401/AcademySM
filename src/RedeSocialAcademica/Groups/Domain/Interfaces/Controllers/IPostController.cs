using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface IPostController
    {
        Task<ActionResult<string>> Create([FromBody] Post post);
        Task<ActionResult<string>> Delete(int id);
        Task<ActionResult<Post>> Get(int id);
        Task<ActionResult<List<Post>>> Index(int groupId);
        Task<ActionResult<string>> Update([FromBody] Post post);
    }
}
