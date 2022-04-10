using Moq;
using VorpalEngine.Input.Controller.XInput;
using VorpalEngine.Samples.ConsoleHelpers;

namespace VorpalEngine.Samples.XInputControllerTest;

internal static class Program
{
    private static readonly ConsoleHelper ConsoleHelper = new("XInput Controller Test Application", 130, 32, 32);

    private static async Task Main()
    {
        var xInputControllerRepository = new Mock<IXInputControllerRepository>();

        _ = xInputControllerRepository.Setup(a => a.AddXInputController(It.IsAny<byte>())).Returns((true, true));

        var xInputControllerManagerFactory = new XInputControllerManagerFactory(xInputControllerRepository.Object);
        var xInputControllerManager = xInputControllerManagerFactory.Create();

        xInputControllerManager.ConfigureControllers();

        await DoWorkAsync(xInputControllerManager);
    }

    private static async Task DoWorkAsync(IXInputControllerManager xInputControllerManager)
    {
        while (!ConsoleHelper.IsCanceled)
        {
            ConsoleHelper.Clear();

            foreach (var index in xInputControllerManager.ControllerIndexes)
            {
                var stateIsValid = xInputControllerManager.TryGetState(index, out var state);

                ConsoleHelper.WriteLine(
                    new ConsoleContent()
                        .FormatText(stateIsValid ? TextFormat.BrightForegroundGreen : TextFormat.Default)
                        .Text(
                            $"XInput controller {index + 1} state is {(stateIsValid ? $"valid (update counter: {state.UpdateCounter})" : "invalid")}")
                        .FormatText(TextFormat.Default));
                ConsoleHelper.WriteLine();

                if (!stateIsValid)
                {
                    continue;
                }

                (XInputControllerButton, string)[] directionalPads =
                {
                    (XInputControllerButton.DirectionalPadLeft, "DPad L"),
                    (XInputControllerButton.DirectionalPadUp, "DPad U"),
                    (XInputControllerButton.DirectionalPadRight, "DPad R"),
                    (XInputControllerButton.DirectionalPadDown, "DPad D"), (XInputControllerButton.A, "A"),
                    (XInputControllerButton.B, "B"), (XInputControllerButton.X, "X"), (XInputControllerButton.Y, "Y"),
                    (XInputControllerButton.LeftShoulder, "L Shoulder"), (XInputControllerButton.LeftThumb, "L Thumb"),
                    (XInputControllerButton.RightShoulder, "R Shoulder"), (XInputControllerButton.RightThumb, "R Thumb"),
                    (XInputControllerButton.Back, "Back"), (XInputControllerButton.Start, "Start")
                };

                var content = new ConsoleContent();

                foreach (var (button, label) in directionalPads)
                {
                    if (state.IsButtonDown(button))
                    {
                        _ = content.FormatText(TextFormat.Negative);
                    }

                    _ = content.Text(label).FormatText(TextFormat.Default).Text("   ");
                }

                ConsoleHelper.WriteLine(content);

                ConsoleHelper.WriteLine();
                ConsoleHelper.WriteLine(
                    "L Thumb X-axis   L Thumb Y-axis   L Trigger   R Thumb X-axis   R Thumb Y-axis   R Trigger");

                content = new ConsoleContent();

                _ = content
                    .Text(state.LeftThumbXAxis.NewValue.ToString().PadRight(17))
                    .Text(state.LeftThumbYAxis.NewValue.ToString().PadRight(17))
                    .Text(state.LeftTrigger.NewValue.ToString().PadRight(12))
                    .Text(state.RightThumbXAxis.NewValue.ToString().PadRight(17))
                    .Text(state.RightThumbYAxis.NewValue.ToString().PadRight(17))
                    .Text(state.RightTrigger.NewValue.ToString());

                ConsoleHelper.WriteLine(content);
                ConsoleHelper.WriteLine();
                ConsoleHelper.WriteLine();
            }

            ConsoleHelper.Render();

            await Task.Delay(TimeSpan.FromMilliseconds(10));
        }
    }
}
