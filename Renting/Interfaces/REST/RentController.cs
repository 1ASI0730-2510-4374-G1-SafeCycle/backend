using System.Net.Mime;
using backend.Renting.Domain.Services;
using backend.Renting.Interfaces.REST.Resources;
using backend.Renting.Interfaces.REST.Transform;
using backend.User_Management.Interfaces.REST.Resources;
using backend.User_Management.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace backend.Renting.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Rent API")]
public class RentController(
    IRentCommandService rentCommandService,
    IRentQueryService rentQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateRent([FromBody] RentResource resource)
    {
        var createRentCommand = CreateRentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await rentCommandService.Handle(createRentCommand);
        
        if(result == null)
            return BadRequest();
        
        return CreatedAtAction(nameof(CreateRent), new { id = result.Id }, RentResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
}