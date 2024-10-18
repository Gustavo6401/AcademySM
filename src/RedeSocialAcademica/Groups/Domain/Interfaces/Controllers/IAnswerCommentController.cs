using Groups.Domain.Models.SqlServerModels.Aggregations;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface IAnswerCommentController
    {
        Task<ActionResult> Create([FromBody] AnswerComment comment);
        Task<ActionResult> Delete(int id);
        Task<ActionResult<AnswerComment>> Get(int id);
        Task<ActionResult<List<AnswerComment>>> Index(int answerId);
        Task<ActionResult> Update([FromBody] AnswerComment comment);
    }
}
