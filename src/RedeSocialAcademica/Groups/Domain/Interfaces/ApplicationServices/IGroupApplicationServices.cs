using Groups.Domain.Models.SqlServerModels;
using Groups.Domain.Models.ViewModels;
using System.Text.RegularExpressions;

namespace Groups.Domain.Interfaces.ApplicationServices
{
    public interface IGroupApplicationServices
    {
        Task Create(Courses group);
        Task Delete(int id);
        Task<Courses> Get(int id);
        Task<List<Courses>> GetAll();
        Task<List<Courses>> GetByLevel(string level);
        Task<List<Courses>> GetByName(string name);
        Task<int> GetIdByName(string name);
        Task<List<Courses>> GetByTutorName(string tutor);
        Task<List<GroupsViewModel>> Groups();
        Task Update(Courses group);
    }
}
