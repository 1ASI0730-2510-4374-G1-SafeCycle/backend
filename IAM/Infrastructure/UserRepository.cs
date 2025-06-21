using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using backend.IAM.Domain.Model.Aggregates;
using backend.IAM.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.IAM.Infrastructure;

public class UserRepository(SafecycleDBContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await Context.Set<User>()
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<User?> FindUserByEmail(string email)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(f => f.Email == email);
    }

    public async Task<IEnumerable<User>> FindUsersByType(string typeUser)
    {
       return await Context.Set<User>().Where(f => f.TypeUser == typeUser).ToListAsync();
    }

    public async Task<User?> FindUserByEmailAndPassword(string email,string password)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(f => f.Password == password && f.Email == email);
    }
}