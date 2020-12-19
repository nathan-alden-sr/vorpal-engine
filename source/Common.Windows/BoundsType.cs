namespace NathanAldenSr.VorpalEngine.Common.Windows
{
    /// <summary>Discriminates between non-client and client bounds.</summary>
    public enum BoundsType
    {
        /// <summary>The bounds are non-client bounds. Non-client bounds include the window border and caption.</summary>
        NonClient,

        /// <summary>The bounds are client bounds. Client bounds include the area inside the window border and caption.</summary>
        Client
    }
}