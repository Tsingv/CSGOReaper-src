using System;
using System.Threading;
using System.Threading.Tasks;

namespace ScriptKidAntiCheat.Punishments
{
	// Token: 0x02000037 RID: 55
	internal class ViolenceSpeedMomentum : Punishment
	{
		// Token: 0x060000CE RID: 206 RVA: 0x00007A6B File Offset: 0x00005C6B
		public ViolenceSpeedMomentum() : base(5000, false, 500)
		{
			this.ActivatePunishment();
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00007A84 File Offset: 0x00005C84
		public void ActivatePunishment()
		{
			if (!base.CanActivate())
			{
				return;
			}
			Program.GameConsole.SendCommand("sensitivity 100");
			Task.Run(delegate()
			{
				for (int i = 0; i < 3; i++)
				{
					Program.GameConsole.SendCommand("+jump");
					Thread.Sleep(100);
					Program.GameConsole.SendCommand("-jump");
					Thread.Sleep(1000);
				}
			});
			base.AfterActivate(true);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00007AD5 File Offset: 0x00005CD5
		public override void Reset()
		{
			Program.GameConsole.SendCommand("exec reset.cfg");
		}
	}
}
