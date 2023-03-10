using System.Linq.Expressions;

namespace SkinetECommerce.Core.Specifications.Abstract;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
}