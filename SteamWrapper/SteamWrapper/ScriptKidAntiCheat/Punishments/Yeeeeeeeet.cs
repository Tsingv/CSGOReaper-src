using System;
using System.Threading;
using System.Threading.Tasks;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat.Punishments
{
	// Token: 0x0200002B RID: 43
	internal class Yeeeeeeeet : Punishment
	{
		// Token: 0x0600009B RID: 155 RVA: 0x00006FAC File Offset: 0x000051AC
		public Yeeeeeeeet(TripWire TripWire, int MouseX_BeforeDrop, int MouseY_BeforeDrop, int MouseX_AfterDrop, int MouseY_AfterDrop) : base(3000, true, 500)
		{
			Yeeeeeeeet <>4__this = this;
			if (!base.CanActivate())
			{
				return;
			}
			this.TriggeringTripWire = TripWire;
			Task.Run(delegate()
			{
				if (<>4__this.Player.ActiveWeapon == 59)
				{
					Program.GameConsole.SendCommand("slot2");
					Thread.Sleep(200);
				}
				Program.GameConsole.SendCommand("drop; drop;");
				SendInput.MouseMove(MouseX_BeforeDrop, MouseY_BeforeDrop);
				Thread.Sleep(150);
				SendInput.MouseMove(MouseX_AfterDrop, MouseY_AfterDrop);
			});
			base.AfterActivate(true);
		}

		// Token: 0x040001ED RID: 493
		public TripWire TriggeringTripWire;
	}
}
