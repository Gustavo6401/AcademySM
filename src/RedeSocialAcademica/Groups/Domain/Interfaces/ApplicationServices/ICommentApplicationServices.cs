using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.ApplicationServices
{
    public interface ICommentApplicationServices
    {
        Task Create(Comment comment);
        Task Delete(int id);
        Task<Comment> Get(int id);
        Task<List<Comment>> Index(int postId);
        Task Update(Comment comment);
    }
}
