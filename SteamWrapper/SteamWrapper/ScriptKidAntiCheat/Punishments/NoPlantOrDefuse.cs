using System;
using System.Timers;

namespace ScriptKidAntiCheat.Punishments
{
	// Token: 0x02000031 RID: 49
	internal class NoPlantOrDefuse : Punishment
	{
		// Token: 0x060000B2 RID: 178 RVA: 0x00007338 File Offset: 0x00005538
		public NoPlantOrDefuse() : base(0, false, 100)
		{
			NoPlantOrDefuse.FakePlantTimer = new Timer();
			NoPlantOrDefuse.FakePlantTimer.Elapsed += this.FakePlant;
			NoPlantOrDefuse.FakePlantTimer.AutoReset = false;
			NoPlantOrDefuse.FakePlantTimer.Enabled = false;
			NoPlantOrDefuse.FakeDefuseTimer = new Timer();
			NoPlantOrDefuse.FakeDefuseTimer.Elapsed += this.FakeDefuse;
			NoPlantOrDefuse.FakeDefuseTimer.AutoReset = false;
			NoPlantOrDefuse.FakeDefuseTimer.Enabled = false;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000073BC File Offset: 0x000055BC
		public override void Tick(object source, ElapsedEventArgs e)
		{
			if (!base.Player.IsAlive())
			{
				return;
			}
			if (base.Player.IsArmingBomb(base.GameProcess))
			{
				if (!this.FakePlantStarted)
				{
					this.FakePlantStarted = true;
					NoPlantOrDefuse.FakePlantTimer.Interval = 2700.0;
					NoPlantOrDefuse.FakePlantTimer.Start();
				}
			}
			else
			{
				NoPlantOrDefuse.FakePlantTimer.Stop();
				this.FakePlantStarted = false;
			}
			if (base.Player.IsDefusingBomb(base.GameProcess))
			{
				if (!this.FakeDefuseStarted)
				{
					this.FakeDefuseStarted = true;
					NoPlantOrDefuse.FakeDefuseTimer.Interval = 9500.0;
					if (base.Player.HasDefuseKit)
					{
						NoPlantOrDefuse.FakeDefuseTimer.Interval = 4500.0;
					}
					NoPlantOrDefuse.FakeDefuseTimer.Start();
					return;
				}
			}
			else
			{
				NoPlantOrDefuse.FakeDefuseTimer.Stop();
				this.FakeDefuseStarted = false;
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000749A File Offset: 0x0000569A
		public void FakePlant(object source, ElapsedEventArgs e)
		{
			if (!base.CanActivate())
			{
				return;
			}
			if (!base.Player.IsArmingBomb(base.GameProcess))
			{
				return;
			}
			Program.GameConsole.SendCommand("-attack; slot2; slot1; play radio\\bombpl;");
			base.AfterActivate(true);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x000074CF File Offset: 0x000056CF
		public void FakeDefuse(object source, ElapsedEventArgs e)
		{
			if (!base.CanActivate())
			{
				return;
			}
			if (!base.Player.IsDefusingBomb(base.GameProcess))
			{
				return;
			}
			Program.GameConsole.SendCommand("-use; slot2; slot1; play radio\\bombdef.wav;");
			base.AfterActivate(true);
		}

		// Token: 0x040001F8 RID: 504
		public bool FakePlantStarted;

		// Token: 0x040001F9 RID: 505
		public bool FakeDefuseStarted;

		// Token: 0x040001FA RID: 506
		private static Timer FakePlantTimer;

		// Token: 0x040001FB RID: 507
		private static Timer FakeDefuseTimer;
	}
}
