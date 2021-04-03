using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace NathanAldenSr.VorpalEngine.Input.Controller.Hid
{
    /// <summary>The value of A HID value.</summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    [SuppressMessage("ReSharper", "ConvertToAutoPropertyWhenPossible")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Roslyn is over-aggressive")]
    public readonly struct HidControllerStateValue
    {
        private readonly bool _isValid;
        private readonly int _logicalMinimum;
        private readonly int _logicalMaximum;
        private readonly int _value;

        /// <summary>Initializes a new instance of the <see cref="HidControllerStateValue" /> struct.</summary>
        /// <param name="isValid">Indicates whether the value is valid.</param>
        /// <param name="logicalMinimum">The logical minimum value.</param>
        /// <param name="logicalMaximum">The logical maximum value.</param>
        /// <param name="value">The value of the HID value.</param>
        public HidControllerStateValue(bool isValid, int logicalMinimum, int logicalMaximum, int value)
        {
            _isValid = isValid;
            _logicalMinimum = logicalMinimum;
            _logicalMaximum = logicalMaximum;
            _value = value;
        }

        /// <summary>Gets a value indicating if this value is valid.</summary>
        public bool IsValid => _isValid;

        /// <summary>The logical minimum value.</summary>
        public int LogicalMinimum => _logicalMinimum;

        /// <summary>The logical maximum value.</summary>
        public int LogicalMaximum => _logicalMaximum;

        /// <summary>Gets the value of the HID value.</summary>
        public int Value => _value;

        private string DebuggerDisplay => $"IsValid = {_isValid}, Minimum = {_logicalMinimum}, Maximum = {_logicalMaximum}, Value = {_value}";
    }
}