using System;
using System.Diagnostics;

namespace NathanAldenSr.VorpalEngine.Common
{
    /// <summary>A breadcrum of contexts useful for logging purposes.</summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public readonly struct NestedContext
    {
        private const string DefaultSeparator = "->";
        private readonly string? _separator;

        /// <summary>Initializes a new instance of the <see cref="NestedContext" /> struct.</summary>
        /// <param name="context">A new context.</param>
        /// <param name="separator">The separator to use when combining contexts.</param>
        public NestedContext(string? context = null, string separator = DefaultSeparator) : this(null, context, separator)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="NestedContext" /> struct.</summary>
        /// <param name="context">A new context.</param>
        /// <param name="fullName">A value indicating whether to include types' namespaces.</param>
        /// <param name="expandGenericArguments">A value indicating whether to include generic type arguments.</param>
        /// <param name="separator">The separator to use when combining contexts.</param>
        public NestedContext(Type context, bool fullName = false, bool expandGenericArguments = true, string separator = DefaultSeparator)
            : this(context.GetTypeName(fullName, expandGenericArguments), separator)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="NestedContext" /> struct.</summary>
        /// <param name="existingContext">An existing context.</param>
        /// <param name="newContext">A new context.</param>
        public NestedContext(NestedContext existingContext, string? newContext = null)
            : this(existingContext.Description, newContext, existingContext._separator)
        {
            _separator = existingContext._separator;
        }

        private NestedContext(string? description, string? context, string? separator)
        {
            separator ??= DefaultSeparator;

            Description = $"{description}{(!string.IsNullOrEmpty(description) && !string.IsNullOrEmpty(context) ? separator : "")}{context}";
            _separator = separator;
        }

        /// <summary>Gets a description of the context with each context separated by the separator string.</summary>
        public string? Description { get; }

        /// <summary>Gets a valid indicating whether the context is empty.</summary>
        public bool IsEmpty => string.IsNullOrEmpty(Description);

        private string? DebuggerDisplay => Description;

        /// <summary>Creates a new <see cref="NestedContext" /> from the current context and a new context.</summary>
        /// <param name="newContext">A new context.</param>
        /// <returns>A new <see cref="NestedContext" /> that is the combination of the current context and the new context.</returns>
        public NestedContext Push(string newContext) => new(Description, newContext, _separator);

        /// <summary>Creates a new <see cref="NestedContext" /> from the current context and a new context.</summary>
        /// <param name="newContext">A new context.</param>
        /// <param name="fullName">A value indicating whether to include types' namespaces.</param>
        /// <param name="expandGenericArguments">A value indicating whether to include generic type arguments.</param>
        /// <returns>A new <see cref="NestedContext" /> that is the combination of the current context and the new context.</returns>
        public NestedContext Push(Type newContext, bool fullName = false, bool expandGenericArguments = true) =>
            Push(newContext.GetTypeName(fullName, expandGenericArguments));

        /// <summary>Creates a new <see cref="NestedContext" /> from the current context and a new context.</summary>
        /// <typeparam name="T">The new context.</typeparam>
        /// <param name="fullName">A value indicating whether to include types' namespaces.</param>
        /// <param name="expandGenericArguments">A value indicating whether to include generic type arguments.</param>
        /// <returns>A new <see cref="NestedContext" /> that is the combination of the current context and the new context.</returns>
        public NestedContext Push<T>(bool fullName = false, bool expandGenericArguments = true) => Push(typeof(T), fullName, expandGenericArguments);

        /// <summary>Creates a new <see cref="NestedContext" /> with no context.</summary>
        /// <param name="separator">The separator to use when combining contexts.</param>
        /// <returns>A new <see cref="NestedContext" /> with no context.</returns>
        public static NestedContext None(string separator = DefaultSeparator) => new(null, separator);
    }
}