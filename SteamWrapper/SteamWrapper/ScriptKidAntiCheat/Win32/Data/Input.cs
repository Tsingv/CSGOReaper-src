using System;
using System.Runtime.InteropServices;

namespace ScriptKidAntiCheat.Win32.Data
{
	// Token: 0x0200001C RID: 28
	[StructLayout(LayoutKind.Explicit)]
	public struct Input
	{
		// Token: 0x040000FE RID: 254
		[FieldOffset(0)]
		public SendInputEventType type;

		// Token: 0x040000FF RID: 255
		[FieldOffset(4)]
		public MouseInput mi;

		// Token: 0x04000100 RID: 256
		[FieldOffset(4)]
		public KeybdInput ki;

		// Token: 0x04000101 RID: 257
		[FieldOffset(4)]
		public HardwareInput hi;
	}
}
