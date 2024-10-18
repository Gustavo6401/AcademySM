using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface IArticleController
    {
        Task<ActionResult<string>> Create([FromBody] Article article);
        Task<ActionResult<string>> Delete(int id);
        Task<ActionResult<Article>> Get(int id);
        Task<ActionResult<List<Article>>> Index(int groupId);
        Task<ActionResult<string>> Update([FromBody] Article article);
    }
}
