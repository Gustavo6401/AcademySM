using CadastroUsuario.Domain.Interfaces.Repositories.SqlServer;
using CadastroUsuario.Domain.Models;
using CadastroUsuario.Infra.Context;
using CadastroUsuario.Infra.Repositories.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.Infra.Repositories.SqlServer
{
    public class EducationalBackgroundRepository : SqlServerRepositoryBase<EducationalBackground>, IEducationalBackgroundRepository
    {
        private readonly UserDbContext _context;
        public EducationalBackgroundRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<EducationalBackground>> GetByUserId(Guid id)
        {
            List<EducationalBackground>? list = await _context.EducationalBackground.Where(b => b.UserId == id)
                                                                                    .ToListAsync();

            return list!;
        }
    }
}
