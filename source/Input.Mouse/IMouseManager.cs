namespace NathanAldenSr.VorpalEngine.Input.Mouse
{
    /// <summary>Represents mouse input management.</summary>
    public interface IMouseManager
    {
        /// <summary>Calculates state changes for the mouse since the last time this method was called.</summary>
        /// <param name="stateChanges">An <see cref="MouseStateChanges" /> object that will contain the changes in mouse state.</param>
        void CalculateStateChanges(out MouseStateChanges stateChanges);

        /// <summary>Resets the mouse state as if the user released all buttons.</summary>
        void Reset();
    }
}