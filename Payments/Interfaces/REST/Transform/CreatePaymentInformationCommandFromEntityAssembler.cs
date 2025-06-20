﻿using backend.Payments.Domain.Model.Commands;
using backend.Payments.Interfaces.REST.Resources;

namespace backend.Payment.Interfaces.REST.Transform;

public static class CreatePaymentInformationCommandFromEntityAssembler
{
    public static CreatePaymentInformationCommand ToCommandFromResource(this CreatePaymentInformationResource resource)
    {
        return new CreatePaymentInformationCommand(resource.cardNumber, resource.holder, resource.type, resource.amount,
            resource.userId);
    }
}