using System.Collections.Generic;
using NathanAldenSr.VorpalEngine.Input.Controller.Hid;

namespace NathanAldenSr.VorpalEngine.Samples.HidControllerTest
{
    public class HidControllerRepository : IHidControllerRepository
    {
        private readonly Dictionary<(string?, string?, string?), uint> _controllers = new();

        public (uint index, bool? enabled, bool enabledDefault) AddHidController(string? manufacturer, string? productName, string? serialNumber)
        {
            if (_controllers.TryGetValue((manufacturer, productName, serialNumber), out uint index))
            {
                return (index, true, true);
            }

            index = (uint)_controllers.Count;

            _controllers.Add((manufacturer, productName, serialNumber), index);

            return (index, true, true);
        }
    }
}