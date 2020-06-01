using System;

namespace ScriptKidAntiCheat.Win32.Data
{
	// Token: 0x0200001D RID: 29
	public struct KeybdInput
	{
		// Token: 0x04000102 RID: 258
		public KeyCode wVk;

		// Token: 0x04000103 RID: 259
		public ushort wScan;

		// Token: 0x04000104 RID: 260
		public KeyboardEventFlags dwFlags;

		// Token: 0x04000105 RID: 261
		public uint time;

		// Token: 0x04000106 RID: 262
		public IntPtr dwExtraInfo;
	}
}
