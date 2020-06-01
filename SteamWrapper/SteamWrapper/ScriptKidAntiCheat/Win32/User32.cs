using System;
using System.Runtime.InteropServices;
using ScriptKidAntiCheat.Win32.Data;

namespace ScriptKidAntiCheat.Win32
{
	// Token: 0x02000019 RID: 25
	public static class User32
	{
		// Token: 0x06000060 RID: 96
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool ClientToScreen(IntPtr hWnd, out Point lpPoint);

		// Token: 0x06000061 RID: 97
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool GetClientRect(IntPtr hWnd, out Rect lpRect);

		// Token: 0x06000062 RID: 98
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr GetForegroundWindow();

		// Token: 0x06000063 RID: 99
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		// Token: 0x06000064 RID: 100
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		// Token: 0x06000065 RID: 101
		[DllImport("user32.dll", SetLastError = true)]
		public static extern uint SendInput(uint nInputs, ref Input pInputs, int cbSize);

		// Token: 0x06000066 RID: 102
		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern uint VkKeyScan(char ch);

		// Token: 0x06000067 RID: 103
		[DllImport("user32.dll")]
		public static extern ushort MapVirtualKey(KeyCode uCode, uint uMapType);

		// Token: 0x06000068 RID: 104
		[DllImport("User32.Dll")]
		public static extern long SetCursorPos(int x, int y);

		// Token: 0x06000069 RID: 105
		[DllImport("user32.dll")]
		public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

		// Token: 0x0600006A RID: 106
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr SetWindowsHookEx(int idHook, User32.LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

		// Token: 0x0600006B RID: 107
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UnhookWindowsHookEx(IntPtr hhk);

		// Token: 0x0600006C RID: 108
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

		// Token: 0x0600006D RID: 109
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x0200001A RID: 26
		// (Invoke) Token: 0x0600006F RID: 111
		public delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
	}
}
