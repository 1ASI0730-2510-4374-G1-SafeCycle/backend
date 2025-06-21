using backend.IAM.Domain.Model.Commands;
using backend.IAM.Interfaces.REST.Resources;

namespace backend.IAM.Interfaces.REST.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(this CreateUserResource resource)
    {
        return new CreateUserCommand(resource.Username,
            resource.Email,
            resource.Password, 
            resource.TypeUser, 
            resource.MaxDailyReservationHour,
            resource.IdentificationUser
            );
    }
}