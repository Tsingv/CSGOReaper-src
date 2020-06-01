using System;
using ScriptKidAntiCheat.Data;
using ScriptKidAntiCheat.Utils;
using ScriptKidAntiCheat.Utils.Maths;
using SharpDX;

namespace ScriptKidAntiCheat.Internal
{
	// Token: 0x02000052 RID: 82
	public class Player : EntityBase
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000183 RID: 387 RVA: 0x0000A4A7 File Offset: 0x000086A7
		// (set) Token: 0x06000184 RID: 388 RVA: 0x0000A4AF File Offset: 0x000086AF
		public Vector3 ViewOffset { get; private set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000185 RID: 389 RVA: 0x0000A4B8 File Offset: 0x000086B8
		// (set) Token: 0x06000186 RID: 390 RVA: 0x0000A4C0 File Offset: 0x000086C0
		public Vector3 EyePosition { get; private set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000187 RID: 391 RVA: 0x0000A4C9 File Offset: 0x000086C9
		// (set) Token: 0x06000188 RID: 392 RVA: 0x0000A4D1 File Offset: 0x000086D1
		public Vector3 ViewAngles { get; private set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000189 RID: 393 RVA: 0x0000A4DA File Offset: 0x000086DA
		// (set) Token: 0x0600018A RID: 394 RVA: 0x0000A4E2 File Offset: 0x000086E2
		public Vector3 AimPunchAngle { get; private set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600018B RID: 395 RVA: 0x0000A4EB File Offset: 0x000086EB
		// (set) Token: 0x0600018C RID: 396 RVA: 0x0000A4F3 File Offset: 0x000086F3
		public Vector3 AimDirection { get; private set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600018D RID: 397 RVA: 0x0000A4FC File Offset: 0x000086FC
		// (set) Token: 0x0600018E RID: 398 RVA: 0x0000A504 File Offset: 0x00008704
		public Vector3 vecVelocity { get; private set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600018F RID: 399 RVA: 0x0000A50D File Offset: 0x0000870D
		// (set) Token: 0x06000190 RID: 400 RVA: 0x0000A515 File Offset: 0x00008715
		public int Fov { get; private set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000191 RID: 401 RVA: 0x0000A51E File Offset: 0x0000871E
		// (set) Token: 0x06000192 RID: 402 RVA: 0x0000A526 File Offset: 0x00008726
		public short ActiveWeapon { get; private set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000193 RID: 403 RVA: 0x0000A52F File Offset: 0x0000872F
		// (set) Token: 0x06000194 RID: 404 RVA: 0x0000A537 File Offset: 0x00008737
		public bool HasDefuseKit { get; private set; }

		// Token: 0x06000195 RID: 405 RVA: 0x0000A101 File Offset: 0x00008301
		protected override IntPtr ReadAddressBase(GameProcess gameProcess)
		{
			return gameProcess.ModuleClient.Read(Offsets.dwLocalPlayer);
		}

		// Token: 0x06000196 RID: 406 RVA: 0x0000A540 File Offset: 0x00008740
		public short getActiveWeapon(GameProcess gameProcess)
		{
			int num = gameProcess.Process.Read(base.AddressBase + Offsets.m_hActiveWeapon) & 4095;
			IntPtr pointer = gameProcess.ModuleClient.Read(Offsets.dwEntityList + (num - 1) * 16);
			return gameProcess.Process.Read(pointer + Offsets.m_iItemDefinitionIndex);
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0000A5A0 File Offset: 0x000087A0
		public bool IsArmingBomb(GameProcess gameProcess)
		{
			int num = gameProcess.Process.Read(base.AddressBase + Offsets.m_hActiveWeapon) & 4095;
			IntPtr pointer = gameProcess.ModuleClient.Read(Offsets.dwEntityList + (num - 1) * 16);
			return gameProcess.Process.Read(pointer + Offsets.m_iItemDefinitionIndex) == 49 && gameProcess.Process.Read(pointer + Offsets.m_bStartedArming);
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000A61C File Offset: 0x0000881C
		public bool IsDefusingBomb(GameProcess gameProcess)
		{
			return Offsets.m_bIsDefusing != 0 && gameProcess.Process.Read(base.AddressBase + Offsets.m_bIsDefusing);
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0000A642 File Offset: 0x00008842
		public bool checkIfHasDefuseKit(GameProcess gameProcess)
		{
			return Offsets.m_bHasDefuser != 0 && gameProcess.Process.Read(base.AddressBase + Offsets.m_bHasDefuser);
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0000A668 File Offset: 0x00008868
		public bool checkIfAds(GameProcess gameProcess)
		{
			return Offsets.m_bIsScoped != 0 && gameProcess.Process.Read(base.AddressBase + Offsets.m_bIsScoped);
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0000A68E File Offset: 0x0000888E
		public int BulletCounter(GameProcess gameProcess)
		{
			if (Offsets.m_iShotsFired == 0)
			{
				return 0;
			}
			return gameProcess.Process.Read(base.AddressBase + Offsets.m_iShotsFired);
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0000A6B4 File Offset: 0x000088B4
		public Vector3 getPlayerVecVelocity(GameProcess gameProcess)
		{
			return gameProcess.Process.Read(base.AddressBase + Offsets.m_vecVelocity);
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0000A6D1 File Offset: 0x000088D1
		public Vector3 getPlayerEyePosition(GameProcess gameProcess)
		{
			this.ViewOffset = gameProcess.Process.Read(base.AddressBase + Offsets.m_vecViewOffset);
			this.EyePosition = base.Origin + this.ViewOffset;
			return this.EyePosition;
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0000A714 File Offset: 0x00008914
		public override bool Update(GameProcess gameProcess)
		{
			if (!base.Update(gameProcess))
			{
				return false;
			}
			this.EyePosition = this.getPlayerEyePosition(gameProcess);
			this.ViewAngles = gameProcess.Process.Read(gameProcess.ModuleEngine.Read(Offsets.dwClientState) + Offsets.dwClientState_ViewAngles);
			this.AimPunchAngle = gameProcess.Process.Read(base.AddressBase + Offsets.m_aimPunchAngle);
			this.Fov = gameProcess.Process.Read(base.AddressBase + Offsets.m_iFOV);
			if (this.Fov == 0)
			{
				this.Fov = 90;
			}
			this.vecVelocity = this.getPlayerVecVelocity(gameProcess);
			this.ActiveWeapon = this.getActiveWeapon(gameProcess);
			this.HasDefuseKit = this.checkIfHasDefuseKit(gameProcess);
			this.isAimingDownScope = this.checkIfAds(gameProcess);
			this.AimDirection = Player.GetAimDirection(this.ViewAngles, this.AimPunchAngle);
			return true;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0000A804 File Offset: 0x00008A04
		private static Vector3 GetAimDirection(Vector3 viewAngles, Vector3 aimPunchAngle)
		{
			double num = ((double)viewAngles.X + (double)aimPunchAngle.X * Player.weapon_recoil_scale).DegreeToRadian();
			double num2 = ((double)viewAngles.Y + (double)aimPunchAngle.Y * Player.weapon_recoil_scale).DegreeToRadian();
			return new Vector3((float)(Math.Cos(num) * Math.Cos(num2)), (float)(Math.Cos(num) * Math.Sin(num2)), (float)(-(float)Math.Sin(num))).Normalized();
		}

		// Token: 0x040002BB RID: 699
		public static double weapon_recoil_scale = 2.0;

		// Token: 0x040002BE RID: 702
		public bool isAimingDownScope;
	}
}
