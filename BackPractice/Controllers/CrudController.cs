using BackPractice.Extensions;
using BackPractice.Models;
using BackPractice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackPractice.Controllers;

[ApiController]
public class CrudController<TRepository, TEntity> : Controller
    where TRepository : IRepository<TEntity>
    where TEntity : class, IEntity
{
    public CrudController(TRepository repository)
    {
        Repository = repository;
    }

    protected TRepository Repository { get; }
    
    [HttpGet]
    public async Task<IActionResult> GetAll(int page = 1)
    {
        var entities = await Repository.GetAll();
        if (entities.Count == 0)
            return NotFound();
        return Ok(entities.AsQueryable().GetPaged(page, 10));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var book = await Repository.Get(id);
        return book is not null ? Ok(book) : NotFound();
    }
   
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TEntity? entity)
    {
        if (entity is null)
            return BadRequest();
        var createdEntity = await Repository.Add(entity);
        if (createdEntity is null)
            return BadRequest();
        return CreatedAtAction(nameof(Get), new {Id = createdEntity.Id}, createdEntity);
    }
   
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] TEntity? entity)
    {
        if (entity is null)
            return BadRequest();
        

        var updatedSale = await Repository.Update(entity);
        return Ok(updatedSale);
    }
}