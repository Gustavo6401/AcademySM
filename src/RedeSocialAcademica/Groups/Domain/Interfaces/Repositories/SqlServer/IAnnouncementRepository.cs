using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.Repositories.SqlServer
{
    public interface IAnnouncementRepository : ISqlServerRepositoryBase<Announcement>
    {
        Task<Announcement> GetById(int id);
        /// <summary>
        /// This method will be used when the user open the tab "Avisos".
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        Task<List<Announcement>> GetAnnouncementsByGroupId(int groupId);
    }
}
