using System.Net.Mime;
using backend.IAM.Domain.Services;
using backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using backend.IAM.Interfaces.REST.Resources;
using backend.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend.IAM.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[SwaggerTag("Authorization API Controller")]
[Produces(MediaTypeNames.Application.Json)]
public class AuthorizationController(IUserCommandService userCommandService) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInResource signInResource)
    {
        var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(signInResource);
        var authenticatedUser = await userCommandService.Handle(signInCommand);

        var resource = AuthenticatedUserResourceFromEntityAssembler
            .ToResourceFromEntity(authenticatedUser.user, authenticatedUser.token);
        
        return Ok(resource);
    }


    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpResource signUpResource)
    {
        var signUpCommand = SignUpCommandFromResourceAssembler.ToCommandFromResource(signUpResource);
        await userCommandService.Handle(signUpCommand);
        return Ok(new { message = "User created successfully" });
    }

}