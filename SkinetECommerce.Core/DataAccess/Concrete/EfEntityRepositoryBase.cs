using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SkinetECommerce.Core.DataAccess.Abstract;
using SkinetECommerce.Core.Entities.Abstact;

namespace SkinetECommerce.Core.DataAccess.Concrete;

public class EfEntityRepositoryBase<TEntity, TContext>: IEntityRepository<TEntity>
    where TEntity: class, IEntity, new()
    where TContext: DbContext, new()
{
    public TEntity? Get(Expression<Func<TEntity, bool>> filter)
    {
        using var context = new TContext();
        var entity = context.Set<TEntity>().SingleOrDefault(filter);
        return entity;
    }

    public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
    {
        using var context = new TContext();
        return filter == null
            ? context.Set<TEntity>().ToList()
            : context.Set<TEntity>().Where(filter).ToList();
    }

    public void Add(TEntity entity)
    {
        var context = EntryEntity(entity, out var addedEntity);
        addedEntity.State = EntityState.Added;
        context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        var context = EntryEntity(entity, out var updatedEntity);
        updatedEntity.State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Remove(TEntity entity)
    {
        var context = EntryEntity(entity, out var removedEntity);
        removedEntity.State = EntityState.Deleted;
        context.SaveChanges();
    }
    
    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
    {
        await using var context = new TContext();
        var entity = await context.Set<TEntity>().SingleOrDefaultAsync(filter);
        return entity;
    }

    public async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        await using var context = new TContext();
        return filter == null 
            ? await context.Set<TEntity>().ToListAsync()
            : await context.Set<TEntity>().Where(filter).ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await using var context = new TContext();
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        await using var context = new TContext();
        var updatedEntity = context.Entry(entity);
        updatedEntity.State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(TEntity entity)
    {
        await using var context = new TContext();
        var deletedEntity = context.Entry(entity);
        deletedEntity.State = EntityState.Deleted;
        await context.SaveChangesAsync();
    }
    
    private static TContext EntryEntity(TEntity entity, out EntityEntry<TEntity> baseEntity)
    {
        using var context = new TContext();
        baseEntity = context.Entry(entity);
        return context;
    }
}