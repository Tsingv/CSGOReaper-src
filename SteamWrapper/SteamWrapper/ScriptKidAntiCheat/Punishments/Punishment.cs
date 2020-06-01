using System;
using System.Threading.Tasks;
using System.Timers;
using ScriptKidAntiCheat.Classes;
using ScriptKidAntiCheat.Data;
using ScriptKidAntiCheat.Internal;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat.Punishments
{
	// Token: 0x02000025 RID: 37
	public class Punishment : IDisposable
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000072 RID: 114 RVA: 0x000069AA File Offset: 0x00004BAA
		// (set) Token: 0x06000073 RID: 115 RVA: 0x000069B2 File Offset: 0x00004BB2
		public bool Enabled { get; set; } = true;

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000074 RID: 116 RVA: 0x000069BB File Offset: 0x00004BBB
		// (set) Token: 0x06000075 RID: 117 RVA: 0x000069C3 File Offset: 0x00004BC3
		public virtual int ActivateOnRound { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000076 RID: 118 RVA: 0x000069CC File Offset: 0x00004BCC
		// (set) Token: 0x06000077 RID: 119 RVA: 0x000069D4 File Offset: 0x00004BD4
		public virtual int DeactivateOnRound { get; set; } = 30;

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000078 RID: 120 RVA: 0x000069DD File Offset: 0x00004BDD
		// (set) Token: 0x06000079 RID: 121 RVA: 0x000069E5 File Offset: 0x00004BE5
		public GameProcess GameProcess { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600007A RID: 122 RVA: 0x000069EE File Offset: 0x00004BEE
		// (set) Token: 0x0600007B RID: 123 RVA: 0x000069F6 File Offset: 0x00004BF6
		public GameData GameData { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600007C RID: 124 RVA: 0x000069FF File Offset: 0x00004BFF
		// (set) Token: 0x0600007D RID: 125 RVA: 0x00006A07 File Offset: 0x00004C07
		public Player Player { get; set; }

		// Token: 0x0600007E RID: 126 RVA: 0x00006A10 File Offset: 0x00004C10
		public Punishment(int resetTime = 5000, bool resetOnNewRound = false, int tickSpeed = 500)
		{
			Punishment.ticker = new Timer((double)tickSpeed);
			this.GameProcess = Program.GameProcess;
			this.GameData = Program.GameData;
			this.Player = this.GameData.Player;
			Console.WriteLine("Punishment activated: " + base.GetType().Name);
			if (resetOnNewRound)
			{
				this.unsubscribeOnDispose = true;
				this.GameData.MatchInfo.OnMatchNewRound += this.ResetOnMatchNewRound;
			}
			if (resetTime != 0)
			{
				this.ResetAfter(resetTime);
			}
			Punishment.ticker.Elapsed += this.Tick;
			Punishment.ticker.AutoReset = true;
			Punishment.ticker.Enabled = true;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00006AE0 File Offset: 0x00004CE0
		public virtual void AfterActivate(bool logging = true)
		{
			if (logging)
			{
				ReplayLogger.Log(base.GetType().Name, true, "");
				Analytics.TrackEvent("Punishments", base.GetType().Name, "", 0);
				if (Program.Debug.ShowDebugMessages)
				{
					Program.GameConsole.SendCommand("Say \"Punishment activated (" + base.GetType().Name + ")\"");
				}
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00006B54 File Offset: 0x00004D54
		public virtual bool CanActivate()
		{
			return this.Enabled && (!this.GameData.MatchInfo.isWarmup || Program.Debug.AllowInWarmup) && ((this.GameData.MatchInfo.RoundNumber >= this.ActivateOnRound && this.GameData.MatchInfo.RoundNumber <= this.DeactivateOnRound) || Program.Debug.IgnoreActivateOnRound);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00006BCC File Offset: 0x00004DCC
		private async Task ResetAfter(int ms)
		{
			await Task.Delay(ms);
			this.Reset();
			this.Dispose();
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00006C19 File Offset: 0x00004E19
		private void ResetOnMatchNewRound(object sender, EventArgs e)
		{
			this.Reset();
			this.Dispose();
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00006421 File Offset: 0x00004621
		public virtual void Reset()
		{
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00006421 File Offset: 0x00004621
		public virtual void Tick(object source, ElapsedEventArgs e)
		{
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00006C27 File Offset: 0x00004E27
		public virtual void Dispose()
		{
			if (this.unsubscribeOnDispose)
			{
				FakeCheat.OnMatchNewRound -= this.ResetOnMatchNewRound;
			}
			Punishment.ticker.Stop();
			Punishment.ticker.Dispose();
		}

		// Token: 0x040001D8 RID: 472
		private static Timer ticker;

		// Token: 0x040001D9 RID: 473
		private bool unsubscribeOnDispose;
	}
}
