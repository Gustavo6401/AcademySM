using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Models.SqlServerModels;
using Groups.Domain.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Presentnation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase, IGroupController
{
    private readonly IGroupApplicationServices _applicationServices;
    public GroupController(IGroupApplicationServices applicationServices)
    {
        _applicationServices = applicationServices;
    }

    [HttpGet("AccessGroup")]
    [Authorize]
    public async Task<ActionResult<GroupsHomeViewModel>> AccessGroup(int id)
    {
        string role = User.FindFirst($"GroupRole-{id}")?.Value!;

        // If the role is null or white space it means that the user is not able to access the group.
        if(string.IsNullOrWhiteSpace(role))
        {
            return StatusCode(403);
        }

        GroupsHomeViewModel? group = await _applicationServices.AccessGroup(id);

        return group!;
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = "CookieAuth")]
    public async Task<ActionResult<CreateGroupViewModel>> Create(Courses courses)
    {
        await _applicationServices.Create(courses);
        int groupId = await _applicationServices.GetIdByName(courses.Name!);

        return Ok(new CreateGroupViewModel { Message = "Grupo Criado com Sucesso!", GroupId = groupId });
    }

    [HttpGet("GetById")]
    [AllowAnonymous]
    public async Task<ActionResult<Courses>> GetById(int id)
    {
        Courses group = await _applicationServices.Get(id);

        return Ok(group);
    }

    /// <summary>
    /// This is one of the various courses filters.
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    [HttpGet("GetByLevel")]
    [AllowAnonymous]
    public async Task<ActionResult<List<Courses>>> GetByLevel(string level)
    {
        List<Courses> list = await _applicationServices.GetByLevel(level);

        return Ok(list);
    }

    [HttpGet("GetByName")]
    [AllowAnonymous]
    public async Task<ActionResult<List<Courses>>> GetByName(string name)
    {
        List<Courses> list = await _applicationServices.GetByName(name);

        return Ok(list);
    }

    [HttpGet("GetByTutorName")]
    [AllowAnonymous]
    public async Task<ActionResult<List<Courses>>> GetByTutorName(string tutor)
    {
        List<Courses> list = await _applicationServices.GetByTutorName(tutor);

        return Ok(list);
    }

    [HttpGet("/Groups")]
    [AllowAnonymous]
    public async Task<ActionResult<List<GroupsViewModel>>> Groups()
    {
        List<GroupsViewModel> list = await _applicationServices.Groups();

        return Ok(list);
    }

    [HttpGet("Index")]
    [AllowAnonymous]
    public async Task<ActionResult<List<Courses>>> Index()
    {
        List<Courses> list = await _applicationServices.GetAll();

        return Ok(list);
    }

    [HttpGet("IsProfessor")]
    [Authorize]
    public ActionResult<bool> IsProfessor(int groupId)
    {
        // This system is based in multiple role values, so when you are loged into a determined user, you can be
        // an Student "Aluno", or a Professor. 

        // This is the main function of User.Find First, this is going to search for user's roles.
        string role = User.FindFirst($"GroupRole-{groupId}")?.Value!;

        if(role != "Professor")
        {
            return Ok(false);
        }

        return Ok(true);
    }

    [HttpPut]
    [Authorize]
    public async Task<ActionResult<string>> Update(Courses courses)
    {
        string groupUserRole = User.FindFirst($"GroupRole-{courses.Id}")?.Value!;

        if(groupUserRole != "Professor")
        {
            return Forbid();
        }

        await _applicationServices.Update(courses);

        return Ok("Cadastro de Grupo Atualizado com Sucesso!");
    }
}
