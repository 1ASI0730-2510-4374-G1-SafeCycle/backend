using System.Net.Mime;
using backend.Tours.Domain.Model.Queries;
using backend.Tours.Domain.Services;
using backend.Tours.Interfaces.REST.Resources;
using backend.Tours.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend.Tours.Interfaces.REST;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("TourBooking Management API")]

public class TourBookingController(ITourBookingCommandService tourBookingCommandService, ITourBookingQueryService tourbookingQueryService): ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a TourBooking",
        Description = "Creates a new TourBooking",
        OperationId = "CreateTourBooking"
    )]
    [SwaggerResponse(201, "The TourBooking was created successfully.")]
    [SwaggerResponse(400, "The TourBooking was not created.")]
    public async Task<ActionResult> CreateTour([FromBody] CreateTourBookingResource resource)
    {
        var command = CreateTourBookingCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await tourBookingCommandService.Handle(command);
        if (result is null) return BadRequest();

        return CreatedAtAction(nameof(GetTourBookingById), new { id = result.Id },
            TourBookingResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TourBookingResource>>> GetAllToursBooking()
    {
        var getAllQuery = new GetAllTourBookingQuery();
        var result = await tourbookingQueryService.Handle(getAllQuery);

        foreach (var booking in result)
        {
            if (booking != null) TourBookingResourceFromEntityAssembler.ToResourceFromEntity(booking);
        }
        
        return Ok(result);
    }
    [HttpGet("{id}")]
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
    
}
