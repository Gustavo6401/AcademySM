using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface IAnnouncementController
    {
        Task<ActionResult<string>> Create([FromBody] Announcement announcement);
        Task<ActionResult<string>> Delete(int id);
        Task<ActionResult<List<Announcement>>> Index(int groupId);
        Task<ActionResult<string>> Update([FromBody] Announcement announcement);
    }
}
