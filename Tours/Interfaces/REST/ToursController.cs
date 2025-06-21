using System.Net.Mime;
using backend.Tours.Domain.Model.Queries;
using backend.Tours.Domain.Services;
using backend.Tours.Interfaces.REST.Resources;
using backend.Tours.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend.Tours.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Tour Management API")]
public class TourController(IToursCommandService tourCommandService, IToursQueryService tourQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a Tour",
        Description = "Creates a new Tour",
        OperationId = "CreateTour"
    )]
    [SwaggerResponse(201, "The Tour was created successfully.")]
    [SwaggerResponse(400, "The Tour was not created.")]
    public async Task<ActionResult> CreateTour([FromBody] CreateToursResource resource)
    {
        var command = CreateToursCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await tourCommandService.Handle(command);
        if (result is null) return BadRequest();

        return CreatedAtAction(nameof(GetTourById), new { id = result.Id },
            ToursResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToursResource>>> GetAllTours()
    {
        var getAllQuery = new GetAllToursQuery();
        var result = await tourQueryService.Handle(getAllQuery);

        foreach (var tour in result)
        {
            if (tour != null) ToursResourceFromEntityAssembler.ToResourceFromEntity(tour);
        }
        
        return Ok(result);
    }
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a Tour by ID",
        Description = "Returns the details of a specific Tour",
        OperationId = "GetTourById"
    )]
    [SwaggerResponse(200, "Tour found.")]
    [SwaggerResponse(404, "Tour not found.")]
    public async Task<ActionResult> GetTourById(int id)
    {
        var getTourById = new GetTourByIdQuery(id);
        var result = await tourQueryService.Handle(getTourById);
        if (result is null) return NotFound();
        var resource = ToursResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
        
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update a Tour",
        Description = "Updates an existing Tour",
        OperationId = "UpdateTour"
    )]
    [SwaggerResponse(200, "The Tour was updated successfully.")]
    [SwaggerResponse(404, "Tour not found.")]
    public async Task<ActionResult> UpdateTour(int id, [FromBody] UpdateToursResource resource)
    {
        var command = UpdateToursCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await tourCommandService.Handle(command);
        if (result is null) return NotFound();

        return Ok(ToursResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
}
