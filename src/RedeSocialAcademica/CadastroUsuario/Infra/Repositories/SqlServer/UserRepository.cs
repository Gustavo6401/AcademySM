using CadastroUsuario.Domain.Interfaces.Repositories.SqlServer;
using CadastroUsuario.Domain.Interfaces.Services;
using CadastroUsuario.Domain.Models;
using CadastroUsuario.Domain.Models.API;
using CadastroUsuario.Domain.Models.ControllerModels;
using CadastroUsuario.Infra.Context;
using CadastroUsuario.Infra.Repositories.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.Infra.Repositories.SqlServer
{
    public class UserRepository : SqlServerRepositoryBase<ApplicationUser>, IUserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task CreateAsync(ApplicationUser entity)
        {
            _context.ApplicationUser.Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<ApplicationUser> GetByEmail(string email)
        {
            ApplicationUser? user = await _context.ApplicationUser.FirstOrDefaultAsync(u => u.EMail!.Equals(email));

            return user!;
        }

        public async Task<LoginInformations> Login(string email, string password)
        {
            LoginInformations? login = await _context.ApplicationUser.Where(u => u.EMail!.Equals(email)
                                                                           && u.Password!.Equals(password))
                .Select(u => new LoginInformations
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    ProfilePicPathName = _context.ProfilePics
                        .Where(pp => pp.UserId == u.Id
                            && pp.IsActive == true)
                        .Select(pp => pp.FileNameAndPath)
                        .FirstOrDefault()
                })
                .FirstOrDefaultAsync();

            return login!;
        }

        public async Task<UserPortfolio> Portfolio(Guid id)
        {
            UserPortfolio? portfolio = await _context.ApplicationUser
                .Where(u => u.Id == id)
                .Select(u => new UserPortfolio
                {
                    UserId = id,
                    UserName = u.FullName,
                    Curriculum = u.Curriculum,
                    ProfilePic = _context.ProfilePics
                        .Where(pp => pp.UserId == u.Id
                            && pp.IsActive == true)
                        .Select(pp => pp.FileNameAndPath)
                        .FirstOrDefault(),
                    Courses = _context.EducationalBackground
                        .Where(eb => eb.UserId == u.Id)
                        .Select(c => new PortfolioCourses {
                            CourseId = c.Id,
                            Name = c.Course
                        })
                        .ToList(),
                    Links = _context.Links
                        .Where(eb => eb.UserId == u.Id)
                        .Select(pl => new PortfolioLink
                        {
                            Id = pl.Id,
                            Name = pl.ProfileName,
                            Origin = pl.Origin,
                            Link = pl.Link
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();

            return portfolio!;
        }

        public override async Task UpdateAsync(ApplicationUser entity)
        {
            _context.ApplicationUser.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<UserDetailsReturn> UserDetails(Guid userId)
        {
            var result = await _context.ApplicationUser.Where(u => u.Id == userId)
                .Select(u => new UserDetailsReturn
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Formation = u.ActualCourse,
                    ProfilePicFileName = _context.ProfilePics
                         .Where(pp => pp.UserId == userId &&
                             pp.IsActive == true)
                        .Select(pp => pp.FileNameAndPath)
                        .FirstOrDefault()!,
                    Formations = _context.EducationalBackground
                        .Where(f => f.UserId == u.Id)
                        .Select(f => new FormationName
                        {
                            Id = f.Id,
                            Name = f.Course
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();

            return result!;
        }
    }
}
