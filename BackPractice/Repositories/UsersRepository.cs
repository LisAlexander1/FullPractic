using BackPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace BackPractice.Repositories;

public class UsersRepository : EfCoreRepository<User, LibraryDbContext>
{
    public UsersRepository(LibraryDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByLogin(string login)
    {
        return await Context.Users.FirstOrDefaultAsync(e => e.Login == login);
    }
}