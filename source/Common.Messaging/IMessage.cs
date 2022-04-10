// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Common.Messaging;

/// <summary>Represents a message queue message.</summary>
public interface IMessage
{
    /// <summary>Gets a description of the message.</summary>
    string? Description => null;
}
