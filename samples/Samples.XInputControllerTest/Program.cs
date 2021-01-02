using System;
using System.Threading.Tasks;
using Moq;
using NathanAldenSr.VorpalEngine.Input.Controller.XInput;
using NathanAldenSr.VorpalEngine.Samples.ConsoleHelpers;

namespace NathanAldenSr.VorpalEngine.Samples.XInputControllerTest
{
    internal static class Program
    {
        private static readonly ConsoleHelper ConsoleHelper = new("XInput Controller Test Application", 130, 32);

        private static async Task Main()
        {
            Mock<IXInputControllerRepository> xInputControllerRepository = new();

            xInputControllerRepository.Setup(a => a.AddXInputController(It.IsAny<byte>())).Returns((true, true));

            XInputControllerManagerFactory xInputControllerManagerFactory = new(xInputControllerRepository.Object);
            IXInputControllerManager xInputControllerManager = xInputControllerManagerFactory.Create();

            xInputControllerManager.ConfigureControllers();

            await DoWorkAsync(xInputControllerManager);
        }

        private static async Task DoWorkAsync(IXInputControllerManager xInputControllerManager)
        {
            while (!ConsoleHelper.IsCanceled)
            {
                ConsoleHelper.Clear();

                foreach (byte index in xInputControllerManager.StateChangeIndexes)
                {
                    xInputControllerManager.TryCalculateStateChanges(index, out XInputControllerStateChanges changes);

                    ConsoleHelper.WriteLine(
                        new ConsoleContent()
                            .FormatText(changes.IsConnected ? TextFormat.BrightForegroundGreen : TextFormat.Default)
                            .Text($"XInput controller {index + 1} is {(changes.IsConnected ? "connected" : "disconnected")}")
                            .FormatText(TextFormat.Default));
                    ConsoleHelper.WriteLine();

                    if (!changes.IsConnected)
                    {
                        continue;
                    }

                    (XInputControllerButton, string)[] directionalPads =
                    {
                        (XInputControllerButton.DirectionalPadLeft, "DPad L"),
                        (XInputControllerButton.DirectionalPadUp, "DPad U"),
                        (XInputControllerButton.DirectionalPadRight, "DPad R"),
                        (XInputControllerButton.DirectionalPadDown, "DPad D"),
                        (XInputControllerButton.A, "A"),
                        (XInputControllerButton.B, "B"),
                        (XInputControllerButton.X, "X"),
                        (XInputControllerButton.Y, "Y"),
                        (XInputControllerButton.LeftShoulder, "L Shoulder"),
                        (XInputControllerButton.LeftThumb, "L Thumb"),
                        (XInputControllerButton.RightShoulder, "R Shoulder"),
                        (XInputControllerButton.RightThumb, "R Thumb"),
                        (XInputControllerButton.Back, "Back"),
                        (XInputControllerButton.Start, "Start")
                    };

                    var content = new ConsoleContent();

                    foreach ((XInputControllerButton button, string label) in directionalPads)
                    {
                        if (changes.IsButtonDown(button))
                        {
                            content.FormatText(TextFormat.Negative);
                        }

                        content.Text(label).FormatText(TextFormat.Default).Text("   ");
                    }

                    ConsoleHelper.WriteLine(content);

                    ConsoleHelper.WriteLine();
                    ConsoleHelper.WriteLine("L Thumb X-axis   L Thumb Y-axis   L Trigger   R Thumb X-axis   R Thumb Y-axis   R Trigger");

                    content = new ConsoleContent();

                    content.Text(changes.LeftThumbXAxis.NewValue.ToString().PadRight(17));
                    content.Text(changes.LeftThumbYAxis.NewValue.ToString().PadRight(17));
                    content.Text(changes.LeftTrigger.NewValue.ToString().PadRight(12));
                    content.Text(changes.RightThumbXAxis.NewValue.ToString().PadRight(17));
                    content.Text(changes.RightThumbYAxis.NewValue.ToString().PadRight(17));
                    content.Text(changes.RightTrigger.NewValue.ToString());

                    ConsoleHelper.WriteLine(content);
                    ConsoleHelper.WriteLine();
                    ConsoleHelper.WriteLine();
                }

                ConsoleHelper.Render();

                await Task.Delay(TimeSpan.FromMilliseconds(10));
            }
        }
    }
}