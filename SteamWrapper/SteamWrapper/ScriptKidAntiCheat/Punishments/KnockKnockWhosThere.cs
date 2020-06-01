using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat.Punishments
{
	// Token: 0x02000028 RID: 40
	internal class KnockKnockWhosThere : Punishment
	{
		// Token: 0x0600008D RID: 141 RVA: 0x00006DAE File Offset: 0x00004FAE
		public KnockKnockWhosThere(TripWire TripWire) : base(0, false, 100)
		{
			this.triggeringTripWire = TripWire;
			Program.m_GlobalHook.KeyDown += this.GlobalHookKeyDown;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00006DD7 File Offset: 0x00004FD7
		private void GlobalHookKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.E)
			{
				if (this.simulatedKeyDown)
				{
					this.simulatedKeyDown = false;
					return;
				}
				this.ActivatePunishment();
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00006DF9 File Offset: 0x00004FF9
		public override void Tick(object source, ElapsedEventArgs e)
		{
			if (!this.triggeringTripWire.IsBeingTripped)
			{
				this.Dispose();
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00006E0E File Offset: 0x0000500E
		public void ActivatePunishment()
		{
			if (!base.CanActivate())
			{
				return;
			}
			this.simulatedKeyDown = true;
			Task.Run(delegate()
			{
				Thread.Sleep(100);
				SendInput.KeyPress(KeyCode.KEY_E);
			});
			base.AfterActivate(true);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00006E4C File Offset: 0x0000504C
		public override void Dispose()
		{
			Program.m_GlobalHook.KeyDown -= this.GlobalHookKeyDown;
			base.Dispose();
		}

		// Token: 0x040001E6 RID: 486
		public TripWire triggeringTripWire;

		// Token: 0x040001E7 RID: 487
		private bool simulatedKeyDown;

		// Token: 0x040001E8 RID: 488
		private IKeyboardMouseEvents m_GlobalHook;
	}
}
