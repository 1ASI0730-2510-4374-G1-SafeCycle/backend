using backend.User_Management.Domain.Model.Aggregates;
using backend.User_Management.Domain.Model.Commands;
using Microsoft.AspNetCore.Mvc;

namespace backend.User_Management.Domain.Services;

public interface IUserCommandService
{
    Task<User?> Handle(CreateUserCommand command);
    Task<IActionResult> Handle(DeleteUserCommand command);
}