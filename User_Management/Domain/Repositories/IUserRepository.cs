using backend.Shared.Domain.Repositories;
using backend.User_Management.Domain.Model.Aggregates;

namespace backend.User_Management.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindUserByEmail(string email);
    Task<IEnumerable<User>> FindUsersByType(string typeUser);
}