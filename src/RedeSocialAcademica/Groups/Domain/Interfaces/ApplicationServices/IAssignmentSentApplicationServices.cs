using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Domain.Interfaces.ApplicationServices
{
    public interface IAssignmentSentApplicationServices
    {
        Task Create(AssignmentSent sent);
        Task Delete(int id);
        Task<AssignmentSent> Get(int id);
        Task GiveAGrade(float grade, int sentId);
        Task<List<AssignmentSent>> Index(int assignmentId);
        Task Update(AssignmentSent sent);
    }
}
