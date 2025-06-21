using backend.IAM.Domain.Model.Aggregates;
using backend.IAM.Domain.Model.Commands;
using Microsoft.AspNetCore.Mvc;

namespace backend.IAM.Domain.Services;

public interface IUserCommandService
{
    Task<User?> Handle(CreateUserCommand command);
    Task Handle(DeleteUserCommand command);
}