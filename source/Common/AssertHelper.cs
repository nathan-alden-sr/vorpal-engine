using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace NathanAldenSr.VorpalEngine.Common
{
    /// <summary>Helper methods for assertions.</summary>
    public static class AssertHelper
    {
        /// <summary>Asserts that a condition is <see langword="true" />.</summary>
        /// <param name="condition">The condition to assert.</param>
        /// <param name="message">The assert message.</param>
        [Conditional("DEBUG")]
        public static void Assert([DoesNotReturnIf(false)] bool condition, string? message = null)
        {
            if (!condition)
            {
                Debug.Assert(condition, message);
            }
        }

        /// <summary>Asserts that a condition is <see langword="true" />.</summary>
        /// <param name="condition">The condition to assert.</param>
        /// <param name="messageBuilder">A message builder that was used to build an assert message.</param>
        [Conditional("DEBUG")]
        public static void Assert([DoesNotReturnIf(false)] bool condition, AssertMessageBuilder messageBuilder)
        {
            if (condition)
            {
                return;
            }

            Debug.Assert(condition, messageBuilder.Build());
        }

        /// <summary>Asserts that a condition is <see langword="true" />.</summary>
        /// <param name="condition">The condition to assert.</param>
        /// <param name="messageBuilderDelegate">A delegate used to build the assert message.</param>
        [Conditional("DEBUG")]
        public static void Assert([DoesNotReturnIf(false)] bool condition, Action<AssertMessageBuilder> messageBuilderDelegate)
        {
            if (condition)
            {
                return;
            }

            var messageBuilder = new AssertMessageBuilder();

            messageBuilderDelegate(messageBuilder);

            Debug.Assert(condition, messageBuilder.Build());
        }

        /// <summary>Asserts that <paramref name="object" /> is not <see langword="null" />.</summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="object">The value that must not be <see langword="null" />.</param>
        /// <param name="objectName">The name of the object.</param>
        [Conditional("DEBUG")]
        public static void AssertNotNull<T>([NotNull] T? @object, string? objectName = null)
            where T : class =>
            Assert(@object is object, $"{(objectName is object ? objectName : "An object")} is null.");

        /// <summary>Asserts that <paramref name="object" /> is not <see langword="null" />.</summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="object">The value that must not be <see langword="null" />.</param>
        /// <param name="objectName">The name of the object.</param>
        [Conditional("DEBUG")]
        public static void AssertNotNull<T>([NotNull] T? @object, string? objectName = null)
            where T : struct =>
            Assert(@object is object, $"{(objectName is object ? objectName : "An object")} is null.");

        /// <summary>Asserts that <paramref name="pointer" /> is not <see langword="null" />.</summary>
        /// <typeparam name="T">The type of the pointer.</typeparam>
        /// <param name="pointer">The pointer that must not be <see langword="null" />.</param>
        /// <param name="pointerName">The name of the pointer.</param>
        [Conditional("DEBUG")]
        public static unsafe void AssertNotNull<T>(T* pointer, string? pointerName = null)
            where T : unmanaged =>
            Assert(pointer != null, $"{(pointerName is object ? pointerName : "A pointer")} is null.");
    }
}