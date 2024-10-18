using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;

namespace Groups.Infra.Repository.SqlServer
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly GroupsDbContext _context;
        public ApplicationUserRepository(GroupsDbContext context)
        {
            _context = context;
        }

        public async Task Create(ApplicationUser user)
        {
            _context.User.Add(user);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            ApplicationUser user = await Get(id);

            _context.User.Remove(user);

            await _context.SaveChangesAsync();
        }

        public async Task<ApplicationUser> Get(Guid id)
        {
            ApplicationUser? user = await _context.User.FindAsync(id);

            return user!;
        }

        public async Task Update(ApplicationUser user)
        {
            _context.User.Update(user);

            await _context.SaveChangesAsync();
        }
    }
}
