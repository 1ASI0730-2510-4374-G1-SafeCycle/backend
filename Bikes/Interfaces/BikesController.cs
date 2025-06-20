using System.Net.Mime;
using backend.Bike_Management.Domain.Model.Queries;
using backend.Bike_Management.Domain.Services;
using backend.Bikes.Domain.Services;
using backend.Bikes.Interfaces.REST.Resources;
using backend.Bikes.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend.Bikes.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Bikes API")]

public class BikesController(IBikesCommandService bikesCommandService, IBikesQueryService bikesQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Bike",
        Description = "Create a new Bike",
        OperationId = "CreateBike")]
    [SwaggerResponse(201, "The Bike was created successfully.")]
    [SwaggerResponse(400, "The Bike was not created successfully.")]
    public async Task<ActionResult> CreateBike([FromBody] CreateBikeResource resource)
    {
        var createBikeSourceCommand = CreateBikeCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await bikesCommandService.Handle(createBikeSourceCommand); 
        if(result is null) return BadRequest();
        
        return CreatedAtAction(nameof(GetBikeById), new { id = result.Id }, BikeResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Gets a Bike according to id", Description = "Gets a Bike according to id",
        OperationId = "GetsBikeById")]
    public async Task<ActionResult> GetBikeById(int id)
    {
        var getBikeById = new GetBikeByIdQuery(id);
        var result = await bikesQueryService.Handle(getBikeById);
        if(result is null) return NotFound();
        var resource = BikeResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource); 

    }
    
    [HttpGet("available")]
    [SwaggerOperation(
        Summary = "Get all available bikes",
        Description = "Returns a list of bikes marked as available",
        OperationId = "GetAllAvailableBikes"
    )]
    [SwaggerResponse(200, "List of available bikes retrieved successfully.")]
    public async Task<IActionResult> GetAvailableBikes()
    {
        var result = await bikesQueryService.Handle(new GetAvailableBikesQuery());
        var resources = result.Select(BikeResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update a Bike",
        Description = "Updates the details of an existing Bike",
        OperationId = "UpdateBike"
    )]
    [SwaggerResponse(200, "The Bike was updated successfully.")]
    [SwaggerResponse(400, "Invalid data supplied.")]
    [SwaggerResponse(404, "Bike not found.")]
    public async Task<ActionResult> UpdateBike(int  id, [FromBody] UpdateBikeResource resource)
    {
        var updateCommand = UpdateBikeCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await bikesCommandService.Handle(updateCommand);

        if (result is null) return NotFound();

        return Ok(BikeResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
}