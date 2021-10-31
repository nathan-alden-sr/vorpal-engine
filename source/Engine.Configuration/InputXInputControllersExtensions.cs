// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Engine.Configuration;

/// <summary>Extension methods for the <see cref="InputXInputControllers" /> class.</summary>
public static class InputXInputControllersExtensions
{
    /// <summary>Adds an XInput controller to the <see cref="InputXInputControllers.Controllers" /> list.</summary>
    /// <param name="inputXInputControllers">An <see cref="InputXInputControllers" /> object.</param>
    /// <param name="index">The index of the XInput controller.</param>
    /// <returns>A tuple containing the enabled state of the XInput controller.</returns>
    public static (bool? enabled, bool enabledDefault) Add(this InputXInputControllers inputXInputControllers, byte index)
    {
        ThrowIfNull(inputXInputControllers, nameof(inputXInputControllers));

        IList<InputXInputControllersController> controllers = inputXInputControllers.Controllers();
        InputXInputControllersController? controller = controllers.SingleOrDefault(a => a.Index == index);

        // ReSharper disable once InvertIf
        if (controller is null)
        {
            const bool enabled = true;

            controller =
                new InputXInputControllersController
                {
                    Enabled = enabled,
                    Index = index
                };

            controllers.Add(controller);
        }

        return (controller.Enabled, controller.EnabledDefault);
    }
}