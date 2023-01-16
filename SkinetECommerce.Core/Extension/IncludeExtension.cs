using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SkinetECommerce.Core.Entities.Abstact;

namespace SkinetECommerce.Core.Extension;

public static class IncludeExtension
{
    public static IQueryable<TEntity> IncludeMultiple<TEntity>(this IQueryable<TEntity> query,
        params Expression<Func<TEntity, object>>[]? includeParams)
    where TEntity: class, IEntity, new()
    {
        if (includeParams != null)
        {
            query = includeParams.Aggregate(query, (current, include) => current.Include(include));
        }

        return query;
    }
}