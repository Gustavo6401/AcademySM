using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.ApplicationServices
{
    public interface IDoubtApplicationServices
    {
        Task Create(Doubt doubt);
        Task Delete(int id);
        Task<Doubt> Get(int id);
        Task<List<Doubt>> Index(int groupId);
        Task Update(Doubt doubt);
    }
}
