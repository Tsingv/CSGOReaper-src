using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat.Punishments
{
	// Token: 0x02000030 RID: 48
	internal class FlashInYourFace : Punishment
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000AA RID: 170 RVA: 0x000071EA File Offset: 0x000053EA
		// (set) Token: 0x060000AB RID: 171 RVA: 0x000071F2 File Offset: 0x000053F2
		public override int ActivateOnRound { get; set; } = 3;

		// Token: 0x060000AC RID: 172 RVA: 0x000071FB File Offset: 0x000053FB
		public FlashInYourFace() : base(0, false, 100)
		{
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00007218 File Offset: 0x00005418
		public override void Tick(object source, ElapsedEventArgs e)
		{
			if (!base.Player.IsAlive())
			{
				return;
			}
			Weapons activeWeapon = (Weapons)base.Player.ActiveWeapon;
			if (activeWeapon == Weapons.Flashbang || activeWeapon == Weapons.Smoke)
			{
				this.ActivatePunishment();
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00007250 File Offset: 0x00005450
		public void ActivatePunishment()
		{
			if (!base.CanActivate())
			{
				return;
			}
			if (new Random().Next(0, 2) != 0 && this.randomness)
			{
				this.randomness = false;
				base.Enabled = false;
				Task.Run(delegate()
				{
					Thread.Sleep(5000);
					this.randomness = true;
					base.Enabled = true;
				});
				return;
			}
			Task.Run(delegate()
			{
				SendInput.MouseRightDown();
				Thread.Sleep(10);
				SendInput.MouseRightUp();
				Thread.Sleep(10);
				SendInput.MouseLeftUp();
				if (!this.isThrowing)
				{
					this.isThrowing = true;
					Task.Run(delegate()
					{
						Thread.Sleep(2000);
						this.randomness = true;
						this.isThrowing = false;
					});
					base.AfterActivate(true);
				}
			});
		}

		// Token: 0x040001F5 RID: 501
		public bool isThrowing;

		// Token: 0x040001F6 RID: 502
		public bool randomness = true;
	}
}
