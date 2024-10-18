using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.Repositories.SqlServer
{
    public interface ICategoryRepository
    {
        Task<Category> GetByName(string? name);
        Task<List<Category>> GetAllCategories();
    }
}
