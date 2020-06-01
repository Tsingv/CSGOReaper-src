using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using ScriptKidAntiCheat.Win32;

namespace ScriptKidAntiCheat.Utils
{
	// Token: 0x02000044 RID: 68
	internal static class MemoryRead
	{
		// Token: 0x0600010D RID: 269 RVA: 0x00008DDE File Offset: 0x00006FDE
		public static T Read<[IsUnmanaged] T>(this Process process, IntPtr lpBaseAddress) where T : struct, ValueType
		{
			return MemoryRead.Read<T>(process.Handle, lpBaseAddress);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00008DEC File Offset: 0x00006FEC
		public static T Read<[IsUnmanaged] T>(this Module module, int offset) where T : struct, ValueType
		{
			if (module != null)
			{
				return MemoryRead.Read<T>(module.Process.Handle, module.ProcessModule.BaseAddress + offset);
			}
			return default(T);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00008E27 File Offset: 0x00007027
		public static string ReadString(this Module module, int offset, int bytesToRead)
		{
			return MemoryRead.ReadString(module.Process.Handle, module.ProcessModule.BaseAddress + offset, bytesToRead);
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00008E4C File Offset: 0x0000704C
		public static T Read<[IsUnmanaged] T>(IntPtr hProcess, IntPtr lpBaseAddress) where T : struct, ValueType
		{
			int num = Marshal.SizeOf<T>();
			object obj = default(T);
			if (!Program.GameProcess.IsValid)
			{
				return default(T);
			}
			int num2;
			Kernel32.ReadProcessMemory(hProcess, lpBaseAddress, obj, num, out num2);
			if (num2 != num)
			{
				return default(T);
			}
			return (T)((object)obj);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00008EA4 File Offset: 0x000070A4
		public static string ReadString(IntPtr hProcess, IntPtr BaseAddress, int bytesToRead)
		{
			byte[] array = new byte[bytesToRead];
			int num;
			Kernel32.ReadProcessMemory(hProcess, BaseAddress, array, bytesToRead, out num);
			if (num == bytesToRead)
			{
				return Encoding.UTF8.GetString(array);
			}
			return null;
		}
	}
}
