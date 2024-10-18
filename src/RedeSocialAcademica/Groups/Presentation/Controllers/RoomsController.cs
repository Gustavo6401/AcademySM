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
        public RoomsController(RoomsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create([FromBody] Room room)
        {
            string role = User.FindFirst($"GroupRole-{room.GroupId}")?.Value!;

            if (role != "Professor")
            {
                return Forbid();
            }

            await _repository.Create(room);

            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<string>> Index(int groupId) 
        {
            string roomId = await _repository.GetRecentRoomId(groupId);

            return Ok(roomId);
        }
    }
}
