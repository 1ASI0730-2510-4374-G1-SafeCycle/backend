using System.Net.Mime;
using backend.User_Management.Domain.Model.Commands;
using backend.User_Management.Domain.Model.Queries;
using backend.User_Management.Domain.Services;
using backend.User_Management.Interfaces.REST.Resources;
using backend.User_Management.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace backend.User_Management.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("User API")]
public class UserController(
    IUserCommandService commandService,
    IUserQueryService userQueryService
    ) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserResource resource)
    {
        var createUserCommand = CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await commandService.Handle(createUserCommand);
        
        if (result == null) return BadRequest();

        return CreatedAtAction(nameof(GetUserById), new { id = result.Id },
            UserResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] int id)
    {
        var getByIdQuery = new GetUserByIdQuery(id);
        var result = await  userQueryService.Handle(getByIdQuery);
        
        if (result == null) return NotFound();
        
        var resource = UserResourceFromEntityAssembler.ToResourceFromEntity(result);
        
        return Ok(resource);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResource>>> GetUsers()
    {
        var getAllQuery = new GetAllUsersQuery();
        var result = await userQueryService.Handle(getAllQuery);
        if (result == null) return NotFound();

        foreach (var user in result)
        {
            UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        }
        
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        var deleteUserCommand = new DeleteUserCommand(id);
        var result = await commandService.Handle(deleteUserCommand);
    
        return NoContent();
    }
}