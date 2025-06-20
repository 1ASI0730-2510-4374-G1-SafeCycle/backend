using backend.Tours.Domain.Model.Commands;
using backend.Tours.Interfaces.REST.Resources;

namespace backend.Tours.Interfaces.REST.Transform;

public static class CreateToursCommandFromResourceAssembler
{
    public static CreateToursCommand ToCommandFromResource(this CreateToursResource resource)
    {
        return new CreateToursCommand(resource.name,resource.hour,resource.img,resource.price);
    }
}