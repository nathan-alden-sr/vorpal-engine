namespace NathanAldenSr.VorpalEngine.EntityComponentSystem
{
    /// <summary>A component.</summary>
    /// <typeparam name="T"></typeparam>
    public readonly struct Component<T>
    {
        /// <summary>Initializes a new instance of the <see cref="Component{T}" /> struct.</summary>
        /// <param name="id">The ID of the component.</param>
        /// <param name="value">The value of the component.</param>
        public Component(int id, T value)
        {
            Id = id;
            Value = value;
        }

        /// <summary>Gets the ID of the component.</summary>
        public int Id { get; }

        /// <summary>Gets the value of the component.</summary>
        public T Value { get; }
    }
}