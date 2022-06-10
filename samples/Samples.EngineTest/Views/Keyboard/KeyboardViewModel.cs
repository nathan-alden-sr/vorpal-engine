using Stylet;
using VorpalEngine.Input.Keyboard;

namespace VorpalEngine.Samples.EngineTest.Views.Keyboard;

public sealed class KeyboardViewModel : Screen
{
    private readonly IKeyboardManager _keyboardManager;

    public KeyboardViewModel(IKeyboardManager keyboardManager)
    {
        ThrowIfNull(keyboardManager);

        _keyboardManager = keyboardManager;
    }
}
