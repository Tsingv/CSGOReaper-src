using System;
using System.Runtime.InteropServices;

namespace ScriptKidAntiCheat.Win32
{
	// Token: 0x02000018 RID: 24
	public static class Kernel32
	{
		// Token: 0x0600005F RID: 95
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [MarshalAs(UnmanagedType.AsAny)] [Out] object lpBuffer, int dwSize, out int lpNumberOfBytesRead);
	}
}
