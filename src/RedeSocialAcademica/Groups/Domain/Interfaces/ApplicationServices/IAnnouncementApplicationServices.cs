using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.ApplicationServices
{
    public interface IAnnouncementApplicationServices
    {
        Task Create(Announcement announcement);
        Task Delete(int id);
        Task<Announcement> Get(int id);
        Task<List<Announcement>> Index(int groupId);
        Task Update(Announcement announcement);
    }
}
