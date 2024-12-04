using Groups.Domain.Models.API;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Groups.Domain.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers;

public interface IUserGroupController
{
    Task<ActionResult<string>> Create(GroupsUsersViewModel users);
    Task<ActionResult<string>> Delete(int id);
    Task<ActionResult<List<GroupsUsers>>> GetByGroupId(int groupId);
    Task<ActionResult<List<GroupsUsers>>> GetByUserId(Guid userId);
    Task<ActionResult<List<ParticipantGroup>>> GetParticipantGroup(Guid userId);
    Task<ActionResult<GroupsUsers>> Index(int id);
    Task<ActionResult<string>> Update(GroupsUsers users);
}
