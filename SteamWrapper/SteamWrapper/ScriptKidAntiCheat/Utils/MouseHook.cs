using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ScriptKidAntiCheat.Win32;
using ScriptKidAntiCheat.Win32.Data;

namespace ScriptKidAntiCheat.Utils
{
	// Token: 0x02000045 RID: 69
	public static class MouseHook
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000112 RID: 274 RVA: 0x00008ED8 File Offset: 0x000070D8
		// (remove) Token: 0x06000113 RID: 275 RVA: 0x00008F0C File Offset: 0x0000710C
		public static event EventHandler MouseAction;

		// Token: 0x06000114 RID: 276 RVA: 0x00008F3F File Offset: 0x0000713F
		public static void Start()
		{
			MouseHook._hookID = MouseHook.SetHook(MouseHook._proc);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00008F50 File Offset: 0x00007150
		public static void stop()
		{
			User32.UnhookWindowsHookEx(MouseHook._hookID);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00008F60 File Offset: 0x00007160
		private static IntPtr SetHook(User32.LowLevelMouseProc proc)
		{
			IntPtr result;
			using (Process currentProcess = Process.GetCurrentProcess())
			{
				using (ProcessModule mainModule = currentProcess.MainModule)
				{
					result = User32.SetWindowsHookEx(14, proc, User32.GetModuleHandle(mainModule.ModuleName), 0U);
				}
			}
			return result;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00008FC4 File Offset: 0x000071C4
		private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
		{
			if (nCode >= 0 && (int)wParam != 512)
			{
				MouseHook.MSLLHOOKSTRUCT msllhookstruct = (MouseHook.MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MouseHook.MSLLHOOKSTRUCT));
				MouseHook.MouseAction((MouseHook.MouseEvents)((int)wParam), new EventArgs());
			}
			return User32.CallNextHookEx(MouseHook._hookID, nCode, wParam, lParam);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000901F File Offset: 0x0000721F
		// Note: this type is marked as 'beforefieldinit'.
		static MouseHook()
		{
			MouseHook.MouseAction = delegate(object <p0>, EventArgs <p1>)
			{
			};
			MouseHook._proc = new User32.LowLevelMouseProc(MouseHook.HookCallback);
			MouseHook._hookID = IntPtr.Zero;
		}

		// Token: 0x0400026E RID: 622
		private static User32.LowLevelMouseProc _proc;

		// Token: 0x0400026F RID: 623
		private static IntPtr _hookID;

		// Token: 0x04000270 RID: 624
		private const int WH_MOUSE_LL = 14;

		// Token: 0x02000046 RID: 70
		public enum MouseEvents
		{
			// Token: 0x04000272 RID: 626
			WM_LBUTTONDOWN = 513,
			// Token: 0x04000273 RID: 627
			WM_LBUTTONUP,
			// Token: 0x04000274 RID: 628
			WM_MOUSEMOVE = 512,
			// Token: 0x04000275 RID: 629
			WM_MOUSEWHEEL = 522,
			// Token: 0x04000276 RID: 630
			WM_RBUTTONDOWN = 516,
			// Token: 0x04000277 RID: 631
			WM_RBUTTONUP
		}

		// Token: 0x02000047 RID: 71
		private struct MSLLHOOKSTRUCT
		{
			// Token: 0x04000278 RID: 632
			public Point pt;

			// Token: 0x04000279 RID: 633
			public uint mouseData;

			// Token: 0x0400027A RID: 634
			public uint flags;

			// Token: 0x0400027B RID: 635
			public uint time;

			// Token: 0x0400027C RID: 636
			public IntPtr dwExtraInfo;
		}
	}
}
