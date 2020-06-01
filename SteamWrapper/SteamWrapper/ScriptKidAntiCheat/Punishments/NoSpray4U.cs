using System;
using System.Timers;

namespace ScriptKidAntiCheat.Punishments
{
	// Token: 0x02000033 RID: 51
	internal class NoSpray4U : Punishment
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x0000763F File Offset: 0x0000583F
		// (set) Token: 0x060000BA RID: 186 RVA: 0x00007647 File Offset: 0x00005847
		public override int ActivateOnRound { get; set; } = 5;

		// Token: 0x060000BB RID: 187 RVA: 0x00007650 File Offset: 0x00005850
		public NoSpray4U() : base(0, false, 500)
		{
			Program.GameData.MatchInfo.OnMatchNewRound += this.OnNewRound;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00007684 File Offset: 0x00005884
		public override void Tick(object source, ElapsedEventArgs e)
		{
			int num = new Random().Next(5, 10);
			if (base.Player.IsAlive() && base.Player.BulletCounter(base.GameProcess) > num)
			{
				this.ActivatePunishment();
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000076C6 File Offset: 0x000058C6
		private void OnNewRound(object sender, EventArgs e)
		{
			base.Enabled = true;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x000076CF File Offset: 0x000058CF
		public void ActivatePunishment()
		{
			if (!base.CanActivate())
			{
				return;
			}
			Program.GameConsole.SendCommand("drop; drop;");
			base.AfterActivate(true);
			if (new Random().Next(0, 5) == 0)
			{
				base.Enabled = false;
			}
		}
	}
}
