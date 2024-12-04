using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.API;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class UserGroupRepository : SqlServerRepositoryBase<GroupsUsers>, IUserGroupRepository
    {
        private readonly GroupsDbContext _context;
        public UserGroupRepository(GroupsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<GroupsUsers>> GetByGroupId(int groupId)
        {
            List<GroupsUsers>? list = await _context.GroupsUsers.Where(gu => gu.GroupId == groupId)
                                                               .ToListAsync();

            return list!;
        }

        public async Task<GroupsUsers> GetByUserAndGroupId(Guid userId, int groupId)
        {
            GroupsUsers? user = await _context.GroupsUsers.FirstOrDefaultAsync(gu => gu.UserId == userId
                                                                              && gu.GroupId == groupId);

            return user!;
        }

        public async Task<List<GroupsUsers>> GetByUserId(Guid userId)
        {
            List<GroupsUsers>? list = await _context.GroupsUsers.Where(gu => gu.UserId == userId)
                                                                .ToListAsync();

            return list!;
        }

        public async Task<List<ParticipantGroup>> GetParticipantGroups(Guid userId)
        {
            List<ParticipantGroup> list = await _context.GroupsUsers.Where(gu => gu.UserId == userId)
                .Select(gu => new ParticipantGroup
                {
                    GroupId = gu.GroupId,
                    GroupName = _context.Courses.Where(g => g.Id == gu.GroupId)
                        .Select(g => g.Name)
                        .FirstOrDefault(),
                    Role = gu.Role,
                    // Script Generated with ChatGPT.
                    CategoryIcon = _context.CategoryGroups
                        .Where(cg => cg.GroupId == gu.GroupId)
                        .Join(_context.Categories,
                            cg => cg.CategoryId,
                            c => c.Id,
                            (cg, c) => c.Icon)
                        .FirstOrDefault()
                })
                .ToListAsync();

            return list!;
        }
    }
}
