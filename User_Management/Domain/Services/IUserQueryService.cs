using backend.User_Management.Domain.Model.Aggregates;
using backend.User_Management.Domain.Model.Queries;

namespace backend.User_Management.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User?>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByIdQuery query);
    Task<IEnumerable<User?>> Handle(GetUserByTypeUserQuery query);
}