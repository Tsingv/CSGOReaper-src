using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ScriptKidAntiCheat.Data;
using ScriptKidAntiCheat.Internal.Raw;
using ScriptKidAntiCheat.Utils;
using ScriptKidAntiCheat.Utils.Maths;
using SharpDX;

namespace ScriptKidAntiCheat.Internal
{
	// Token: 0x0200004F RID: 79
	public class Entity : EntityBase
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000145 RID: 325 RVA: 0x00009B37 File Offset: 0x00007D37
		public int Index { get; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000146 RID: 326 RVA: 0x00009B3F File Offset: 0x00007D3F
		// (set) Token: 0x06000147 RID: 327 RVA: 0x00009B47 File Offset: 0x00007D47
		public bool Dormant { get; private set; } = true;

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000148 RID: 328 RVA: 0x00009B50 File Offset: 0x00007D50
		// (set) Token: 0x06000149 RID: 329 RVA: 0x00009B58 File Offset: 0x00007D58
		private IntPtr AddressStudioHdr { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600014A RID: 330 RVA: 0x00009B61 File Offset: 0x00007D61
		// (set) Token: 0x0600014B RID: 331 RVA: 0x00009B69 File Offset: 0x00007D69
		public studiohdr_t StudioHdr { get; private set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600014C RID: 332 RVA: 0x00009B72 File Offset: 0x00007D72
		// (set) Token: 0x0600014D RID: 333 RVA: 0x00009B7A File Offset: 0x00007D7A
		public mstudiohitboxset_t StudioHitBoxSet { get; private set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600014E RID: 334 RVA: 0x00009B83 File Offset: 0x00007D83
		public mstudiobbox_t[] StudioHitBoxes { get; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600014F RID: 335 RVA: 0x00009B8B File Offset: 0x00007D8B
		public mstudiobone_t[] StudioBones { get; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000150 RID: 336 RVA: 0x00009B93 File Offset: 0x00007D93
		public Matrix[] BonesMatrices { get; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000151 RID: 337 RVA: 0x00009B9B File Offset: 0x00007D9B
		public Vector3[] BonesPos { get; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000152 RID: 338 RVA: 0x00009BA3 File Offset: 0x00007DA3
		[TupleElementNames(new string[]
		{
			"from",
			"to"
		})]
		public ValueTuple<int, int>[] Skeleton { [return: TupleElementNames(new string[]
		{
			"from",
			"to"
		})] get; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000153 RID: 339 RVA: 0x00009BAB File Offset: 0x00007DAB
		// (set) Token: 0x06000154 RID: 340 RVA: 0x00009BB3 File Offset: 0x00007DB3
		public int SkeletonCount { get; private set; }

		// Token: 0x06000155 RID: 341 RVA: 0x00009BBC File Offset: 0x00007DBC
		public Entity(int index)
		{
			this.Index = index;
			this.StudioHitBoxes = new mstudiobbox_t[Helper.MaxStudioBones];
			this.StudioBones = new mstudiobone_t[Helper.MaxStudioBones];
			this.BonesMatrices = new Matrix[Helper.MaxStudioBones];
			this.BonesPos = new Vector3[Helper.MaxStudioBones];
			this.Skeleton = new ValueTuple<int, int>[Helper.MaxStudioBones];
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00009C2D File Offset: 0x00007E2D
		public override bool IsAlive()
		{
			return base.IsAlive() && !this.Dormant;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00009C42 File Offset: 0x00007E42
		protected override IntPtr ReadAddressBase(GameProcess gameProcess)
		{
			return gameProcess.ModuleClient.Read(Offsets.dwEntityList + this.Index * 16);
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00009C60 File Offset: 0x00007E60
		public override bool Update(GameProcess gameProcess)
		{
			if (!base.Update(gameProcess))
			{
				return false;
			}
			this.Dormant = gameProcess.Process.Read(base.AddressBase + Offsets.m_bDormant);
			if (!this.IsAlive())
			{
				return true;
			}
			this.UpdateStudioHdr(gameProcess);
			this.UpdateStudioHitBoxes(gameProcess);
			this.UpdateStudioBones(gameProcess);
			this.UpdateBonesMatricesAndPos(gameProcess);
			this.UpdateSkeleton();
			return true;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00009CC8 File Offset: 0x00007EC8
		private void UpdateStudioHdr(GameProcess gameProcess)
		{
			IntPtr lpBaseAddress = gameProcess.Process.Read(base.AddressBase + Offsets.m_pStudioHdr);
			this.AddressStudioHdr = gameProcess.Process.Read(lpBaseAddress);
			this.StudioHdr = gameProcess.Process.Read(this.AddressStudioHdr);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00009D1C File Offset: 0x00007F1C
		private void UpdateStudioHitBoxes(GameProcess gameProcess)
		{
			IntPtr intPtr = this.AddressStudioHdr + this.StudioHdr.hitboxsetindex;
			this.StudioHitBoxSet = gameProcess.Process.Read(intPtr);
			for (int i = 0; i < this.StudioHitBoxSet.numhitboxes; i++)
			{
				this.StudioHitBoxes[i] = gameProcess.Process.Read(intPtr + this.StudioHitBoxSet.hitboxindex + i * Marshal.SizeOf<mstudiobbox_t>());
			}
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00009D9C File Offset: 0x00007F9C
		private void UpdateStudioBones(GameProcess gameProcess)
		{
			for (int i = 0; i < this.StudioHdr.numbones; i++)
			{
				this.StudioBones[i] = gameProcess.Process.Read(this.AddressStudioHdr + this.StudioHdr.boneindex + i * Marshal.SizeOf<mstudiobone_t>());
			}
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00009DF8 File Offset: 0x00007FF8
		private void UpdateBonesMatricesAndPos(GameProcess gameProcess)
		{
			IntPtr pointer = gameProcess.Process.Read(base.AddressBase + Offsets.m_dwBoneMatrix);
			for (int i = 0; i < this.BonesPos.Length; i++)
			{
				matrix3x4_t matrix3x4_t = gameProcess.Process.Read(pointer + i * Marshal.SizeOf<matrix3x4_t>());
				this.BonesMatrices[i] = matrix3x4_t.ToMatrix();
				this.BonesPos[i] = new Vector3(matrix3x4_t.m30, matrix3x4_t.m31, matrix3x4_t.m32);
			}
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00009E84 File Offset: 0x00008084
		private void UpdateSkeleton()
		{
			int num = 0;
			for (int i = 0; i < this.StudioHitBoxSet.numhitboxes; i++)
			{
				mstudiobbox_t mstudiobbox_t = this.StudioHitBoxes[i];
				mstudiobone_t mstudiobone_t = this.StudioBones[mstudiobbox_t.bone];
				if (mstudiobone_t.parent >= 0 && mstudiobone_t.parent < this.StudioHdr.numbones)
				{
					this.Skeleton[num] = new ValueTuple<int, int>(mstudiobbox_t.bone, mstudiobone_t.parent);
					num++;
				}
			}
			this.SkeletonCount = num;
		}
	}
}
