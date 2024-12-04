using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.SqlServerModels;
using Groups.Domain.Models.ViewModels;

namespace Groups.Domain.Interfaces.Repositories.SqlServer
{
    public interface IGroupRepository : ISqlServerRepositoryBase<Courses>
    {
        Task<GroupsHomeViewModel> AccessGroup(Guid id);
        /// <summary>
        /// en
        /// Group's Ids is going to be used in the Front-End
        /// 
        /// pt-Br
        /// Os Ids dos Grupos serão usados no Front-End.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        new Task<Guid> Create(Courses courses);
        new Task<Courses> Get(int id);
        Task<List<Courses>> GetAll();
        Task<int> GetIdByPublicId(Guid id);
        Task<List<Courses>> GetByLevel(string level);
        Task<List<Courses>> GetByName(string name);
        Task<int> GetIdByName(string name);
        Task<List<Courses>> GetByTutorName(string tutor);
        Task<List<GroupsViewModel>> Groups();
    }
}
