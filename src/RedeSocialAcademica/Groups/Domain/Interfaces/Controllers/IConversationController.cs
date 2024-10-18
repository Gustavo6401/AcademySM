using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface IConversationController
    {
        Task<ActionResult<string>> Create([FromBody] Conversation conversation);
        Task<ActionResult<string>> Delete(int id);
        Task<ActionResult<Conversation>> Get(int id);
        Task<ActionResult<Conversation>> GetByName(string name);
        Task<ActionResult<string>> Update([FromBody] Conversation conversation);
    }
}
