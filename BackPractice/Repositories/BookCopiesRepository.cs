using BackPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace BackPractice.Repositories;

public class BookCopiesRepository : EfCoreRepository<BookCopy, LibraryDbContext>
{
    public BookCopiesRepository(LibraryDbContext context) : base(context) {}

    public override async Task<BookCopy?> Get(Guid id)
    {
        await Context.Set<Book>().LoadAsync();
        return await base.Get(id);
    }

    public override async Task<List<BookCopy>> GetAll()
    {
        await Context.Set<Book>().LoadAsync();
        return await base.GetAll();
    }
    
    public async Task<List<BookCopy>> GetBookOfDebtors()
    {
        await Context.Books
            .Include(e => e.Author)
            .Include(e => e.Publisher)
            .LoadAsync();
        return await Context.Set<BorrowedBook>()
            .Include(e => e.Reader)
            .Where(e => e.ReturnTo < DateTime.Now && e.ReturnedAt == null)
            .Select(e => e.BookCopy)
            .ToListAsync();
    }
}