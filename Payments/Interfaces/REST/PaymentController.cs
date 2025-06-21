using System.Net.Mime;
using backend.Payment.Interfaces.REST.Transform;
using backend.Payments.Domain.Model.Queries;
using backend.Payments.Domain.Services;
using backend.Payments.Interfaces.REST.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend.Payments.Interfaces.REST;



[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Payment API")]

public class PaymentController(IPaymentCommandService paymentCommandService, IPaymentQueryService paymentQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Payment",
        Description = "Create a new Payment",
        OperationId = "CreatePayment")]
    [SwaggerResponse(201, "Payment was created successfully.")]
    [SwaggerResponse(400, "Payment was not created")]
    public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentResource resource)
    {
        var createPaymentSourceCommand = CreatePaymentCommandFromEntityAssembler.ToCommandFromResource(resource);
        var result = await paymentCommandService.Handle(createPaymentSourceCommand); 
        if(result is null) return BadRequest();

        return CreatedAtAction(nameof(GetPaymentById), new { id = result.id },
            PaymentResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("by-id/{id}")]
    [SwaggerOperation(Summary = "Gets a Payment according to id", Description = "Gets a Payment according to id",
        OperationId = "GetPaymentById")]
    public async Task<IActionResult> GetPaymentById(int id)
    {
        var getPaymentById = new GetPaymentByIdQuery(id);
        var result = await paymentQueryService.Handle(getPaymentById);
        if (result is null) return NotFound();
        var resource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet("by-price/{price}")]
    [SwaggerOperation(Summary = "Gets a Payment according to price", Description = "Gets a Payment according to price",
        OperationId = "GetPaymentByPrice")]
    public async Task<IActionResult> GetPaymentByPrice(float price)
    {
        var getPaymentByPrice = new GetPaymentByPriceQuery(price);
        var result = await paymentQueryService.Handle(getPaymentByPrice);
        if (result is null) return NotFound();
        var resource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
}