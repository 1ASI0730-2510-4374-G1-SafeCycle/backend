using backend.IAM.Domain.Model.Commands;
using backend.IAM.Interfaces.REST.Resources;

namespace backend.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(this SignUpResource resource)
    {
        return new SignUpCommand(resource.Username,
            resource.Email,
            resource.Password, 
            resource.TypeUser, 
            resource.MaxDailyReservationHour,
            resource.IdentificationUser
            );
    }
}