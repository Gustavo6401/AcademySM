using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.ApplicationServices
{
    public interface IAssignmentApplicationServices
    {
        Task Create(Assignment assignment);
        Task Delete(int id);
        Task<Assignment> Get(int id);
        Task<List<Assignment>> Index(int groupId);
        Task Update(Assignment assignment);
    }
}
