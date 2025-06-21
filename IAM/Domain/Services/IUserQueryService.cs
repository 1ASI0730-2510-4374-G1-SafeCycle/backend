using backend.IAM.Domain.Model.Aggregates;
using backend.IAM.Domain.Model.Queries;

namespace backend.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User?>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByIdQuery query);
    Task<IEnumerable<User?>> Handle(GetUserByTypeUserQuery query);
    Task<User?> Handle(GetUserByEmailQuery query);
    Task<User?> Handle(GetUserByEmailAndPasswordQuery query);
}