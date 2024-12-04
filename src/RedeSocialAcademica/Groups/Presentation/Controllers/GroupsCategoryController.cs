using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Groups.Domain.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsCategoryController : ControllerBase, IGroupCategoryController
    {
        private readonly IGroupCategoryApplicationServices _applicationServices;
        public GroupsCategoryController(IGroupCategoryApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }

        /// <summary>
        /// en
        /// Group's public Ids are utils in this application, because we cannot expose the true Ids.
        /// 
        /// pt-Br
        /// Estou recebendo o Id público nessa aplicação porque nós não podemos expôr os Ids verdadeiros
        /// e auto-incrementais.
        /// </summary>
        /// <param name="categoryGroups"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> Create([FromBody] GroupsCategoryViewModel categoryGroups)
        {
            await _applicationServices.Create(categoryGroups);

            return Ok("Categoria adicionada ao Grupo com Sucesso!");
        }
    }
}
