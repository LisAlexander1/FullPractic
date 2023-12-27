using BackPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace BackPractice.Repositories;

public class BorrowedBooksRepository : EfCoreRepository<BorrowedBook, LibraryDbContext>
{
    public BorrowedBooksRepository(LibraryDbContext context) : base(context)
    {
    }

    public override async Task<BorrowedBook?> Get(Guid id)
    {
        await Context.Set<Reader>().LoadAsync();
        await Context.Set<BookCopy>().LoadAsync();

        return await base.Get(id);
    }

    public override async Task<List<BorrowedBook>> GetAll()
    {
        await Context.Set<Reader>().LoadAsync();
        await Context.Set<BookCopy>().LoadAsync();
        
        return await base.GetAll();
    }
}