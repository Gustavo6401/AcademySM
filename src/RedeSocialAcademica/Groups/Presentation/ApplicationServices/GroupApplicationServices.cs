using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Domain.Models.ViewModels;
using System.Diagnostics.CodeAnalysis;

namespace Groups.Presentation.ApplicationServices
{
    public class GroupApplicationServices : IGroupApplicationServices
    {
        private readonly IGroupServices _services;
        private readonly IGroupRepository _repository;
        public GroupApplicationServices(IGroupServices services, IGroupRepository repository)
        {
            _services = services;
            _repository = repository;
        }
        public async Task Create(Courses group)
        {
            _services.ValidateOnCreate(group);

            await _repository.Create(group);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<Courses> Get(int id)
        {
            Courses? group = await _repository.Get(id);

            return group!;
        }

        public async Task<List<Courses>> GetAll()
        {
            List<Courses>? list = await _repository.GetAll();

            return list!;
        }

        public async Task<List<Courses>> GetByLevel(string level)
        {
            List<Courses>? list = await _repository.GetByLevel(level);

            return list!;
        }

        public async Task<List<Courses>> GetByName(string name)
        {
            List<Courses>? list = await _repository.GetByName(name);

            return list!;
        }

        public async Task<List<Courses>> GetByTutorName(string tutor)
        {
            List<Courses>? list = await _repository.GetByTutorName(tutor);

            return list!;
        }

        public async Task<int> GetIdByName(string name)
        {
            int groupId = await _repository.GetIdByName(name);

            return groupId;
        }

        public async Task<List<GroupsViewModel>> Groups()
        {
            List<GroupsViewModel> list = await _repository.Groups();

            return list;
        }

        public async Task Update(Courses group)
        {
            _services.ValidateOnCreate(group);

            await _repository.Update(group);
        }
    }
}
