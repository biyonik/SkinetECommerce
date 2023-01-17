using SkinetECommerce.Core.Entities.Abstact;
using SkinetECommerce.Core.Specifications.Abstract;

namespace SkinetECommerce.DataAccess.Specification;

public class SpecificationEvaluator<TEntity> where TEntity: class, IEntity, new()
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
    {
        var query = inputQuery;
        if (specification.Criteria != null)
        {
            query = query.Where(specification.Criteria);
        }

        query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
        return query;
    }
}