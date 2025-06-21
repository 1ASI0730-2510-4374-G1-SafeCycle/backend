using backend.Tours.Domain.Model.Commands;
using backend.Tours.Domain.Model.Entities;

namespace backend.Tours.Domain.Services;

public interface IToursCommandService
{
    Task<Tour?> Handle(CreateToursCommand command);
    Task<Tour?> Handle(UpdateToursCommand command);
}