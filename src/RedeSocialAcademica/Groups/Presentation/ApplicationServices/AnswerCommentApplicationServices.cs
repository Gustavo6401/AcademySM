using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Presentation.ApplicationServices
{
    public class AnswerCommentApplicationServices : IAnswerCommentApplicationServices
    {
        private readonly IAnswerCommentServices _services;
        private readonly IAnswerCommentRepository _repository;
        public AnswerCommentApplicationServices(IAnswerCommentServices services, IAnswerCommentRepository repository)
        {
            _services = services;
            _repository = repository;
        }
        public async Task Create(AnswerComment comment)
        {
            _services.ValidateOnCreate(comment);

            await _repository.Create(comment);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<AnswerComment> Get(int id)
        {
            AnswerComment comment = await _repository.Get(id);

            return comment;
        }

        public async Task<List<AnswerComment>> Index(int answerId)
        {
            List<AnswerComment> list = await _repository.GetByAnswerId(answerId);

            return list;
        }

        public async Task Update(AnswerComment comment)
        {
            _services.ValidateOnCreate(comment);

            await _repository.Update(comment);
        }
    }
}
