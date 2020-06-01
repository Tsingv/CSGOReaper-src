using System;
using System.Runtime.InteropServices;
using ScriptKidAntiCheat.Win32;
using ScriptKidAntiCheat.Win32.Data;

namespace ScriptKidAntiCheat.Utils
{
	// Token: 0x02000049 RID: 73
	public static class SendInput
	{
		// Token: 0x0600011C RID: 284 RVA: 0x00009060 File Offset: 0x00007260
		public static void KeyDown(KeyCode key)
		{
			ushort wScan = User32.MapVirtualKey(key, 0U);
			Input input = default(Input);
			input.type = SendInputEventType.InputKeyboard;
			input.ki.wScan = wScan;
			input.ki.dwFlags = KeyboardEventFlags.KEYEVENTF_UNICODE;
			Input input2 = input;
			User32.SendInput(1U, ref input2, Marshal.SizeOf<Input>());
		}

		// Token: 0x0600011D RID: 285 RVA: 0x000090B0 File Offset: 0x000072B0
		public static void KeyUp(KeyCode key)
		{
			ushort wScan = User32.MapVirtualKey(key, 0U);
			Input input = default(Input);
			input.type = SendInputEventType.InputKeyboard;
			input.ki.wScan = wScan;
			input.ki.dwFlags = (KeyboardEventFlags.KEYEVENTF_KEYUP | KeyboardEventFlags.KEYEVENTF_UNICODE);
			Input input2 = input;
			User32.SendInput(1U, ref input2, Marshal.SizeOf<Input>());
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00009100 File Offset: 0x00007300
		public static void KeyPress(KeyCode key)
		{
			SendInput.KeyDown(key);
			SendInput.KeyUp(key);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00009110 File Offset: 0x00007310
		public static void MouseLeftDown()
		{
			Input input = default(Input);
			input.type = SendInputEventType.InputMouse;
			input.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTDOWN;
			Input input2 = input;
			User32.SendInput(1U, ref input2, Marshal.SizeOf<Input>());
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000914C File Offset: 0x0000734C
		public static void MouseLeftUp()
		{
			Input input = default(Input);
			input.type = SendInputEventType.InputMouse;
			input.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTUP;
			Input input2 = input;
			User32.SendInput(1U, ref input2, Marshal.SizeOf<Input>());
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00009188 File Offset: 0x00007388
		public static void MouseRightDown()
		{
			Input input = default(Input);
			input.type = SendInputEventType.InputMouse;
			input.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_RIGHTDOWN;
			Input input2 = input;
			User32.SendInput(1U, ref input2, Marshal.SizeOf<Input>());
		}

		// Token: 0x06000122 RID: 290 RVA: 0x000091C4 File Offset: 0x000073C4
		public static void MouseRightUp()
		{
			Input input = default(Input);
			input.type = SendInputEventType.InputMouse;
			input.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_RIGHTUP;
			Input input2 = input;
			User32.SendInput(1U, ref input2, Marshal.SizeOf<Input>());
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000091FF File Offset: 0x000073FF
		public static void MouseMove(int x, int y)
		{
			User32.mouse_event(Helper.MOUSEEVENTF_MOVE, x, y, 0, 0);
		}
	}
}
