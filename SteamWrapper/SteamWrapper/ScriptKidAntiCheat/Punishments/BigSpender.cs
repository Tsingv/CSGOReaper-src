using System;
using System.Timers;

namespace ScriptKidAntiCheat.Punishments
{
	// Token: 0x02000027 RID: 39
	internal class BigSpender : Punishment
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00006D2A File Offset: 0x00004F2A
		// (set) Token: 0x06000089 RID: 137 RVA: 0x00006D32 File Offset: 0x00004F32
		public override int ActivateOnRound { get; set; } = 3;

		// Token: 0x0600008A RID: 138 RVA: 0x00006D3B File Offset: 0x00004F3B
		public BigSpender() : base(0, false, 500)
		{
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00006D51 File Offset: 0x00004F51
		public override void Tick(object source, ElapsedEventArgs e)
		{
			if (base.Player.IsAlive() && base.GameData.MatchInfo.isFreezeTime && !this.isBuying)
			{
				this.ActivatePunishment();
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00006D80 File Offset: 0x00004F80
		public void ActivatePunishment()
		{
			if (!base.CanActivate())
			{
				return;
			}
			this.isBuying = true;
			Program.GameConsole.SendCommand("buy elite; drop; buy elite; drop; buy nova; drop; buy nova; drop; buy mac10; drop; buy mac10; drop; buy bizon; drop; buy bizon; drop; buy mp9; drop; buy mp9; drop; ");
			base.AfterActivate(true);
			this.Dispose();
		}

		// Token: 0x040001E4 RID: 484
		public bool isBuying;
	}
}
