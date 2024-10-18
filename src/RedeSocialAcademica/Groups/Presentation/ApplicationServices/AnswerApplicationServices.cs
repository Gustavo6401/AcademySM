using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Presentation.ApplicationServices
{
    public class AnswerApplicationServices : IAnswerApplicationServices
    {
        private readonly IAnswerRepository _repository;
        private readonly IAnswerServices _services;
        public AnswerApplicationServices(IAnswerRepository repository, IAnswerServices services)
        {
            _repository = repository;
            _services = services;
        }
        public async Task Create(Answer answer)
        {
            _services.ValidateOnCreate(answer);

            await _repository.Create(answer);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<Answer> Get(int id)
        {
            Answer answer = await _repository.Get(id);

            return answer;
        }

        public async Task<List<Answer>> Index(int doubtId)
        {
            List<Answer> list = await _repository.GetAnswersByDoubtId(doubtId);

            return list;
        }

        public async Task Update(Answer answer)
        {
            _services.ValidateOnCreate(answer);

            await _repository.Update(answer);
        }
    }
}
