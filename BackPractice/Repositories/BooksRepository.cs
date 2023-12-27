using BackPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace BackPractice.Repositories;

public class BooksRepository : EfCoreRepository<Book,LibraryDbContext>
{
    public BooksRepository(LibraryDbContext context) : base(context)
    {
        
    }

    public override async Task<Book?> Get(Guid id)
    {
        await Context.Set<Publisher>().LoadAsync();
        await Context.Set<Author>().LoadAsync();
        return await base.Get(id);
    }

    public override async Task<List<Book>> GetAll()
    {
        await Context.Set<Publisher>().LoadAsync();
        await Context.Set<Author>().LoadAsync();
        return await base.GetAll();
    }

    public async Task<List<Book>> GetByDateRange(DateTime from, DateTime to)
    {
        await Context.Set<Publisher>().LoadAsync();
        await Context.Set<Author>().LoadAsync();
        return await Context.Set<Book>().Where(
            e => from <= e.PublishedAt && e.PublishedAt <= to).ToListAsync();
    }

    // public async Task<byte[]?> GetCover(Guid id)
    // {
    //     var book = await Get(id);
    //     return book!.Cover;
    // }
}