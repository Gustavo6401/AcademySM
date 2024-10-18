using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Presentation.ApplicationServices
{
    public class AssignmentSentApplicationServices : IAssignmentSentApplicationServices
    {
        private readonly IAssignmentSentRepository _repository;
        public AssignmentSentApplicationServices(IAssignmentSentRepository repository)
        {
            _repository = repository;
        }
        public async Task Create(AssignmentSent sent)
        {
            await _repository.Create(sent);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<AssignmentSent> Get(int id)
        {
            AssignmentSent sent = await _repository.Get(id);

            return sent;
        }

        public async Task GiveAGrade(float grade, int sentId)
        {
            AssignmentSent sent = await Get(sentId);
            sent.Rate = grade;

            await Update(sent);
        }

        public async Task<List<AssignmentSent>> Index(int assignmentId)
        {
            List<AssignmentSent> sent = await _repository.GetAll(assignmentId);

            return sent;
        }

        public async Task Update(AssignmentSent sent)
        {
            await _repository.Update(sent);
        }
    }
}
