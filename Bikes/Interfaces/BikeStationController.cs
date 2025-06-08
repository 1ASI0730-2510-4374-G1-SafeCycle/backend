using System.Net.Mime;
using backend.Bike_Management.Domain.Model.Queries;
using backend.Bike_Management.Domain.Services;
using backend.Bikes.Interfaces.REST.Resources;
using backend.Bikes.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend.Bikes.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Favorite Sources API")]
public class BikeStationController(IBikeStationCommandService bikeStationCommandService, IBikeStationQueryService bikeStationQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a Bike Station",
        Description = "Creates a Bike Station",
        OperationId = "CreateBikeStation"
    )]
    [SwaggerResponse(201, "The Bike Station was created successfully.")]
    [SwaggerResponse(400, "The Bike Station was not created.")]
    public async Task<ActionResult> CreateBikeStation([FromBody] CreateBikeStationResource resource)
    {
        var createBikeStationSourceCommand = CreateBikeStationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await bikeStationCommandService.Handle(createBikeStationSourceCommand);
        if(result is null) return BadRequest();
        
        return CreatedAtAction(nameof(GetBikesStationById), new { id = result.Id }, 
            BikeStationResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Gets a bike station according to id",
        Description = "Gets a bike station according to id",
        OperationId = "GetBikesStationById"
    )]
    public async Task<ActionResult> GetBikesStationById(int id)
    {
        var getBikeStationById = new GetBikeStationByIdQuery(id);
        var result = await bikeStationQueryService.Handle(getBikeStationById);
        if (result is null) return NotFound();
        var resource = BikeStationResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
}
