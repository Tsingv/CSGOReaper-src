using System;
using System.Timers;

namespace ScriptKidAntiCheat.Punishments
{
	// Token: 0x02000034 RID: 52
	internal class ReverseSpeedhack : Punishment
	{
		// Token: 0x060000BF RID: 191 RVA: 0x00007705 File Offset: 0x00005905
		public ReverseSpeedhack() : base(10000, true, 500)
		{
			ReplayLogger.Log(base.GetType().Name, true, "");
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000772E File Offset: 0x0000592E
		public override void Tick(object source, ElapsedEventArgs e)
		{
			this.ActivatePunishment();
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00007736 File Offset: 0x00005936
		public void ActivatePunishment()
		{
			if (!base.CanActivate())
			{
				return;
			}
			Program.GameConsole.SendCommand("+duck");
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00007750 File Offset: 0x00005950
		public override void Reset()
		{
			Program.GameConsole.SendCommand("-duck");
		}
	}
}
