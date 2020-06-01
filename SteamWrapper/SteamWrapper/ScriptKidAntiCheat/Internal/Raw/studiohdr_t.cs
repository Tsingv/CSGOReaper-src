using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX;

namespace ScriptKidAntiCheat.Internal.Raw
{
	// Token: 0x0200005D RID: 93
	public struct studiohdr_t
	{
		// Token: 0x04000315 RID: 789
		public int id;

		// Token: 0x04000316 RID: 790
		public int version;

		// Token: 0x04000317 RID: 791
		public int checksum;

		// Token: 0x04000318 RID: 792
		[FixedBuffer(typeof(byte), 64)]
		public studiohdr_t.<name>e__FixedBuffer name;

		// Token: 0x04000319 RID: 793
		public int length;

		// Token: 0x0400031A RID: 794
		public Vector3 eyeposition;

		// Token: 0x0400031B RID: 795
		public Vector3 illumposition;

		// Token: 0x0400031C RID: 796
		public Vector3 hull_min;

		// Token: 0x0400031D RID: 797
		public Vector3 hull_max;

		// Token: 0x0400031E RID: 798
		public Vector3 view_bbmin;

		// Token: 0x0400031F RID: 799
		public Vector3 view_bbmax;

		// Token: 0x04000320 RID: 800
		public int flags;

		// Token: 0x04000321 RID: 801
		public int numbones;

		// Token: 0x04000322 RID: 802
		public int boneindex;

		// Token: 0x04000323 RID: 803
		public int numbonecontrollers;

		// Token: 0x04000324 RID: 804
		public int bonecontrollerindex;

		// Token: 0x04000325 RID: 805
		public int numhitboxsets;

		// Token: 0x04000326 RID: 806
		public int hitboxsetindex;

		// Token: 0x0200005E RID: 94
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 64)]
		public struct <name>e__FixedBuffer
		{
			// Token: 0x04000327 RID: 807
			public byte FixedElementField;
		}
	}
}
