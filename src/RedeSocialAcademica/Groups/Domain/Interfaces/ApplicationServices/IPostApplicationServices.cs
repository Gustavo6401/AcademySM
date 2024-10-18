using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.ApplicationServices
{
    public interface IPostApplicationServices
    {
        Task Create(Post post);
        Task Delete(int id);
        Task<Post> Get(int id);
        Task<List<Post>> Index(int groupId);
        Task Update(Post post);
    }
}
