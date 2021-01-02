using NathanAldenSr.VorpalEngine.Common;

namespace NathanAldenSr.VorpalEngine.Configuration.Paths
{
    /// <summary>Represents path resolution.</summary>
    public interface IPathManager
    {
        /// <summary>Gets paths for a particular identifier.</summary>
        /// <param name="identifier">An identifier.</param>
        /// <returns>An interface that represents paths for the specified identifier.</returns>
        IIdentifierPaths GetIdentifierPaths(Identifier identifier);
    }
}