using BackPractice.Extensions;
using BackPractice.Models;
using BackPractice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackPractice.Controllers;

[Route("books")]
public class BookController : CrudController<BooksRepository, Book>
{
    public BookController(BooksRepository repository) : base(repository)
    {
        
    }

    // [HttpGet("{id:guid}/cover")]
    // public async Task<IActionResult> GetCover(Guid id)
    // {
    //     var cover = await Repository.GetCover(id);
    //     return cover!.Length > 0 ? Ok(cover) : NotFound();
    // }

    [HttpGet("published")]
    public async Task<IActionResult> GetByDateRange(DateTime? from, DateTime? to, int page = 1)
    {
        var books = await Repository.GetByDateRange(from ?? DateTime.MinValue, to ?? DateTime.MaxValue);
        return books.Count > 0 ? Ok(books.AsQueryable().GetPaged(1, 10)) : NotFound();
    }
}