// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using Microsoft.IO;

namespace VorpalEngine.Common;

/// <summary>Provides a process-wide <see cref="RecyclableMemoryStreamManager" /> object.</summary>
public static class MemoryStreamUtilities
{
    /// <summary>A process-wide <see cref="RecyclableMemoryStreamManager" /> object.</summary>
    public static readonly RecyclableMemoryStreamManager RecyclableMemoryStreamManager = new();
}