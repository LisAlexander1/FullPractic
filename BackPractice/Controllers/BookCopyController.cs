using BackPractice.Models;
using BackPractice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackPractice.Controllers;

[Route("books/copies")]
public class BookCopyController : CrudController<BookCopiesRepository, BookCopy>
{
    public BookCopyController(BookCopiesRepository repository) : base(repository)
    {
    }

    [HttpGet("debt")]
    public async Task<IActionResult> GetBooksOfDebtors()
    {
        var books = await Repository.GetBookOfDebtors();
        return books.Count > 0 ? Ok(books) : NoContent();
    }
}