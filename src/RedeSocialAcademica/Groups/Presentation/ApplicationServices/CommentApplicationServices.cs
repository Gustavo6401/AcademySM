using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Presentation.ApplicationServices
{
    public class CommentApplicationServices : ICommentApplicationServices
    {
        private readonly ICommentServices _services;
        private readonly ICommentRepository _repository;
        public CommentApplicationServices(ICommentServices services, ICommentRepository repository)
        {
            _services = services;
            _repository = repository;
        }
        public async Task Create(Comment comment)
        {
            _services.ValidateOnCreate(comment);

            await _repository.Create(comment);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<Comment> Get(int id)
        {
            Comment comment = await _repository.Get(id);

            return comment;
        }

        public async Task<List<Comment>> Index(int postId)
        {
            List<Comment> list = await _repository.GetAllPostComments(postId);

            return list;
        }

        public async Task Update(Comment comment)
        {
            _services.ValidateOnCreate(comment);

            await _repository.Update(comment);
        }
    }
}
