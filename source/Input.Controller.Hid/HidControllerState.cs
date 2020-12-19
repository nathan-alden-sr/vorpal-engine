namespace NathanAldenSr.VorpalEngine.Input.Controller.Hid
{
    internal struct HidControllerState
    {
        public bool IsValid;
        public uint ButtonStates;
        public HidControllerStateValue HatSwitch;
        public HidControllerStateValue DirectionalPadUp;
        public HidControllerStateValue DirectionalPadDown;
        public HidControllerStateValue DirectionalPadLeft;
        public HidControllerStateValue DirectionalPadRight;
        public HidControllerStateValue XAxis;
        public HidControllerStateValue YAxis;
        public HidControllerStateValue ZAxis;
        public HidControllerStateValue XAxisRotation;
        public HidControllerStateValue YAxisRotation;
        public HidControllerStateValue ZAxisRotation;

        public void Reset() => this = default;
    }
}