using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface IDoubtVoteController
    {
        Task<ActionResult<string>> Create([FromBody] DoubtVote vote);
        Task<ActionResult<string>> Delete(int id);
        Task<ActionResult<List<DoubtVote>>> GetByDoubt(int doubtId);
        Task<ActionResult<int>> Index(int doubtId);
        Task<ActionResult<string>> Update([FromBody] DoubtVote vote);
    }
}
