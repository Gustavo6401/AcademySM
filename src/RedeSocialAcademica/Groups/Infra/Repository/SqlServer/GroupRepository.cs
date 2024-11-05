using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Domain.Models.ViewModels;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class GroupRepository : SqlServerRepositoryBase<Courses>, IGroupRepository
    {
        private readonly GroupsDbContext _context;
        public GroupRepository(GroupsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<GroupsHomeViewModel> AccessGroup(int id)
        {
            List<Post>? list = await _context.Posts.Where(p => p.GroupId == id)
                .ToListAsync();

            GroupsHomeViewModel? groupsHomeViewModel = await _context.Courses.Where(g => g.Id == id)
                .Select(g => new GroupsHomeViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Level = g.Level,
                    Description = g.Description,
                    Posts = list
                })
                .FirstOrDefaultAsync();

            return groupsHomeViewModel!;
        }

        public async Task<List<Courses>> GetAll()
        {
            List<Courses>? courses = await _context.Courses.ToListAsync();

            return courses!;
        }

        public async Task<List<Courses>> GetByLevel(string level)
        {
            List<Courses>? courses = await _context.Courses.Where(g => g.Level!.Contains(level))
                                                           .ToListAsync();

            return courses!;
        }

        public async Task<List<Courses>> GetByName(string name)
        {
            List<Courses>? courses = await _context.Courses.Where(g => g.Name!.Contains(name))
                                                           .ToListAsync();

            return courses!;
        }

        public async Task<List<Courses>> GetByTutorName(string tutor)
        {
            List<Courses>? courses = await _context.Courses.Where(g => g.Tutor!.Contains(tutor))
                                                           .ToListAsync();

            return courses!;
        }

        public async Task<int> GetIdByName(string name)
        {
            int groupId = await _context.Courses.Where(g => g.Name == name)
                .Select(g => g.Id)
                .OrderBy(g => g)
                .LastOrDefaultAsync();

            return groupId;
        }

        public async Task<List<GroupsViewModel>> Groups()
        {
            List<GroupsViewModel> lista = await _context.Courses.Where(g => g.IsPublic == true)
                .Select(g => new GroupsViewModel
                {
                    GroupId = g.Id,
                    GroupTitle = g.Name,
                    GroupLevel = g.Level,
                    GroupCategoryIcon = _context.Categories.Where(c =>
                        c.Id == _context.CategoryGroups.Where(
                            gc => gc.GroupId == g.Id)
                            .Select(gc => gc.CategoryId)
                            .FirstOrDefault()
                        )
                        .Select(c => c.Icon)
                        .FirstOrDefault()
                })
                .ToListAsync();

            return lista;
        }
    }
}
