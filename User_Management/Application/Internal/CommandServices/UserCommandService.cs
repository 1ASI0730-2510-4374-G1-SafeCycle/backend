using backend.Shared.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using backend.User_Management.Domain.Model.Aggregates;
using backend.User_Management.Domain.Model.Commands;
using backend.User_Management.Domain.Repositories;
using backend.User_Management.Domain.Services;

namespace backend.User_Management.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork) : IUserCommandService
{
    public async Task<User?> Handle(CreateUserCommand command)
    {
        var user = await userRepository.FindUserByEmail(command.Email);
        
        if(user != null)
            throw new Exception($"User with email {command.Email} already exists.");
        
        user = new User(command);

        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return user;
    }
}