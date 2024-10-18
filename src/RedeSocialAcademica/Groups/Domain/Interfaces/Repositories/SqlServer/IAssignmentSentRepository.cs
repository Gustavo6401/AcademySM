using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Domain.Interfaces.Repositories.SqlServer
{
    public interface IAssignmentSentRepository : ISqlServerRepositoryBase<AssignmentSent>
    {
        /// <summary>
        /// Gets all assignments sents in the group.
        /// </summary>
        /// <param name="assignmentId"></param>
        /// <returns></returns>
        Task<List<AssignmentSent>> GetAll(int assignmentId);
    }
}
