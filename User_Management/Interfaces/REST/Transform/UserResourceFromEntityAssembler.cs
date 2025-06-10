using backend.User_Management.Domain.Model.Aggregates;
using backend.User_Management.Interfaces.REST.Resources;

namespace backend.User_Management.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
        => new UserResource(entity.Username, entity.Email,
            entity.Password, entity.TypeUser,
            entity.MaxDailyReservationHour,
            entity.IdentificationUser);
}