using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface IPostVoteController
    {
        Task<ActionResult> Create([FromBody] PostVote vote);
        Task<ActionResult> Delete(int id);
        Task<ActionResult<List<PostVote>>> GetAllPostVotes(int postId);
        Task<ActionResult<int>> Index(int postId);
        Task<ActionResult> Update([FromBody] PostVote vote);
    }
}
