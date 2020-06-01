using System;
using ScriptKidAntiCheat.Data;
using ScriptKidAntiCheat.Utils;
using SharpDX;

namespace ScriptKidAntiCheat.Internal
{
	// Token: 0x02000050 RID: 80
	public abstract class EntityBase
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600015E RID: 350 RVA: 0x00009F0C File Offset: 0x0000810C
		// (set) Token: 0x0600015F RID: 351 RVA: 0x00009F14 File Offset: 0x00008114
		public IntPtr AddressBase { get; protected set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000160 RID: 352 RVA: 0x00009F1D File Offset: 0x0000811D
		// (set) Token: 0x06000161 RID: 353 RVA: 0x00009F25 File Offset: 0x00008125
		public bool LifeState { get; protected set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000162 RID: 354 RVA: 0x00009F2E File Offset: 0x0000812E
		// (set) Token: 0x06000163 RID: 355 RVA: 0x00009F36 File Offset: 0x00008136
		public int Health { get; protected set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000164 RID: 356 RVA: 0x00009F3F File Offset: 0x0000813F
		// (set) Token: 0x06000165 RID: 357 RVA: 0x00009F47 File Offset: 0x00008147
		public Team Team { get; protected set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000166 RID: 358 RVA: 0x00009F50 File Offset: 0x00008150
		// (set) Token: 0x06000167 RID: 359 RVA: 0x00009F58 File Offset: 0x00008158
		public Vector3 Origin { get; private set; }

		// Token: 0x06000168 RID: 360 RVA: 0x00009F61 File Offset: 0x00008161
		public virtual bool IsAlive()
		{
			return this.AddressBase != IntPtr.Zero && !this.LifeState && this.Health > 0 && (this.Team == Team.Terrorists || this.Team == Team.CounterTerrorists);
		}

		// Token: 0x06000169 RID: 361
		protected abstract IntPtr ReadAddressBase(GameProcess gameProcess);

		// Token: 0x0600016A RID: 362 RVA: 0x00009F9C File Offset: 0x0000819C
		public virtual bool Update(GameProcess gameProcess)
		{
			this.AddressBase = this.ReadAddressBase(gameProcess);
			if (this.AddressBase == IntPtr.Zero)
			{
				return false;
			}
			this.LifeState = gameProcess.Process.Read(this.AddressBase + Offsets.m_lifeState);
			this.Health = gameProcess.Process.Read(this.AddressBase + Offsets.m_iHealth);
			this.Team = (Team)gameProcess.Process.Read(this.AddressBase + Offsets.m_iTeamNum);
			this.Origin = gameProcess.Process.Read(this.AddressBase + Offsets.m_vecOrigin);
			return true;
		}
	}
}
