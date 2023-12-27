using BackPractice.Models;
using BackPractice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackPractice.Controllers;


[Route("publishers")]
public class PublisherController : CrudController<PublishersRepository, Publisher>
{
    public PublisherController(PublishersRepository repository) : base(repository)
    {
    }
}