using BackPractice.Models;
using BackPractice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackPractice.Controllers;

[Route("borrowed-books")]

public class BorrowedBookController : CrudController<BorrowedBooksRepository, BorrowedBook>
{
    public BorrowedBookController(BorrowedBooksRepository repository) : base(repository)
    {
    }
}