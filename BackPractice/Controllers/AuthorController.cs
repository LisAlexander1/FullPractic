using BackPractice.Extensions;
using BackPractice.Models;
using BackPractice.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BackPractice.Controllers;

[Route("authors")]
public class AuthorController : CrudController<AuthorsRepository, Author>
{
    public AuthorController(AuthorsRepository repository) : base(repository)
    {
    }
    
    [HttpGet("{id:guid}/books")]
    public async Task<IActionResult> GetAuthorBooks(Guid id, int page = 1)
    {
        var books = await Repository.GetAuthorBooks(id);
        if (books.Count == 0)
            return NotFound();
        return Ok(books.AsQueryable().GetPaged(page, 10));
    }
}