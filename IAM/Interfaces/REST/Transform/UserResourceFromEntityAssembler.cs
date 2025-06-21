using backend.IAM.Domain.Model.Aggregates;
using backend.IAM.Interfaces.REST.Resources;

namespace backend.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
        => new UserResource(entity.Username, entity.Email,
            entity.Password, entity.TypeUser,
            entity.MaxDailyReservationHour,
            entity.IdentificationUser);
}