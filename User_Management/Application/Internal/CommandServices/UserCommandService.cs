using backend.Shared.Domain.Repositories;
using backend.User_Management.Domain.Model.Aggregates;
using backend.User_Management.Domain.Model.Commands;
using backend.User_Management.Domain.Repositories;
using backend.User_Management.Domain.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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

    public async Task Handle(DeleteUserCommand command)
    {
        var user = await userRepository.FindByIdAsync(command.id);
        
        if(user == null)
            throw new Exception($"User with id {command.id} doesnt exists.");
        try
        {
            userRepository.Remove(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"User with id {command.id} doesnt exists.", e);
        }
        
    }
}