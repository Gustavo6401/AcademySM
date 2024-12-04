using Groups.Domain.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers
{
    public interface IGroupCategoryController
    {
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
        Task<ActionResult<string>> Create(GroupsCategoryViewModel categoryGroups);
    }
}
