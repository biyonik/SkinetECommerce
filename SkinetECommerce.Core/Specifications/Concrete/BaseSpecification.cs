using System.Linq.Expressions;
using SkinetECommerce.Core.Specifications.Abstract;

namespace SkinetECommerce.Core.Specifications.Concrete;

public class BaseSpecification<T>: ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; }
    public List<Expression<Func<T, object>>> Includes { get; } = new();

    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    protected void AddInclude(Expression<Func<T, object>> includesExpression)
    {
        Includes.Add(includesExpression);
    }
}