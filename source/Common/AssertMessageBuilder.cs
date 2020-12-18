using System.Text;

namespace NathanAldenSr.VorpalEngine.Common
{
    /// <summary>Builds assert messages.</summary>
    public class AssertMessageBuilder
    {
        private readonly StringBuilder _stringBuilder = new();

        /// <summary>Appends a message.</summary>
        /// <param name="message">The message to append.</param>
        /// <returns>This object.</returns>
        public AssertMessageBuilder Message(string message)
        {
            if (_stringBuilder.Length > 0)
            {
                _stringBuilder.AppendLine();
            }
            _stringBuilder.Append(message);

            return this;
        }

        /// <summary>Appends a parameter.</summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>This object.</returns>
        public AssertMessageBuilder Parameter(string name, object? value = null) => Message($"{name}: {value ?? "<null>"}");

        /// <summary>Builds the message.</summary>
        /// <returns>The message.</returns>
        public string Build() => _stringBuilder.ToString();
    }
}