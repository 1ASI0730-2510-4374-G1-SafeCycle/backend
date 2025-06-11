using System.Net.Mime;
using backend.TourBooking.Domain.Model.Queries;
using backend.TourBooking.Domain.Services;
using backend.TourBooking.Interfaces.REST.Resources;
using backend.TourBooking.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend.TourBooking.Interfaces.REST;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("TourBooking Management API")]

public class TourBookingController(ITourbookingCommandService tourbookingCommandService, ITourBookingQueryService tourbookingQueryService):ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a Tour Booking",
        Description = "Creates a new Tour Booking ",
        OperationId = "CreateTourBooking"
    )]
    [SwaggerResponse(201, "Tour Booking has been created successfully.")]
    [SwaggerResponse(400, "Bad Request, Tour booking is invalid.")]
    public async Task<ActionResult> CreateTourBooking([FromBody] CreateTourBookingResource resource)
    {
        var command = CreateTourBookingCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await tourbookingCommandService.Handle(command);
        if (result is null) return BadRequest();
        
        return CreatedAtAction(nameof(GetTourBookingById), 
            new {id = result.Id}, 
            TourBookingResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpPut("{id:int}")]
    [SwaggerOperation(
        Summary = "Get Tour Booking by Id",
        Description = "Receive the information about a Tour Booking by Id",
        OperationId = "GetTourBookingById"
        )]
    [SwaggerResponse(200, "Tour Booking has been found successfully.")]
    [SwaggerResponse(404, "Tour Booking not found.")]
    public async Task<ActionResult> GetTourBookingById(int id)
    {
        var getTourBookingByIdQuery =  new GetTourBookingByIdQuery(id);
        var result = await tourbookingQueryService.Handle(getTourBookingByIdQuery);
        if (result is null) return NotFound();
        
        return Ok(TourBookingResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpPut("{id:int}")]
    [SwaggerOperation(
        Summary = "Update a Tour Booking by Id",
        Description = "Update a Tour booking by Id",
        OperationId = "UpdateTourBooking"
    )]
    [SwaggerResponse(200, "Tour Booking has been updated successfully.")]
    [SwaggerResponse(400, "Bad Request, Tour booking is invalid.")]
    [SwaggerResponse(404, "Tour Booking not found.")]
    public async Task<ActionResult> UpdateTourBooking([FromBody] UpdateTourBookingResource resource)
    {
        var command = UpdateTourBookingCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await tourbookingCommandService.Handle(command);
        if (result is null) return NotFound();
        
        return Ok(TourBookingResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
}