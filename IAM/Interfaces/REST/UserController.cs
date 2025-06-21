using System.Net.Mime;
using backend.IAM.Domain.Model.Commands;
using backend.IAM.Domain.Model.Queries;
using backend.IAM.Domain.Services;
using backend.IAM.Interfaces.REST.Resources;
using backend.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace backend.IAM.Interfaces.REST;

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
    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetUserByEmail([FromRoute] string email)
    {
        var getByIdQuery = new GetUserByEmailQuery(email);
        var result = await  userQueryService.Handle(getByIdQuery);
        
        if (result == null) return NotFound();
        
        var resource = UserResourceFromEntityAssembler.ToResourceFromEntity(result);
        
        return Ok(resource);
    }
    [HttpGet("secret/{email}/{password}")]
    public async Task<IActionResult> GetUserByEmailAndPassword([FromRoute]string email, [FromRoute]string password)
    {
        var getByEmailAndPasswordQuery = new GetUserByEmailAndPasswordQuery(email,password);
        var result = await  userQueryService.Handle(getByEmailAndPasswordQuery);
        
        if (result == null) return NotFound();
        
        var resource = UserResourceFromEntityAssembler.ToResourceFromEntity(result);
        
        return Ok(resource);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResource>>> GetUsers()
    {
        var getAllQuery = new GetAllUsersQuery();
        var result = await userQueryService.Handle(getAllQuery);

        foreach (var user in result)
        {
            if (user != null) UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        }
        
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        var deleteUserCommand = new DeleteUserCommand(id);
        await commandService.Handle(deleteUserCommand);
    
        return NoContent();
    }
}