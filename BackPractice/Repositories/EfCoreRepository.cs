using BackPractice.Extensions;
using BackPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace BackPractice.Repositories;

public abstract class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class, IEntity
    where TContext : DbContext
{
    protected readonly TContext Context;

    protected EfCoreRepository(TContext context)
    {
        Context = context;
    }
    public virtual async Task<TEntity?> Add(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity> Delete(Guid id)
    {
        var entity = await Get(id);
        if (entity == null)
        {
            return entity;
        }

        Context.Set<TEntity>().Remove(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<TEntity?> Get(Guid id)
    {
        return await Context.Set<TEntity>().FirstOrDefaultAsync(p => p.Id == id);
    }

    public virtual async Task<List<TEntity>> GetAll()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity> Update(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return entity;
    }
}