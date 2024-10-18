using Groups.Domain.Models.SqlServerModels;
using Groups.Domain.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Domain.Interfaces.Controllers;

public interface IGroupController
{
    Task<ActionResult<CreateGroupViewModel>> Create(Courses courses);
    Task<ActionResult<Courses>> GetById(int id);
    Task<ActionResult<List<Courses>>> GetByLevel(string level);
    Task<ActionResult<List<Courses>>> GetByName(string name);
    Task<ActionResult<List<Courses>>> GetByTutorName(string tutor);
    Task<ActionResult<List<GroupsViewModel>>> Groups();
    Task<ActionResult<List<Courses>>> Index();
    Task<ActionResult<string>> Update(Courses courses);
}
