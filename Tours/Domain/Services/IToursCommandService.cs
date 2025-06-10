using backend.Tours.Domain.Model.Commands;

namespace backend.Tours.Domain.Services;

public interface IToursCommandService
{
    Task<Model.Entities.Tours?> Handle(CreateToursCommand command);
    Task<Model.Entities.Tours?> Handle(UpdateToursCommand command);
}