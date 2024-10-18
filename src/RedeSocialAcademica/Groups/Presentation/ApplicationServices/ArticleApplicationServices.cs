using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Presentation.ApplicationServices
{
    public class ArticleApplicationServices : IArticleApplicationServices
    {
        private readonly IArticleRepository _repository;
        private readonly IArticleServices _services;
        public ArticleApplicationServices(IArticleRepository repository, IArticleServices services)
        {
            _repository = repository;
            _services = services;
        }
        public async Task Create(Article article)
        {
            _services.ValidateOnCreate(article);

            await _repository.Create(article);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<Article> Get(int id)
        {
            Article article = await _repository.Get(id);

            return article;
        }

        public async Task<List<Article>> GetByGroup(int groupId)
        {
            List<Article> list = await _repository.GetByGroupId(groupId);

            return list;
        }

        public async Task Update(Article article)
        {
            _services.ValidateOnCreate(article);

            await _repository.Update(article);
        }
    }
}
