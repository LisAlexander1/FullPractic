using BackPractice.Extensions;
using BackPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace BackPractice.Repositories;

public class ReadersRepository : EfCoreRepository<Reader, LibraryDbContext>
{
    public ReadersRepository(LibraryDbContext context) : base(context)
    {
        
    }

    public async Task<List<Reader>> GetDebtors()
    {
        await Context.BorrowedBooks.LoadAsync();
        return await Context.Set<BorrowedBook>()
            .Include(e => e.Reader)
            .Where(e => e.ReturnTo < DateTime.Now && e.ReturnedAt == null)
            .Select(e => e.Reader)
            .ToListAsync();
    }
}