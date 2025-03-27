using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.ORM.EntityConfiguration;

public static class Extensions
{
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> where) where T : class
    {
        if (!condition)
            return query;

        return query.Where(where);
    }
}