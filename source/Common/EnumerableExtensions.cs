using System;
using System.Collections.Generic;
using System.Linq;

namespace NathanAldenSr.VorpalEngine.Common
{
    /// <summary>Extensions for the <see cref="IEnumerable{T}" /> interface.</summary>
    public static class EnumerableExtensions
    {
        /// <summary>Queries two enumerables and returns an enumerable of tuples where the left and right fields indicate matching elements.</summary>
        /// <typeparam name="T">The type of each element.</typeparam>
        /// <param name="left">The left enumerable.</param>
        /// <param name="right">The right enumerable.</param>
        /// <param name="groupByDelegate">A delegate that determines the expression to group on.</param>
        /// <returns>
        ///     An enumerable of tuples where the left and right fields indicate matching elements. <see langword="null" /> indicates
        ///     the particular side did not contain a matching element.
        /// </returns>
        public static IEnumerable<(T? left, T? right)> FullOuterJoin<T>(this IEnumerable<T> left, IEnumerable<T> right, Func<T, object> groupByDelegate)
            where T : class
        {
            return
                left.Select(a => new { position = 0, item = a })
                    .Concat(right.Select(a => new { position = 1, item = a }))
                    .GroupBy(a => groupByDelegate(a.item))
                    .Select(a => (a.FirstOrDefault(y => y.position == 0)?.item, a.FirstOrDefault(y => y.position == 1)?.item));
        }
    }
}