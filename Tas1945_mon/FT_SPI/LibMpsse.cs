using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using libMPSSEWrapper.Types;

namespace Tas1945_mon
{
	static class LibMpsse
	{
        private static int _initializations = 0;

        public const string DllName = "libMPSSE.dll";

        public static void Init()
        {
            if (Interlocked.Increment(ref _initializations) == 1)
                Init_libMPSSE();

        }

        public static void Cleanup()
        {
            if (Interlocked.Decrement(ref _initializations) == 0)
                Cleanup_libMPSSE();
        }

        [DllImport(DllName, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        public extern static void Init_libMPSSE();

        [DllImport(DllName, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        public extern static void Cleanup_libMPSSE();
    }
}
