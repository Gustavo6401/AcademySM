using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface ICommentController
    {
        Task<ActionResult> Create([FromBody] Comment comment);
        Task<ActionResult> Delete(int id);
        Task<ActionResult<Comment>> Get(int id);
        Task<ActionResult<List<Comment>>> Index(int postId);
        Task<ActionResult> Update([FromBody] Comment comment);
    }
}
