using backend.Tours.Domain.Model.Commands;
using backend.Tours.Interfaces.REST.Resources;

namespace backend.Tours.Interfaces.REST.Transform;

public static class UpdateToursCommandFromResourceAssembler
{
    public static UpdateToursCommand ToCommandFromResource(this UpdateToursResource resource)
    {
        return new UpdateToursCommand(resource.Id,resource.name,resource.hour,resource.img,resource.price);
    }
}