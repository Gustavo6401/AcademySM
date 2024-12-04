using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Models.MongoDBModels.Rooms;
using Groups.Infra.Repository.MongoDB.RoomsDataPersistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Groups.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly RoomsRepository _repository;
        private readonly IGroupApplicationServices _applicationServices;
        public RoomsController(RoomsRepository repository, IGroupApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
            _repository = repository;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create([FromBody] Room room)
        {
            Guid publicId = Guid.Parse(room.GroupId!);
            int id = await _applicationServices.GetIdByPublicId(publicId);

            string role = User.FindFirst($"GroupRole-{id}")?.Value!;

            if (role != "Professor")
            {
                return Forbid();
            }

            await _repository.Create(room);

            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<string>> Index(string groupId) 
        {
            string roomId = await _repository.GetRecentRoomId(groupId);

            return Ok(roomId);
        }
    }
}
