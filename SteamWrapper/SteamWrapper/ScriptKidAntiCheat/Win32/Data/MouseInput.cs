using System;

namespace ScriptKidAntiCheat.Win32.Data
{
	// Token: 0x02000020 RID: 32
	public struct MouseInput
	{
		// Token: 0x04000119 RID: 281
		public int dx;

		// Token: 0x0400011A RID: 282
		public int dy;

		// Token: 0x0400011B RID: 283
		public uint mouseData;

		// Token: 0x0400011C RID: 284
		public MouseEventFlags dwFlags;

		// Token: 0x0400011D RID: 285
		public uint time;

		// Token: 0x0400011E RID: 286
		public IntPtr dwExtraInfo;
	}
}
