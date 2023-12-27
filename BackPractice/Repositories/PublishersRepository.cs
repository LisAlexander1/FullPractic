using BackPractice.Models;

namespace BackPractice.Repositories;

public class PublishersRepository : EfCoreRepository<Publisher, LibraryDbContext>
{
    public PublishersRepository(LibraryDbContext context) : base(context)
    {
        
    }
}