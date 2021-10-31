// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Engine.Configuration;

/// <summary>Extension methods for the <see cref="InputHidControllers" /> class.</summary>
public static class InputHidControllersExtensions
{
    /// <summary>Adds a HID controller to the <see cref="InputHidControllers.Controllers" /> list.</summary>
    /// <param name="inputHidControllers">An <see cref="InputHidControllers" /> object.</param>
    /// <param name="manufacturer">
    ///     The manufacturer of the HID controller. A <see langword="null" /> value indicates the manufacturer is
    ///     unknown.
    /// </param>
    /// <param name="productName">
    ///     The product name of the HID controller. A <see langword="null" /> value indicates the product name is
    ///     unknown.
    /// </param>
    /// <param name="serialNumber">
    ///     The serial number of the HID controller. A <see langword="null" /> value indicates the serial number
    ///     is unknown.
    /// </param>
    /// <returns>A tuple containing the index and enabled state of the HID controller.</returns>
    public static (uint index, bool? enabled, bool enabledDefault) Add(
        this InputHidControllers inputHidControllers,
        string? manufacturer,
        string? productName,
        string? serialNumber)
    {
        ThrowIfNull(inputHidControllers, nameof(inputHidControllers));

        IList<InputHidControllersController> controllers = inputHidControllers.Controllers();
        InputHidControllersController? controller =
            controllers.SingleOrDefault(
                a => string.Equals(a.Manufacturer, manufacturer, StringComparison.Ordinal) &&
                     string.Equals(a.ProductName, productName, StringComparison.Ordinal) &&
                     string.Equals(a.SerialNumber, serialNumber, StringComparison.Ordinal));

        // ReSharper disable once InvertIf
        if (controller is null)
        {
            const bool enabled = true;
            uint index = controllers.Count > 0 ? controllers.Max(b => b.Index) + 1 : 0;

            controller =
                new InputHidControllersController
                {
                    Enabled = enabled,
                    Index = index,
                    Manufacturer = manufacturer,
                    ProductName = productName,
                    SerialNumber = serialNumber
                };

            controllers.Add(controller);
        }

        return (controller.Index, controller.Enabled, controller.EnabledDefault);
    }
}