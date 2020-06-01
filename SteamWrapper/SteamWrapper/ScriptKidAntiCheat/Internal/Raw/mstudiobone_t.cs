using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX;

namespace ScriptKidAntiCheat.Internal.Raw
{
	// Token: 0x02000059 RID: 89
	public struct mstudiobone_t
	{
		// Token: 0x040002FF RID: 767
		public int sznameindex;

		// Token: 0x04000300 RID: 768
		public int parent;

		// Token: 0x04000301 RID: 769
		[FixedBuffer(typeof(int), 6)]
		public mstudiobone_t.<bonecontroller>e__FixedBuffer bonecontroller;

		// Token: 0x04000302 RID: 770
		public Vector3 pos;

		// Token: 0x04000303 RID: 771
		public Quaternion quat;

		// Token: 0x04000304 RID: 772
		public Vector3 rot;

		// Token: 0x04000305 RID: 773
		public Vector3 posscale;

		// Token: 0x04000306 RID: 774
		public Vector3 rotscale;

		// Token: 0x04000307 RID: 775
		public matrix3x4_t poseToBone;

		// Token: 0x04000308 RID: 776
		public Quaternion qAlignment;

		// Token: 0x04000309 RID: 777
		public int flags;

		// Token: 0x0400030A RID: 778
		public int proctype;

		// Token: 0x0400030B RID: 779
		public int procindex;

		// Token: 0x0400030C RID: 780
		public int physicsbone;

		// Token: 0x0400030D RID: 781
		public int surfacepropidx;

		// Token: 0x0400030E RID: 782
		public int contents;

		// Token: 0x0400030F RID: 783
		[FixedBuffer(typeof(int), 8)]
		public mstudiobone_t.<unused>e__FixedBuffer unused;

		// Token: 0x0200005A RID: 90
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 24)]
		public struct <bonecontroller>e__FixedBuffer
		{
			// Token: 0x04000310 RID: 784
			public int FixedElementField;
		}

		// Token: 0x0200005B RID: 91
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 32)]
		public struct <unused>e__FixedBuffer
		{
			// Token: 0x04000311 RID: 785
			public int FixedElementField;
		}
	}
}
