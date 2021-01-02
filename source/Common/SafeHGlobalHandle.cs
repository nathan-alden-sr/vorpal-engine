using System;
using System.Runtime.InteropServices;

namespace NathanAldenSr.VorpalEngine.Common
{
    /// <summary>
    ///     A safe handle that wraps allocations made with <see cref="Marshal.AllocHGlobal(int)" /> or
    ///     <see cref="Marshal.AllocHGlobal(IntPtr)" />.
    /// </summary>
    public class SafeHGlobalHandle : SafeHandle
    {
        /// <summary>Initializes a new instance of the <see cref="SafeHGlobalHandle" /> class.</summary>
        /// <param name="preexistingHandle">
        ///     A handle returned by <see cref="Marshal.AllocHGlobal(int)" /> or
        ///     <see cref="Marshal.AllocHGlobal(IntPtr)" />.
        /// </param>
        public SafeHGlobalHandle(IntPtr preexistingHandle) : base(IntPtr.Zero, true)
        {
            SetHandle(preexistingHandle);
        }

        /// <inheritdoc />
        public override bool IsInvalid => handle == IntPtr.Zero;

        /// <inheritdoc />
        protected override bool ReleaseHandle()
        {
            Marshal.FreeHGlobal(handle);

            return true;
        }
    }
}