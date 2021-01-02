using System;

namespace NathanAldenSr.VorpalEngine.Common
{
    /// <summary>Extension methods for the <see cref="ListEx{T}" /> class.</summary>
    public static class ListExExtensions
    {
        /// <summary>Removes an item from the list.</summary>
        /// <typeparam name="T">The type of item.</typeparam>
        /// <param name="listEx">A list.</param>
        /// <param name="item">The item to remove.</param>
        /// <returns><see langword="true" /> if the item was removed; otherwise, <see langword="false" />.</returns>
        public static bool Remove<T>(this ListEx<T> listEx, T item)
            where T : IEquatable<T>
        {
            int index = listEx.AsSpan().IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            listEx.RemoveAt(index);

            return true;
        }

        /// <summary>Removes an item from the list.</summary>
        /// <typeparam name="T">The type of item.</typeparam>
        /// <param name="listEx">A list.</param>
        /// <param name="item">The item to remove.</param>
        /// <returns><see langword="true" /> if the item was removed; otherwise, <see langword="false" />.</returns>
        public static bool Remove<T>(this ListEx<T> listEx, in T item)
            where T : IEquatable<T>
        {
            int index = listEx.AsSpan().IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            listEx.RemoveAt(index);

            return true;
        }

        /// <summary>Determines if the list contains an item.</summary>
        /// <typeparam name="T">The type of item.</typeparam>
        /// <param name="listEx">A list.</param>
        /// <param name="item">The item to check.</param>
        /// <returns><see langword="true" /> if the item exists in the list; otherwise, <see langword="false" />.</returns>
        public static bool Contains<T>(this ListEx<T> listEx, T item)
            where T : IEquatable<T> =>
            listEx.IndexOf(item) > -1;

        /// <summary>Gets the index of an item in the list.</summary>
        /// <typeparam name="T">The type of item.</typeparam>
        /// <param name="listEx">A list.</param>
        /// <param name="item">The item whose index is retrieved.</param>
        /// <returns>The index of the item if the item exists in the list; otherwise, <c>-1</c>.</returns>
        public static int IndexOf<T>(this ListEx<T> listEx, T item)
            where T : IEquatable<T> =>
            listEx.AsSpan().IndexOf(item);
    }
}