using System;
using System.Timers;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat.Punishments
{
	// Token: 0x0200002E RID: 46
	internal class InvertMouseAds : Punishment
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x000070E0 File Offset: 0x000052E0
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x000070E8 File Offset: 0x000052E8
		public override int ActivateOnRound { get; set; } = 2;

		// Token: 0x060000A3 RID: 163 RVA: 0x000070F1 File Offset: 0x000052F1
		public InvertMouseAds() : base(0, false, 500)
		{
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00007108 File Offset: 0x00005308
		public override void Tick(object source, ElapsedEventArgs e)
		{
			Weapons activeWeapon = (Weapons)base.Player.ActiveWeapon;
			if (base.Player.isAimingDownScope && (activeWeapon == Weapons.Awp || activeWeapon == Weapons.Scout || activeWeapon == Weapons.Sig || activeWeapon == Weapons.Scar))
			{
				if (!this.InvertActivated)
				{
					this.ActivatePunishment();
					return;
				}
			}
			else if (this.InvertActivated)
			{
				this.Reset();
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000715F File Offset: 0x0000535F
		public void ActivatePunishment()
		{
			if (!base.CanActivate())
			{
				return;
			}
			this.InvertActivated = true;
			Program.GameConsole.SendCommand("m_pitch -0.022");
			base.AfterActivate(true);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00007187 File Offset: 0x00005387
		public override void Reset()
		{
			this.InvertActivated = false;
			Program.GameConsole.SendCommand("m_pitch +0.022");
		}

		// Token: 0x040001F3 RID: 499
		public bool InvertActivated;
	}
}
