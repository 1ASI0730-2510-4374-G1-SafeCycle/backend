using System.Net.Mime;
using backend.Payment.Domain.Model.Queries;
using backend.Payment.Domain.Services;
using backend.Payment.Interfaces.REST.Resources;
using backend.Payment.Interfaces.REST.Transform;
using backend.Tours.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend.Payment.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("PaymentInformation API")]
public class PaymentInformationController(IPaymentInformationCommandService paymentInformationCommandService, IPaymentInformationQueryService paymentInformationQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Payment Information",
        Description = "Create a new Payment Information",
        OperationId = "CreatePaymentInformation")]
    [SwaggerResponse(201, "Payment Information was created successfully.")]
    [SwaggerResponse(400, "Payment Information was not created")]
    public async Task<IActionResult> CreatePaymentInformation([FromBody] CreatePaymentInformationResource resource)
    {
        var command = CreatePaymentInformationCommandFromEntityAssembler.ToCommandFromResource(resource);
        var result = await paymentInformationCommandService.Handle(command);
        if (result is null) return BadRequest();

        return CreatedAtAction(nameof(GetPaymentInformationById), new { id = result.id },
            PaymentInformationResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("by-id/{id}")]
    [SwaggerOperation(
        Summary = "Get a Payment Information by ID",
        Description = "Get a Payment Information by ID",
        OperationId = "GetPaymentInformationById"
    )]
    [SwaggerResponse(200, "Information found.")]
    [SwaggerResponse(404, "Information not found.")]
    public async Task<ActionResult> GetPaymentInformationById(int id)
    {
        var getPaymentInformationById = new GetPaymentInformationByIdQuery(id);
        var result = await paymentInformationQueryService.Handle(getPaymentInformationById);
        if (result is null) return NotFound();
        var resource = PaymentInformationResourceFromEntityAssembler.ToResourceFromEntity(result);
        
        return Ok(resource);
    }
    
    [HttpGet("by-holder/{holder}")]
    [SwaggerOperation(
        Summary = "Get a Payment Information by its holder",
        Description = "Get a Payment Information by its holder",
        OperationId = "GetPaymentInformationByHolder"
    )]
    [SwaggerResponse(200, "Information found.")]
    [SwaggerResponse(404, "Information not found.")]
    public async Task<ActionResult> GetPaymentInformationByHolder(string holder)
    {
        var getPaymentInformationByHolder = new GetPaymentInformationByHolderQuery(holder);
        var result = await paymentInformationQueryService.Handle(getPaymentInformationByHolder);
        if (result is null) return NotFound();
        var resource = PaymentInformationResourceFromEntityAssembler.ToResourceFromEntity(result);
        
        return Ok(resource);
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update a Information of Payments",
        Description = "Update a Information of Payments",
        OperationId = "UpdatePaymentInformation"
    )]
    [SwaggerResponse(200, "The Information was updated successfully.")]
    [SwaggerResponse(404, "Information not found.")]
    public async Task<ActionResult> UpdateTour(int id, [FromBody] UpdatePaymentInformationResource resource)
    {
        var command = UpdatePaymentInformationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await paymentInformationCommandService.Handle(command);
        if (result is null) return NotFound();

        return Ok(PaymentInformationResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
}