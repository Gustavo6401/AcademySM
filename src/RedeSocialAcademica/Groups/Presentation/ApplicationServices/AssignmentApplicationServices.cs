using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Presentation.ApplicationServices
{
    public class AssignmentApplicationServices : IAssignmentApplicationServices
    {
        private readonly IAssignmentRepository _repository;
        private readonly IAssignmentServices _services;
        public AssignmentApplicationServices(IAssignmentRepository repository, IAssignmentServices services)
        {
            _repository = repository;
            _services = services;
        }

        public async Task Create(Assignment assignment)
        {
            _services.ValidateAssignmentOnCreate(assignment);

            await _repository.Create(assignment);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<Assignment> Get(int id)
        {
            Assignment? assignment = await _repository.Get(id);

            return assignment!;
        }

        public async Task<List<Assignment>> Index(int groupId)
        {
            List<Assignment>? list = await _repository.GetAssignmentsByCourseId(groupId);

            return list!;
        }

        public async Task Update(Assignment assignment)
        {
            _services.ValidateAssignmentOnCreate(assignment);

            await _repository.Update(assignment);
        }
    }
}
