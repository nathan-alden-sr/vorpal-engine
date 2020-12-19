using NathanAldenSr.VorpalEngine.Common;

namespace NathanAldenSr.VorpalEngine.Input.Controllers.Hid
{
    /// <summary>A factory for creating <see cref="IHidControllerManager" /> objects.</summary>
    public class HidControllerManagerFactory : IHidControllerManagerFactory
    {
        private readonly IHidControllerRepository _hidControllerRepository;

        /// <summary>Initializes a new instance of the <see cref="HidControllerManagerFactory" /> class.</summary>
        /// <param name="hidControllerRepository">An <see cref="IHidControllerRepository" /> implementation.</param>
        public HidControllerManagerFactory(IHidControllerRepository hidControllerRepository)
        {
            _hidControllerRepository = hidControllerRepository;
        }

        /// <inheritdoc />
        public IHidControllerManager Create(NestedContext context = default) => new HidControllerManager(_hidControllerRepository, context);
    }
}