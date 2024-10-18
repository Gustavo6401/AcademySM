using Groups.Domain.Models.SqlServerModels.Aggregations;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface IConversationUserController
    {
        Task<ActionResult<string>> Create([FromBody] ConversationsUsers users);
        Task<ActionResult<string>> Delete(int id);
        Task<ActionResult<ConversationsUsers>> Get(int id);
        Task<ActionResult<List<ConversationsUsers>>> GetUsersByConversationId(int conversationId);
        Task<ActionResult<List<ConversationsUsers>>> Index(int conversationId);
        Task<ActionResult<string>> Update([FromBody] ConversationsUsers users);
    }
}
