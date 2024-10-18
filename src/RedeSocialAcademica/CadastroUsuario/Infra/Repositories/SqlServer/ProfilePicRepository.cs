using CadastroUsuario.Domain.Interfaces.Repositories.SqlServer;
using CadastroUsuario.Domain.Models;
using CadastroUsuario.Infra.Context;
using CadastroUsuario.Infra.Repositories.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.Infra.Repositories.SqlServer
{
    public class ProfilePicRepository : SqlServerRepositoryBase<ProfilePic>, IProfilePictureRepository
    {
        private readonly UserDbContext _context;
        public ProfilePicRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<ProfilePic>> GetByUserId(Guid id)
        {
            List<ProfilePic>? list = await _context.ProfilePics.Where(p => p.UserId == id)
                                                              .ToListAsync();

            return list!;
        }

        public async Task<ProfilePic> GetValidProfilePic(Guid userId)
        {
            ProfilePic? picture = await _context.ProfilePics.FirstOrDefaultAsync(p => p.UserId == userId
                                                                                 && p.IsActive == true);

            return picture!;
        }
    }
}
