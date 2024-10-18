using Groups.Domain.Models.SqlServerModels.Aggregations;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface IAnswerVoteController
    {
        Task<ActionResult> Create([FromBody] AnswerVote vote);
        Task<ActionResult> Delete(int id);
        Task<ActionResult<List<AnswerVote>>> GetVotes(int answerId);
        Task<ActionResult<int>> Index(int answerId);
        Task<ActionResult> Update([FromBody] AnswerVote vote);
    }
}
