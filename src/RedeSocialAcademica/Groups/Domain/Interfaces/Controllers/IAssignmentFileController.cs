using Groups.Domain.Models.SqlServerModels.Aggregations;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface IAssignmentFileController
    {
        Task<ActionResult> Create([FromBody] AssignmentFile file);
        Task<ActionResult<string>> Delete(int id);
        Task<ActionResult<AssignmentFile>> Get(int id);
        Task<ActionResult<List<AssignmentFile>>> Index(int assignmentId);
        /// <summary>
        /// This method is mainly used for updating clodfront's URLs.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<ActionResult> Update([FromBody] AssignmentFile file);
    }
}
