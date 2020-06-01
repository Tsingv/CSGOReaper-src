using System;
using System.Threading;
using System.Timers;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat.Punishments
{
	// Token: 0x02000032 RID: 50
	internal class NoSilentWalk : Punishment
	{
		// Token: 0x060000B6 RID: 182 RVA: 0x00007504 File Offset: 0x00005704
		public NoSilentWalk() : base(0, false, 500)
		{
			NoSilentWalk.punishmentTimer = new System.Timers.Timer(10000.0);
			NoSilentWalk.punishmentTimer.Elapsed += this.delayedPunishment;
			NoSilentWalk.punishmentTimer.AutoReset = false;
			NoSilentWalk.punishmentTimer.Enabled = false;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00007560 File Offset: 0x00005760
		public override void Tick(object source, ElapsedEventArgs e)
		{
			if (base.Player.vecVelocity.X < 150f && base.Player.vecVelocity.X > -150f && base.Player.vecVelocity.X != 0f && base.Player.vecVelocity.Y < 150f && base.Player.vecVelocity.Y > -150f && base.Player.vecVelocity.Y != 0f && base.Player.IsAlive())
			{
				NoSilentWalk.punishmentTimer.Start();
				return;
			}
			NoSilentWalk.punishmentTimer.Stop();
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000761C File Offset: 0x0000581C
		private void delayedPunishment(object source, ElapsedEventArgs e)
		{
			if (!base.CanActivate())
			{
				return;
			}
			SendInput.MouseLeftDown();
			Thread.Sleep(100);
			SendInput.MouseLeftUp();
			base.AfterActivate(true);
		}

		// Token: 0x040001FC RID: 508
		private static System.Timers.Timer punishmentTimer;
	}
}
