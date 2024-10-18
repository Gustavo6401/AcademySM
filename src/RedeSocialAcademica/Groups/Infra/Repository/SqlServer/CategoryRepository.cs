using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GroupsDbContext _context;
        public CategoryRepository(GroupsDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAllCategories()
        {
            List<Category>? categories = await _context.Categories.ToListAsync();

            return categories!;
        }

        public async Task<Category> GetByName(string? name)
        {
            Category? category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);

            return category!;
        }
    }
}
