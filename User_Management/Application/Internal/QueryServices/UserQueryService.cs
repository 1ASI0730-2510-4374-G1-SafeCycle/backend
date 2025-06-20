using backend.User_Management.Domain.Model.Aggregates;
using backend.User_Management.Domain.Model.Queries;
using backend.User_Management.Domain.Repositories;
using backend.User_Management.Domain.Services;

namespace backend.User_Management.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    public async Task<IEnumerable<User?>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }

    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<User?>> Handle(GetUserByTypeUserQuery query)
    {
        return await userRepository.FindUsersByType(query.TypeUser);
    }
}