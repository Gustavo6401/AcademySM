using CadastroUsuario.Domain.Interfaces.Repositories.SqlServer;
using CadastroUsuario.Domain.Models;
using CadastroUsuario.Infra.Context;
using CadastroUsuario.Infra.Repositories.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.Infra.Repositories.SqlServer
{
    public class UserLockoutRepository : SqlServerRepositoryBase<UserLockout>, IUserLockoutRepository
    {
        private readonly UserDbContext _context;
        public UserLockoutRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserLockout> GetLastUserLockoutByUserId(Guid userId)
        {
            UserLockout? lastLockout = await _context.UserLockout.LastOrDefaultAsync(l => l.UserId == userId);

            return lastLockout!;
        }
    }
}
