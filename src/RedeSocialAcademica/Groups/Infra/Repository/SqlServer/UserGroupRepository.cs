using Groups.Domain.Interfaces.Repositories.SqlServer;
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

            return user;
        }

        public async Task<List<GroupsUsers>> GetByUserId(Guid userId)
        {
            List<GroupsUsers>? list = await _context.GroupsUsers.Where(gu => gu.UserId == userId)
                                                                .ToListAsync();

            return list!;
        }
    }
}
