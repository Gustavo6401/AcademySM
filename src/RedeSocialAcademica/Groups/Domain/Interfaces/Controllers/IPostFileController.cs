using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface IPostFileController
    {
        Task<ActionResult> Create([FromBody] PostFile file);
        Task<ActionResult<string>> Delete(int id);
        Task<ActionResult<PostFile>> Get(int id);
        Task<ActionResult<List<PostFile>>> Index(int postId);
        Task<ActionResult> Update([FromBody] PostFile file);
    }
}
