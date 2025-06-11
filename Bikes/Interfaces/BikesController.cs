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

    [HttpGet("´{id}")]
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
}