using backend.IAM.Domain.Model.Aggregates;
using backend.IAM.Domain.Model.Queries;
using backend.IAM.Domain.Repositories;
using backend.IAM.Domain.Services;

namespace backend.IAM.Application.Internal.QueryServices;

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