namespace NathanAldenSr.VorpalEngine.Engine.Common
{
    /// <summary>Identifies specific threads used during engine execution.</summary>
    public enum EngineThread
    {
        /// <summary>The update thread handles the Windows message pump, input state, and game state updates.</summary>
        Update,

        /// <summary>The render thread handles rendering.</summary>
        Render
    }
}