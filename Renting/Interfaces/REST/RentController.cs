using System.Net.Mime;
using backend.Renting.Domain.Services;
using backend.Renting.Interfaces.REST.Resources;
using backend.Renting.Interfaces.REST.Transform;
using backend.Renting.Domain.Model.Queries;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
    [SwaggerOperation(
        Summary = "Create a new Rent",
        Description = "Create a new Rent",
        OperationId = "CreateRent")]
    [SwaggerResponse(201, "The Rent was created successfully.")]
    [SwaggerResponse(400, "The Rent was not created successfully.")]
    public async Task<IActionResult> CreateRent([FromBody] CreateRentResource resource)
    {
        var createRentCommand = CreateRentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await rentCommandService.Handle(createRentCommand);
        
        if(result == null)
            return BadRequest();
        
        return CreatedAtAction(nameof(CreateRent), new { id = result.Id }, RentResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Gets a Rent according to id", Description = "Gets a Rent according to id",
        OperationId = "GetsRentById")]

    public async Task<ActionResult> GetRentById(int id)
    {
        var getRentById = new GetRentByIdQuery(id);
        var result = await rentQueryService.Handle(getRentById);
        if (result is null) return NotFound();
        var resource = RentResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
}