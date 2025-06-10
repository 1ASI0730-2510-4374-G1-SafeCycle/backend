using backend.Tours.Domain.Model.Commands;

namespace backend.Tours.Domain.Services;

public interface IToursCommandService
{
    Task<Model.Aggregates.Tours?> Handle(CreateToursCommand command);
}