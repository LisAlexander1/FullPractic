using BackPractice.Models;
using BackPractice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackPractice.Controllers;

[Route("readers")]
public class ReaderController : CrudController<ReadersRepository, Reader>
{
    public ReaderController(ReadersRepository repository) : base(repository) {}

    [HttpGet("debtors")]
    public async Task<IActionResult> GetDebtors()
    {
        var readers = await Repository.GetDebtors();
        return readers.Count > 0 ? Ok(readers) : NoContent();
    }
}