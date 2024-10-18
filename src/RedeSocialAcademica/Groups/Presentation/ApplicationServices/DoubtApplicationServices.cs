using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Presentation.ApplicationServices
{
    public class DoubtApplicationServices : IDoubtApplicationServices
    {
        private readonly IDoubtServices _services;
        private readonly IDoubtRepository _repository;
        public DoubtApplicationServices(IDoubtServices services, IDoubtRepository repository)
        {
            _services = services;
            _repository = repository;
        }
        public async Task Create(Doubt doubt)
        {
            _services.ValidateOnCreate(doubt);

            await _repository.Create(doubt);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<Doubt> Get(int id)
        {
            Doubt doubt = await _repository.Get(id);

            return doubt;
        }

        public async Task<List<Doubt>> Index(int groupId)
        {
            List<Doubt> list = await _repository.GetByGroup(groupId);

            return list;
        }

        public async Task Update(Doubt doubt)
        {
            _services.ValidateOnCreate(doubt);

            await _repository.Update(doubt);
        }
    }
}
