// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Data;
using System.Runtime.InteropServices;
using TerraFX.Interop;
using VorpalEngine.Input.Controller.Hid;
using VorpalEngine.Samples.ConsoleHelpers;
using static TerraFX.Interop.Windows;

namespace VorpalEngine.Samples.HidControllerTest;

internal static class Program
{
    private static readonly ConsoleHelper ConsoleHelper = new("HID Controller Test Application", 130, 30, 1000);
    private static IHidControllerManager _hidControllerManager = default!;
    private static readonly DataTable ValuesDataTable = new();

    private static unsafe void Main()
    {
        ValuesDataTable.Columns.AddRange(
            new (string columnName, string caption)[]
                {
                    ("ValueType", ""),
                    ("IsValid", "Valid?"),
                    ("LogicalMinimum", "Min"),
                    ("Value", "Value"),
                    ("LogicalMaximum", "Max")
                }
                .Select(
                    column =>
                        new DataColumn(column.columnName)
                        {
                            Caption = column.caption,
                            ExtendedProperties =
                            {
                                ("Width", column.caption.Length)
                            }
                        })
                .ToArray());

        HidControllerManagerFactory hidControllerManagerFactory = new(new HidControllerRepository());

        _hidControllerManager = hidControllerManagerFactory.Create();

        // Create message-only window

        IntPtr moduleHandle = GetModuleHandle(null);
        var className = $"{typeof(Program).FullName}.{(long)moduleHandle:X16}";
        const string title = "HID Controller Test Application";
        IntPtr windowHandle = IntPtr.Zero;

        fixed (char* pClassName = className)
        {
            fixed (char* pTitle = title)
            {
                WNDCLASSEXW wndClassExW =
                    new()
                    {
                        cbSize = (uint)sizeof(WNDCLASSEXW),
                        hInstance = moduleHandle,
                        lpfnWndProc = &WindowProc,
                        lpszClassName = (ushort*)pClassName
                    };
                ushort classAtom;

                ThrowIfZero(
                    (uint)(classAtom = RegisterClassExW(&wndClassExW)),
                    nameof(RegisterClassW));

                var exit = false;

                try
                {
                    ThrowIfZero(
                        windowHandle = CreateWindowExW(0, (ushort*)classAtom, (ushort*)pTitle, 0, 0, 0, 0, 0, HWND_MESSAGE, IntPtr.Zero, IntPtr.Zero, null),
                        nameof(CreateWindowExW));

                    // Register Raw Input devices

                    ushort[] usages =
                    {
                        HID_USAGE_GENERIC_GAMEPAD,
                        HID_USAGE_GENERIC_JOYSTICK
                    };
                    RAWINPUTDEVICE* pRawInputDevices = stackalloc RAWINPUTDEVICE[usages.Length];

                    for (uint i = 0; i < usages.Length; i++)
                    {
                        pRawInputDevices[i] =
                            new RAWINPUTDEVICE
                            {
                                dwFlags = RIDEV_INPUTSINK,
                                hwndTarget = windowHandle,
                                usUsage = usages[i],
                                usUsagePage = HID_USAGE_PAGE_GENERIC
                            };
                    }

                    ThrowIfZero(
                        RegisterRawInputDevices(pRawInputDevices, (uint)usages.Length, (uint)sizeof(RAWINPUTDEVICE)),
                        nameof(RegisterRawInputDevices));

                    // Window message pump

                    List<string> descriptionParts = new();

                    while (!ConsoleHelper.IsCanceled && !exit)
                    {
                        MSG msg;

                        while (PeekMessageW(&msg, IntPtr.Zero, 0, 0, PM_REMOVE) != 0)
                        {
                            if (msg.message == WM_QUIT)
                            {
                                exit = true;
                            }

                            _ = TranslateMessage(&msg);
                            DispatchMessage(&msg);
                        }

                        ConsoleHelper.Clear();

                        foreach (uint index in _hidControllerManager.StateChangeIndexes)
                        {
                            bool isStateValid = _hidControllerManager.TryGetState(index, out IHidController? controller, out HidControllerState state);

                            if (controller is not null)
                            {
                                descriptionParts.Clear();

                                if (controller.Manufacturer is not null)
                                {
                                    descriptionParts.Add($"Mfg: {controller.Manufacturer}");
                                }
                                if (controller.ProductName is not null)
                                {
                                    descriptionParts.Add($"Product: {controller.ProductName}");
                                }
                                if (controller.SerialNumber is not null)
                                {
                                    descriptionParts.Add($"SN: {controller.SerialNumber}");
                                }
                                if (descriptionParts.Count == 0)
                                {
                                    descriptionParts.Add(index.ToString());
                                }

                                ConsoleHelper.WriteLine(
                                    new ConsoleContent()
                                        .FormatText(TextFormat.BrightForegroundGreen)
                                        .Text(
                                            $"HID controller {(descriptionParts.Count == 0 ? index : $"({string.Join(", ", descriptionParts)})")} is connected (update counter: {state.UpdateCounter})")
                                        .FormatText(TextFormat.Default));
                                ConsoleHelper.WriteLine();

                                if (isStateValid)
                                {
                                    ConsoleContent content = new();

                                    content.Text("Buttons:   ");

                                    for (byte i = 0; i < controller.ButtonCount; i++)
                                    {
                                        if (state.IsButtonDown(i))
                                        {
                                            content.FormatText(TextFormat.Negative);
                                        }
                                        content.Text(i.ToString());
                                        content.FormatText(TextFormat.Default);
                                        content.Text("   ");
                                    }

                                    ConsoleHelper.WriteLine(content);
                                    ConsoleHelper.WriteLine("Values:");
                                    ConsoleHelper.WriteLine();

                                    ValuesDataTable.Rows.Clear();

                                    static void AddRow(DataTable table, string valueName, HidControllerStateValue stateValue)
                                    {
                                        table.Rows.Add(
                                            valueName,
                                            stateValue.IsValid ? "yes" : "no",
                                            stateValue.LogicalMinimum.ToString(),
                                            stateValue.Value.ToString(),
                                            stateValue.LogicalMaximum.ToString());

                                        foreach (DataColumn column in table.Columns())
                                        {
                                            column.ExtendedProperties["Width"] =
                                                Math.Max(column.Caption.Length, table.Rows().Max(a => ((string)a[column]).Length));
                                        }
                                    }

                                    AddRow(ValuesDataTable, "Hat switch", state.HatSwitch.NewValue);
                                    AddRow(ValuesDataTable, "Directional pad up", state.DirectionalPadUp.NewValue);
                                    AddRow(ValuesDataTable, "Directional pad down", state.DirectionalPadDown.NewValue);
                                    AddRow(ValuesDataTable, "Directional pad left", state.DirectionalPadLeft.NewValue);
                                    AddRow(ValuesDataTable, "Directional pad right", state.DirectionalPadRight.NewValue);
                                    AddRow(ValuesDataTable, "X-axis", state.XAxis.NewValue);
                                    AddRow(ValuesDataTable, "Y-axis", state.YAxis.NewValue);
                                    AddRow(ValuesDataTable, "Z-axis", state.ZAxis.NewValue);
                                    AddRow(ValuesDataTable, "X-axis rotation", state.XAxisRotation.NewValue);
                                    AddRow(ValuesDataTable, "Y-axis rotation", state.YAxisRotation.NewValue);
                                    AddRow(ValuesDataTable, "Z-axis rotation", state.ZAxisRotation.NewValue);

                                    content = new ConsoleContent();

                                    const int padding = 3;

                                    foreach (DataColumn column in ValuesDataTable.Columns)
                                    {
                                        var width = (int)column.ExtendedProperties["Width"]!;

                                        content.Text(column.Caption.PadRight(width + padding));
                                    }

                                    ConsoleHelper.WriteLine(content);

                                    ImmutableArray<(DataColumn column, int width)> columns =
                                        ValuesDataTable.Columns().Select(a => (a, (int)a.ExtendedProperties["Width"]!)).ToImmutableArray();

                                    foreach (DataRow row in ValuesDataTable.Rows)
                                    {
                                        content = new ConsoleContent();

                                        foreach ((DataColumn column, int width) in columns)
                                        {
                                            content.Text(((string)row[column]).PadRight(width + padding));
                                        }

                                        ConsoleHelper.WriteLine(content);
                                    }

                                    ConsoleHelper.WriteLine();
                                }
                            }
                        }

                        ConsoleHelper.Render();
                    }
                }
                finally
                {
                    if (windowHandle != IntPtr.Zero)
                    {
                        _ = DestroyWindow(windowHandle);
                    }
                    _ = UnregisterClassW((ushort*)classAtom, moduleHandle);
                }
            }
        }
    }

    [UnmanagedCallersOnly]
    private static unsafe nint WindowProc(IntPtr hWnd, uint uMsg, nuint wParam, nint lParam)
    {
        switch (uMsg)
        {
            case WM_DESTROY:
                PostQuitMessage(0);
                break;
            case WM_INPUT:
                uint size;

                ThrowIfNotZero(
                    GetRawInputData(lParam, RID_INPUT, null, &size, (uint)sizeof(RAWINPUTHEADER)),
                    nameof(GetRawInputBuffer));

                byte* pBuffer = stackalloc byte[(int)size];
                uint getRawInputBufferData = GetRawInputData(lParam, RID_INPUT, pBuffer, &size, (uint)sizeof(RAWINPUTHEADER));

                if (getRawInputBufferData == unchecked((uint)-1) || getRawInputBufferData != size)
                {
                    ThrowExternalException(nameof(GetRawInputBuffer), unchecked((int)getRawInputBufferData));
                }

                _hidControllerManager.UpdateState((RAWINPUT*)pBuffer);

                break;
        }

        return DefWindowProcW(hWnd, uMsg, wParam, lParam);
    }
}