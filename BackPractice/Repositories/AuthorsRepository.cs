using BackPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace BackPractice.Repositories;

public class AuthorsRepository : EfCoreRepository<Author, LibraryDbContext>
{
    public AuthorsRepository(LibraryDbContext context) : base(context)
    {
        
    }

    public async Task<ICollection<Book>> GetAuthorBooks(Guid id)
    {
        await Context.Books.LoadAsync();
        var author = await Get(id);
        return author!.Books;
    }
}