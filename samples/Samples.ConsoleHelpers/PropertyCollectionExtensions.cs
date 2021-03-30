using System.Data;

namespace NathanAldenSr.VorpalEngine.Samples.ConsoleHelpers
{
    public static class PropertyCollectionExtensions
    {
        public static void Add(this PropertyCollection propertyCollection, (object Key, object? Value) item) => propertyCollection.Add(item.Key, item.Value);
    }
}