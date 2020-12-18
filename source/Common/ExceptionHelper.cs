using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using static System.Runtime.InteropServices.Marshal;
using static TerraFX.Interop.Windows;

namespace NathanAldenSr.VorpalEngine.Common
{
    /// <summary>Helper methods for exceptions.</summary>
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class ExceptionHelper
    {
        /// <summary>Throws an <see cref="ExternalException" /> for a specific Win32 error.</summary>
        /// <param name="error">A Win32 error.</param>
        /// <param name="methodName">The name of the method that returned an error.</param>
        [DoesNotReturn]
        public static void ThrowExternalException(int error, string? methodName = null) =>
            throw new ExternalException($"{methodName ?? "A native function invocation"} failed.", error);

        /// <summary>Throws an <see cref="ExternalException" /> for a specific Win32 error.</summary>
        /// <param name="error">A Win32 error.</param>
        /// <param name="methodName">The name of the method that returned an error.</param>
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExternalException(uint error, string? methodName = null) => ThrowExternalException(unchecked((int)error), methodName);

        /// <summary>
        ///     Throws an <see cref="ExternalException" /> for the last Win32 error as reported by the <c>GetLastError</c> function.
        /// </summary>
        /// <param name="methodName">The name of the method that returned an error.</param>
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExternalExceptionForLastWin32Error(string? methodName = null) => ThrowExternalException(GetLastWin32Error(), methodName);

        /// <summary>
        ///     Throws an <see cref="ExternalException" /> for the last HRESULT error as reported by the <c>GetLastError</c> function.
        /// </summary>
        /// <param name="methodName">The name of the method that returned an error.</param>
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExternalExceptionForLastHRESULT(string? methodName = null) => ThrowExternalException(GetHRForLastWin32Error(), methodName);

        /// <summary>Throws an <see cref="ExternalException" /> if <paramref name="predicate" /> evaluates to <see langword="true" />.</summary>
        /// <param name="result">The result of the method invocation.</param>
        /// <param name="predicate">A delegate that determines whether to throw the exception.</param>
        /// <param name="methodName">The name of the method that returned a result.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExternalExceptionIf(int result, Func<int, bool> predicate, string methodName)
        {
            if (predicate(result))
            {
                ThrowExternalExceptionForLastWin32Error(methodName);
            }
        }

        /// <summary>Throws an <see cref="ExternalException" /> if <paramref name="predicate" /> evaluates to <see langword="true" />.</summary>
        /// <param name="result">The result of the method invocation.</param>
        /// <param name="predicate">A delegate that determines whether to throw the exception.</param>
        /// <param name="methodName">The name of the method that returned a result.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExternalExceptionIf(uint result, Func<uint, bool> predicate, string methodName)
        {
            if (predicate(result))
            {
                ThrowExternalExceptionForLastWin32Error(methodName);
            }
        }

        /// <summary>Throws an <see cref="ExternalException" /> if <paramref name="predicate" /> evaluates to <see langword="true" />.</summary>
        /// <param name="result">The result of the method invocation.</param>
        /// <param name="predicate">A delegate that determines whether to throw the exception.</param>
        /// <param name="methodName">The name of the method that returned a result.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExternalExceptionIf(IntPtr result, Func<IntPtr, bool> predicate, string methodName)
        {
            if (predicate(result))
            {
                ThrowExternalExceptionForLastWin32Error(methodName);
            }
        }

        /// <summary>Throws an <see cref="ExternalException" /> if <paramref name="predicate" /> evaluates to <see langword="true" />.</summary>
        /// <param name="result">The result of the method invocation.</param>
        /// <param name="predicate">A delegate that determines whether to throw the exception.</param>
        /// <param name="methodName">The name of the method that returned a result.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExternalExceptionIf(UIntPtr result, Func<UIntPtr, bool> predicate, string methodName)
        {
            if (predicate(result))
            {
                ThrowExternalExceptionForLastWin32Error(methodName);
            }
        }

        /// <summary>
        ///     Throws an <see cref="ExternalException" /> for the last Win32 error if <paramref name="result" /> is
        ///     <see cref="FALSE" />.
        /// </summary>
        /// <param name="result">The result of the method invocation.</param>
        /// <param name="methodName">The name of the method that returned a result.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExternalExceptionIfFalse(int result, string methodName)
        {
            if (result == FALSE)
            {
                ThrowExternalExceptionForLastWin32Error(methodName);
            }
        }

        /// <summary>
        ///     Throws an <see cref="ExternalException" /> for the last Win32 error if <paramref name="result" /> is
        ///     <see cref="FALSE" />.
        /// </summary>
        /// <param name="result">The result of the method invocation.</param>
        /// <param name="methodName">The name of the method that returned a result.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExternalExceptionIfFalse(uint result, string methodName)
        {
            if (result == FALSE)
            {
                ThrowExternalExceptionForLastWin32Error(methodName);
            }
        }

        /// <summary>Throws an <see cref="ExternalException" /> for the last Win32 error if <paramref name="result" /> is zero.</summary>
        /// <param name="result">The result of the method invocation.</param>
        /// <param name="methodName">The name of the method that returned a result.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExternalExceptionIfZero(int result, string methodName)
        {
            if (result == 0)
            {
                ThrowExternalExceptionForLastWin32Error(methodName);
            }
        }

        /// <summary>Throws an <see cref="ExternalException" /> for the last Win32 error if <paramref name="result" /> is zero.</summary>
        /// <param name="result">The result of the method invocation.</param>
        /// <param name="methodName">The name of the method that returned a result.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExternalExceptionIfZero(uint result, string methodName)
        {
            if (result == 0)
            {
                ThrowExternalExceptionForLastWin32Error(methodName);
            }
        }

        /// <summary>Throws an <see cref="ExternalException" /> for the last Win32 error if <paramref name="result" /> is zero.</summary>
        /// <param name="result">The result of the method invocation.</param>
        /// <param name="methodName">The name of the method that returned a result.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExternalExceptionIfZero(IntPtr result, string methodName)
        {
            if (result == IntPtr.Zero)
            {
                ThrowExternalExceptionForLastWin32Error(methodName);
            }
        }

        /// <summary>Throws an <see cref="ExternalException" /> for the last Win32 error if <paramref name="result" /> is zero.</summary>
        /// <param name="result">The result of the method invocation.</param>
        /// <param name="methodName">The name of the method that returned a result.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExternalExceptionIfZero(UIntPtr result, string methodName)
        {
            if (result == UIntPtr.Zero)
            {
                ThrowExternalExceptionForLastWin32Error(methodName);
            }
        }

        /// <summary>Throws an <see cref="ExternalException" /> for the last Win32 error if <paramref name="result" /> is non-zero.</summary>
        /// <param name="result">The result of the method invocation.</param>
        /// <param name="methodName">The name of the method that returned a result.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExternalExceptionIfNonZero(int result, string methodName)
        {
            if (result != 0)
            {
                ThrowExternalExceptionForLastWin32Error(methodName);
            }
        }

        /// <summary>Throws an <see cref="ExternalException" /> for the last Win32 error if <paramref name="result" /> is non-zero.</summary>
        /// <param name="result">The result of the method invocation.</param>
        /// <param name="methodName">The name of the method that returned a result.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExternalExceptionIfNonZero(uint result, string methodName)
        {
            if (result != 0)
            {
                ThrowExternalExceptionForLastWin32Error(methodName);
            }
        }

        /// <summary>Throws an <see cref="ExternalException" /> for the last Win32 error if <paramref name="result" /> is non-zero.</summary>
        /// <param name="result">The result of the method invocation.</param>
        /// <param name="methodName">The name of the method that returned a result.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExternalExceptionIfNonZero(IntPtr result, string methodName)
        {
            if (result != IntPtr.Zero)
            {
                ThrowExternalExceptionForLastWin32Error(methodName);
            }
        }

        /// <summary>Throws an <see cref="ExternalException" /> for the last Win32 error if <paramref name="result" /> is non-zero.</summary>
        /// <param name="result">The result of the method invocation.</param>
        /// <param name="methodName">The name of the method that returned a result.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExternalExceptionIfNonZero(UIntPtr result, string methodName)
        {
            if (result != UIntPtr.Zero)
            {
                ThrowExternalExceptionForLastWin32Error(methodName);
            }
        }

        /// <summary>
        ///     Throws an <see cref="ExternalException" /> if <see cref="FAILED" /> returns <see langword="true" /> for
        ///     <paramref name="result" />.
        /// </summary>
        /// <param name="result">The result of the method invocation.</param>
        /// <param name="methodName">The name of the method that returned a result.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExternalExceptionIfFailed(int result, string methodName)
        {
            if (FAILED(result))
            {
                ThrowExternalException(result, methodName);
            }
        }

        /// <summary>
        ///     Throws an <see cref="ExternalException" /> if <see cref="FAILED" /> returns <see langword="true" /> for
        ///     <paramref name="result" />.
        /// </summary>
        /// <param name="result">The result of the method invocation.</param>
        /// <param name="methodName">The name of the method that returned a result.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExternalExceptionIfFailed(uint result, string methodName)
        {
            if (FAILED(unchecked((int)result)))
            {
                ThrowExternalException(result, methodName);
            }
        }

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