using Groups.Domain.Models.SqlServerModels;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface IAssignmentSentController
    {
        Task<ActionResult<string>> Create([FromBody] AssignmentSent sent);
        Task<ActionResult<string>> Delete(int id);
        Task<ActionResult<AssignmentSent>> Get(int id);
        Task<ActionResult<string>> GiveAGrade(float grade, int id);
        Task<ActionResult<List<AssignmentSent>>> Index(int assignmentId);
        Task<ActionResult<string>> Update([FromBody] AssignmentSent sent);        
    }
}
