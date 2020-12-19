using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using NathanAldenSr.VorpalEngine.Common;
using NathanAldenSr.VorpalEngine.Logging;
using TerraFX.Interop;
using static NathanAldenSr.VorpalEngine.Common.ExceptionHelper;
using static NathanAldenSr.VorpalEngine.Common.Windows.ExceptionHelper;
using static TerraFX.Interop.Windows;

namespace NathanAldenSr.VorpalEngine.Input.Controller.XInput
{
    /// <summary>Manages XInput controller input.</summary>
    public class XInputControllerManager : IXInputControllerManager
    {
        private const int MinimumIndex = 0;
        private const int MaximumIndex = 3;
        private readonly ContextLogger? _logger;
        private readonly IXInputControllerRepository _xInputControllerRepository;
        private readonly Dictionary<byte, XInputController?> _xInputControllersByIndex = new();

        /// <summary>Initializes a new instance of the <see cref="XInputControllerManager" /> class.</summary>
        /// <param name="xInputControllerRepository">An <see cref="IXInputControllerRepository" /> implementation.</param>
        /// <param name="context">A nested context.</param>
        public XInputControllerManager(IXInputControllerRepository xInputControllerRepository, NestedContext context = default)
        {
            context = context.Push<XInputControllerManager>();

            _xInputControllerRepository = xInputControllerRepository;
            _logger = new ContextLogger(context);
        }

        /// <inheritdoc />
        public IReadOnlyCollection<byte> StateChangeIndexes { get; } =
            Enumerable.Range(MinimumIndex, MaximumIndex - MinimumIndex + 1).Select(a => (byte)a).ToImmutableArray();

        /// <inheritdoc />
        public bool TryCalculateStateChanges(byte index, out XInputControllerStateChanges stateChanges)
        {
            ValidateIndex(index);

            if (_xInputControllersByIndex.TryGetValue(index, out XInputController? controller) && controller is object)
            {
                return controller.TryCalculateStateChanges(out stateChanges);
            }

            stateChanges = default;
            return false;
        }

        /// <inheritdoc />
        public void ConfigureControllers()
        {
            for (byte i = MinimumIndex; i <= MaximumIndex; i++)
            {
                ConfigureController(i);
            }
        }

        /// <inheritdoc />
        public void InvalidateController(byte index) => ConfigureController(index);

        private unsafe void ConfigureController(byte index)
        {
            ValidateIndex(index);

            (bool? _, bool enabledDefault) = _xInputControllerRepository.AddXInputController(index);
            XINPUT_CAPABILITIES capabilities;
            uint result = XInputGetCapabilities(index, XINPUT_FLAG_GAMEPAD, &capabilities);
            XInputController? controller = null;

            switch (result)
            {
                case ERROR_SUCCESS:
                    controller =
                        capabilities.Type == XINPUT_DEVTYPE_GAMEPAD && capabilities.SubType == XINPUT_DEVSUBTYPE_GAMEPAD ? new XInputController(index) : null;
                    break;
                case ERROR_DEVICE_NOT_CONNECTED:
                    controller = null;
                    break;
                default:
                    ThrowExternalException(result, nameof(XInputGetCapabilities));
                    break;
            }

            if (controller is null)
            {
                _xInputControllersByIndex[index] = null;

                _logger?.Debug("XInput controller {Index} is disconnected", index);
            }
            else if (!enabledDefault)
            {
                _xInputControllersByIndex[index] = null;

                _logger?.Debug("XInput controller {Index} is connected but disabled", index);
            }
            else
            {
                _xInputControllersByIndex[index] = controller;

                _logger?.Information("XInput controller {Index} is connected and enabled", index);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ValidateIndex(byte index)
        {
            if (index > MaximumIndex)
            {
                ThrowArgumentOutOfRangeException(nameof(index), index);
            }
        }
    }
}