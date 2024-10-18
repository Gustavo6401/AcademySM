using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Domain.Interfaces.Repositories.SqlServer
{
    public interface IAssignmentFileRepository : ISqlServerRepositoryBase<AssignmentFile>
    {
        /// <summary>
        /// This method is responsible for getting all of assignment's files filtering by assignment id.
        /// </summary>
        /// <param name="assignmentId"></param>
        /// <returns></returns>
        Task<List<AssignmentFile>> GetAllAssignmentFiles(int assignmentId);
    }
}
