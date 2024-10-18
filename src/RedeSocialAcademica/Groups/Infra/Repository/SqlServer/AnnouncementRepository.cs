using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class AnnouncementRepository : SqlServerRepositoryBase<Announcement>, IAnnouncementRepository
    {
        private readonly GroupsDbContext _context;
        public AnnouncementRepository(GroupsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Announcement>> GetAnnouncementsByGroupId(int groupId)
        {
            List<Announcement>? list = await _context.Announcements.Where(a => a.GroupId == groupId)
                                                                   .ToListAsync();

            return list!;
        }

        public async Task<Announcement> GetById(int id)
        {
            Announcement? announcement = await _context.Announcements.FirstOrDefaultAsync(a => a.Id == id);

            return announcement!;
        }
    }
}
