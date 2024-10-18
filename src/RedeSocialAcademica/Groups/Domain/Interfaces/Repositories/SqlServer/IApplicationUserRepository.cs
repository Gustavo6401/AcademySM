using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.Repositories.SqlServer;

public interface IApplicationUserRepository
{
    Task Create(ApplicationUser user);
    Task Delete(Guid id);
    Task<ApplicationUser> Get(Guid id);
    Task Update(ApplicationUser user);
}
