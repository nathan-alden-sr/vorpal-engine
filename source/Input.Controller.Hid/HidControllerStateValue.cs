namespace NathanAldenSr.VorpalEngine.Input.Controller.Hid
{
    internal struct HidControllerStateValue
    {
        public HidControllerStateValue(int logicalMinimum, int logicalMaximum, int value)
        {
            // Handles so-called "null" HID values
            IsValid = value >= logicalMinimum && value <= logicalMaximum;

            LogicalMinimum = logicalMinimum;
            LogicalMaximum = logicalMaximum;
            Value = value;
        }

        public bool IsValid;
        public int LogicalMinimum;
        public int LogicalMaximum;
        public int Value;
    }
}