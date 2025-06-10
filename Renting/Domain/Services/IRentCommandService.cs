using backend.Renting.Domain.Model.Aggregates;
using backend.Renting.Domain.Model.Commands;
using backend.User_Management.Domain.Model.Aggregates;
using backend.User_Management.Domain.Model.Commands;

namespace backend.Renting.Domain.Services;

public interface IRentCommandService
{
    Task<Rent?> Handle(CreateRentCommand command);
    Task Handle(RemoveRentCommand command);
}