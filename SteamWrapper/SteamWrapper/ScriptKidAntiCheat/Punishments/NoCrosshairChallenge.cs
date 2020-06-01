using System;

namespace ScriptKidAntiCheat.Punishments
{
	// Token: 0x0200002F RID: 47
	internal class NoCrosshairChallenge : Punishment
	{
		// Token: 0x060000A7 RID: 167 RVA: 0x0000719F File Offset: 0x0000539F
		public NoCrosshairChallenge() : base(10000, true, 500)
		{
			this.ActivatePunishment();
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000071B8 File Offset: 0x000053B8
		public void ActivatePunishment()
		{
			if (!base.CanActivate())
			{
				return;
			}
			Program.GameConsole.SendCommand("crosshair 0");
			base.AfterActivate(true);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000071D9 File Offset: 0x000053D9
		public override void Reset()
		{
			Program.GameConsole.SendCommand("crosshair 1");
		}
	}
}
