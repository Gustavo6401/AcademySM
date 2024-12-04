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
        public async Task<GroupsHomeViewModel> AccessGroup(Guid id)
        {
            GroupsHomeViewModel? group = await _repository.AccessGroup(id);

            return group!;
        }
        public async Task<Guid> Create(Courses group)
        {
            _services.ValidateOnCreate(group);

            Guid id = await _repository.Create(group);

            return id;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<Courses> Get(int id)
        {
            /*
             * en
             * I use the method's overload to search by an Guid. Public Auto_increment Ids is an security
             * failure, so my main goal now is to search for ALL of those failures and correct it.
             * 
             * pt-Br
             * Eu uso a sobrecarga de métodos para buscar por um Guid. Ids auto incrementais públicos são uma
             * falha de segurança, então meu objetivo principal é buscar TODAS essas falhas e corrigi-las.
             */
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

        public async Task<int> GetIdByPublicId(Guid id)
        {
            int groupId = await _repository.GetIdByPublicId(id);

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
