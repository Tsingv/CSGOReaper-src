using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX;

namespace ScriptKidAntiCheat.Internal.Raw
{
	// Token: 0x02000056 RID: 86
	public struct mstudiobbox_t
	{
		// Token: 0x040002F5 RID: 757
		public int bone;

		// Token: 0x040002F6 RID: 758
		public int group;

		// Token: 0x040002F7 RID: 759
		public Vector3 bbmin;

		// Token: 0x040002F8 RID: 760
		public Vector3 bbmax;

		// Token: 0x040002F9 RID: 761
		public int szhitboxnameindex;

		// Token: 0x040002FA RID: 762
		[FixedBuffer(typeof(int), 3)]
		public mstudiobbox_t.<unused>e__FixedBuffer unused;

		// Token: 0x040002FB RID: 763
		public float radius;

		// Token: 0x040002FC RID: 764
		[FixedBuffer(typeof(int), 4)]
		public mstudiobbox_t.<pad>e__FixedBuffer pad;

		// Token: 0x02000057 RID: 87
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 12)]
		public struct <unused>e__FixedBuffer
		{
			// Token: 0x040002FD RID: 765
			public int FixedElementField;
		}

		// Token: 0x02000058 RID: 88
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 16)]
		public struct <pad>e__FixedBuffer
		{
			// Token: 0x040002FE RID: 766
			public int FixedElementField;
		}
	}
}
