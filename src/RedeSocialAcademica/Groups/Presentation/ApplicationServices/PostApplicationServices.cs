using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Presentation.ApplicationServices
{
    public class PostApplicationServices : IPostApplicationServices
    {
        private readonly IPostServices _services;
        private readonly IPostRepository _repository;
        public PostApplicationServices(IPostServices services, IPostRepository repository)
        {
            _repository = repository;
            _services = services;
        }
        public async Task Create(Post post)
        {
            _services.ValidateOnCreate(post);

            await _repository.Create(post);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<Post> Get(int id)
        {
            Post post = await _repository.Get(id);

            return post;
        }

        public async Task<List<Post>> Index(int groupId)
        {
            List<Post> list = await _repository.GetByGroupId(groupId);

            return list;
        }

        public async Task Update(Post post)
        {
            _services.ValidateOnCreate(post);

            await _repository.Update(post);
        }
    }
}
