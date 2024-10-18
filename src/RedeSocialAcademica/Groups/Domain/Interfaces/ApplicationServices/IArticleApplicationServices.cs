using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.ApplicationServices
{
    public interface IArticleApplicationServices
    {
        Task Create(Article article);
        Task Delete(int id);
        Task<Article> Get(int id);
        Task<List<Article>> GetByGroup(int groupId);
        Task Update(Article article);
    }
}
