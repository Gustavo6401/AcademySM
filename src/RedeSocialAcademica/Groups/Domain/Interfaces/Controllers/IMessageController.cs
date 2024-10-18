using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface IMessageController
    {
        Task<ActionResult> Create([FromBody] Message message);
        Task<ActionResult> Delete(int id);
        Task<ActionResult<Message>> Get(int id);
        Task<ActionResult<List<Message>>> Index(int page, int conversationId);
        Task<ActionResult> Update([FromBody] Message message);
    }
}
