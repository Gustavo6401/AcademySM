using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase, IAnnouncementController
    {
        private readonly IAnnouncementApplicationServices _applicationServices;
        private readonly IGroupApplicationServices _groupApplicationServices;
        public AnnouncementController(IAnnouncementApplicationServices applicationServices, 
            IGroupApplicationServices groupApplicationServices)
        {
            _applicationServices = applicationServices;
            _groupApplicationServices = groupApplicationServices;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> Create([FromBody] Announcement announcement)
        {
            Courses course = await _groupApplicationServices.Get(announcement.GroupId);

            if(User.FindFirst($"GroupRole-{course.Id}")?.Value! != "Professor")
            {
                return Forbid();
            }

            await _applicationServices.Create(announcement);

            return Ok("Aviso Enviado Com Sucesso!");
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<string>> Delete(int id)
        {
            Announcement announcement = await _applicationServices.Get(id);
            Courses course = await _groupApplicationServices.Get(announcement.GroupId);

            if (User.FindFirst($"GroupRole-{course.Id}")?.Value! != "Professor")
            {
                return Forbid();
            }

            await _applicationServices.Delete(id);

            return Ok("Aviso Deletado com Sucesso!");
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Announcement>>> Index(int groupId)
        {
            List<Announcement>? list = await _applicationServices.Index(groupId);

            return Ok(list);
        }

        [HttpPut]
        [Authorize]
        [Authorize]
        public async Task<ActionResult<string>> Update([FromBody] Announcement announcement)
        {
            Courses course = await _groupApplicationServices.Get(announcement.GroupId);

            if (User.FindFirst($"GroupRole-{course.Id}")?.Value! != "Professor")
            {
                return Forbid();
            }

            await _applicationServices.Update(announcement);

            return Ok("Aviso Modificado Com Sucesso!");
        }
    }
}
