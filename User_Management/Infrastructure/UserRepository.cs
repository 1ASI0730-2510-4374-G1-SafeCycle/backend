using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using backend.User_Management.Domain.Model.Aggregates;
using backend.User_Management.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.User_Management.Infrastructure;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(SafecycleDBContext context) : base(context)
    {}

    public async Task<User?> FindUserByEmail(string email)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(f => f.Email == email);
    }

    public async Task<IEnumerable<User>> FindUsersByType(string typeUser)
    {
       return await Context.Set<User>().Where(f => f.TypeUser == typeUser).ToListAsync();
    }
}