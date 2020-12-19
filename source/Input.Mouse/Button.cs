namespace NathanAldenSr.VorpalEngine.Input.Mouse
{
    /// <summary>Mouse buttons.</summary>
    public enum Button : byte
    {
        /// <summary>The left mouse button, or <see cref="One" />.</summary>
        Left,

        /// <summary>The right mouse button, or <see cref="Two" />.</summary>
        Right,

        /// <summary>The middle mouse button, or <see cref="Three" />.</summary>
        Middle,

        /// <summary>The X1 button, or <see cref="Four" />.</summary>
        X1,

        /// <summary>The X2 button, or <see cref="Five" />.</summary>
        X2,

        /// <summary>The first mouse button, or <see cref="Left" />.</summary>
        One = Left,

        /// <summary>The second mouse button, or <see cref="Right" />.</summary>
        Two = Right,

        /// <summary>The third mouse button, or <see cref="Middle" />.</summary>
        Three = Middle,

        /// <summary>The fourth mouse button, or <see cref="X1" />.</summary>
        Four = X1,

        /// <summary>The fifth mouse button, or <see cref="X2" />.</summary>
        Five = X2
    }
}