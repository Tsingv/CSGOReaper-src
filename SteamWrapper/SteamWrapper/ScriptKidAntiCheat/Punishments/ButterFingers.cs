using System;

namespace ScriptKidAntiCheat.Punishments
{
	// Token: 0x0200002D RID: 45
	internal class ButterFingers : Punishment
	{
		// Token: 0x0600009E RID: 158 RVA: 0x00007095 File Offset: 0x00005295
		public ButterFingers() : base(15000, true, 500)
		{
			this.ActivatePunishment();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000070AE File Offset: 0x000052AE
		public void ActivatePunishment()
		{
			if (!base.CanActivate())
			{
				return;
			}
			Program.GameConsole.SendCommand("bind mouse1 drop");
			base.AfterActivate(true);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000070CF File Offset: 0x000052CF
		public override void Reset()
		{
			Program.GameConsole.SendCommand("bind mouse1 +attack");
		}
	}
}
