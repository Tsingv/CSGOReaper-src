using System;

namespace ScriptKidAntiCheat.Win32.Data
{
	// Token: 0x0200001E RID: 30
	[Flags]
	public enum KeyboardEventFlags : uint
	{
		// Token: 0x04000108 RID: 264
		KEYEVENTF_EXTENDEDKEY = 1U,
		// Token: 0x04000109 RID: 265
		KEYEVENTF_KEYUP = 2U,
		// Token: 0x0400010A RID: 266
		KEYEVENTF_SCANCODE = 4U,
		// Token: 0x0400010B RID: 267
		KEYEVENTF_UNICODE = 8U
	}
}
