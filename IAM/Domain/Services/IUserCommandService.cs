using backend.IAM.Domain.Model.Aggregates;
using backend.IAM.Domain.Model.Commands;
using Microsoft.AspNetCore.Mvc;

namespace backend.IAM.Domain.Services;

public interface IUserCommandService
{
    Task<User?> Handle(SignUpCommand command);
    Task Handle(DeleteUserCommand command);
    Task<(User user, string token)> Handle(SignInCommand command);
}