using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;

namespace NathanAldenSr.VorpalEngine.Common
{
    /// <summary>Helper methods for exceptions.</summary>
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class ExceptionHelper
    {
        /// <summary>Throws an <see cref="ObjectDisposedException" />.</summary>
        /// <param name="objectName">The name of the disposed object.</param>
        /// <param name="message">An exception message.</param>
        [DoesNotReturn]
        public static void ThrowObjectDisposedException(string? objectName = null, string? message = null)
        {
            throw new ObjectDisposedException(objectName, message);
        }

        /// <summary>
        ///     Throws an <see cref="InvalidOperationException" /> if <see cref="Thread.CurrentThread" /> is not
        ///     <paramref name="thread" />.
        /// </summary>
        /// <param name="thread">The <see cref="Thread" /> to check against <see cref="Thread.CurrentThread" />.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfCurrentThreadIsNotSuppliedThread(Thread thread)
        {
            if (Thread.CurrentThread != thread)
            {
                ThrowInvalidOperationException("The current thread does not match the supplied thread.");
            }
        }

        /// <summary>Throws an <see cref="InvalidOperationException" />.</summary>
        /// <param name="message">An exception message.</param>
        /// <param name="innerException">An inner exception.</param>
        [DoesNotReturn]
        public static void ThrowInvalidOperationException(string? message = null, Exception? innerException = null) =>
            throw new InvalidOperationException(message, innerException);

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException" />.</summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="actualValue">The value of the parameter that caused the exception.</param>
        [DoesNotReturn]
        public static void ThrowArgumentOutOfRangeException(string? paramName = null, object? actualValue = null) =>
            throw new ArgumentOutOfRangeException(paramName, actualValue, null);

        /// <summary>Throws an <see cref="ArgumentException" />.</summary>
        /// <param name="message">An exception message.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="innerException">An inner exception.</param>
        [DoesNotReturn]
        public static void ThrowArgumentException(string? message = null, string? paramName = null, Exception? innerException = null) =>
            throw new ArgumentException(message, paramName, innerException);

        /// <summary>Throws a <see cref="NotSupportedException" />.</summary>
        /// <param name="message">An exception message.</param>
        /// <param name="innerException">An inner exception.</param>
        [DoesNotReturn]
        public static void ThrowNotSupportedException(string? message = null, Exception? innerException = null) =>
            throw new NotSupportedException(message, innerException);
    }
}