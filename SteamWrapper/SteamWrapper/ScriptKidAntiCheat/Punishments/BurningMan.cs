using System;
using System.Threading;
using System.Threading.Tasks;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat.Punishments
{
	// Token: 0x0200002A RID: 42
	internal class BurningMan : Punishment
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00006E86 File Offset: 0x00005086
		// (set) Token: 0x06000096 RID: 150 RVA: 0x00006E8E File Offset: 0x0000508E
		public override int ActivateOnRound { get; set; } = 5;

		// Token: 0x06000097 RID: 151 RVA: 0x00006E97 File Offset: 0x00005097
		public BurningMan() : base(0, false, 500)
		{
			MouseHook.MouseAction += this.Event;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00006EC0 File Offset: 0x000050C0
		private void Event(object MouseEvent, EventArgs e)
		{
			if (!Program.GameProcess.IsValid || !Program.GameData.Player.IsAlive())
			{
				return;
			}
			if ((MouseHook.MouseEvents)MouseEvent == MouseHook.MouseEvents.WM_LBUTTONUP)
			{
				Weapons activeWeapon = (Weapons)base.Player.ActiveWeapon;
				if ((activeWeapon == Weapons.Molotov || activeWeapon == Weapons.Incendiary || activeWeapon == Weapons.Grenade) && !this.IsThrowing)
				{
					this.ActivatePunishment();
				}
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00006F21 File Offset: 0x00005121
		public void ActivatePunishment()
		{
			if (!base.CanActivate())
			{
				return;
			}
			if (new Random().Next(0, 2) != 0)
			{
				return;
			}
			this.IsThrowing = true;
			Task.Run(delegate()
			{
				Thread.Sleep(75);
				SendInput.MouseMove(0, 10000);
				Program.GameConsole.SendCommand("-forward; -back; -moveleft; -moveright; unbind W; unbind A; unbind S; unbind D");
				Thread.Sleep(2000);
				Program.GameConsole.SendCommand("exec reset.cfg");
				this.IsThrowing = false;
			});
			base.AfterActivate(true);
		}

		// Token: 0x040001EB RID: 491
		public bool IsThrowing;
	}
}
