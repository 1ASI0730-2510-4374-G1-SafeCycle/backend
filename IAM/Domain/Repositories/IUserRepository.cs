using backend.Shared.Domain.Repositories;
using backend.IAM.Domain.Model.Aggregates;

namespace backend.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> FindUserByEmail(string email);
    Task<IEnumerable<User>> FindUsersByType(string typeUser);
}