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

        public async Task<GroupsHomeViewModel> AccessGroup(Guid id)
        {
            GroupsHomeViewModel? groupsHomeViewModel = await _context.Courses.Where(g => g.PublicId == id)
                .Select(g => new GroupsHomeViewModel
                {
                    Id = g.PublicId,
                    Name = g.Name,
                    Level = g.Level,
                    Description = g.Description,
                    Posts = _context.Posts.Where(p => p.GroupId == g.Id)
                        .ToList()
                })
                .FirstOrDefaultAsync();

            return groupsHomeViewModel!;
        }

        /// <summary>
        /// en
        /// Group's Ids is going to be used in the Front-End
        /// 
        /// pt-Br
        /// Os Ids dos Grupos serão usados no Front-End.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override async Task<Guid> Create(Courses entity)
        {
            _context.Courses.Add(entity);

            await _context.SaveChangesAsync();

            return entity.PublicId;
        }

        /// <summary>
        /// en
        /// This method is used a lot of time by internal methods and classes, like AnnouncementController 
        /// and I have to deal with it.
        /// 
        /// pt-Br
        /// Esse método é usado muitas vezes por métodos internos e classes, como AnnouncementController e eu
        /// tenho que lidar com isso.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<Courses> Get(int id)
        {
            Courses? course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);

            return course!;
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

        public async Task<int> GetIdByPublicId(Guid id)
        {
            int groupId = await _context.Courses.Where(g => g.PublicId == id)
                .Select(g => g.Id)
                .FirstOrDefaultAsync();

            return groupId;
        }

        public async Task<List<GroupsViewModel>> Groups()
        {
            List<GroupsViewModel> lista = await _context.Courses.Where(g => g.IsPublic == true)
                .Select(g => new GroupsViewModel
                {
                    GroupId = g.PublicId,
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
