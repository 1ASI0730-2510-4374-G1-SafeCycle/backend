using backend.Renting.Domain.Model.Commands;
using backend.Renting.Interfaces.REST.Resources;

namespace backend.Renting.Interfaces.REST.Transform;

public static class DeleteRentCommandFromResourceAssembler
{
    public static DeleteRentCommand ToCommandFromEntity(DeleteRentResource resource)
    {
        return new DeleteRentCommand(resource.userId);
    }
}