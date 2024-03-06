using Domain.Modules.Base.Enums;
using System.Linq.Expressions;

namespace Domain.Modules.Base.Extensions
{
    [Serializable]
    public static class OrderSortExtensions
    {
        public static IOrderedQueryable<T> OrderByTypeSort<T, TKey>(this IQueryable<T> qry, Expression<Func<T, TKey>> expr, OrderSortEnum orderSortEnum)
        {
            if (orderSortEnum == OrderSortEnum.Asc)
                return qry.OrderBy(expr);
            else
                return qry.OrderByDescending(expr);
        }
    }
}