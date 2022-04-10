// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Common.Windows;

/// <summary>Border styles for windows.</summary>
public enum BorderStyle
{
    /// <summary>A border is displayed that allows for user resizing of the window.</summary>
    Sizable,

    /// <summary>A border is displayed but the user may not resize the window.</summary>
    NonSizable,

    /// <summary>No border is displayed.</summary>
    None
}
