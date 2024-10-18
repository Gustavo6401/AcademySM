using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.SqlServerModels;
using Groups.Domain.Models.ViewModels;

namespace Groups.Domain.Interfaces.Repositories.SqlServer
{
    public interface IGroupRepository : ISqlServerRepositoryBase<Courses>
    {
        Task<List<Courses>> GetAll();
        Task<List<Courses>> GetByLevel(string level);
        Task<List<Courses>> GetByName(string name);
        Task<int> GetIdByName(string name);
        Task<List<Courses>> GetByTutorName(string tutor);
        Task<List<GroupsViewModel>> Groups();
    }
}
