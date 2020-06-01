using System;
using System.Timers;
using System.Windows.Forms;
using ScriptKidAntiCheat.Utils;
using SharpDX;

namespace ScriptKidAntiCheat.Classes
{
	// Token: 0x02000062 RID: 98
	public class FakeCheat
	{
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060001CE RID: 462 RVA: 0x0000AD18 File Offset: 0x00008F18
		// (remove) Token: 0x060001CF RID: 463 RVA: 0x0000AD4C File Offset: 0x00008F4C
		public static event EventHandler OnMatchNewRound;

		// Token: 0x060001D0 RID: 464 RVA: 0x0000AD80 File Offset: 0x00008F80
		public FakeCheat(FakeCheatForm the_form)
		{
			Analytics.TrackEvent("FakeCheat", "Loaded", "", 0);
			FakeCheat.form = the_form;
			MouseHook.Start();
			new ReplayMonitor();
			FakeCheat.pathToCSGO = Helper.getPathToCSGO();
			FakeCheat.ticker = new System.Timers.Timer(500.0);
			FakeCheat.ticker.Elapsed += this.tick;
			FakeCheat.ticker.AutoReset = true;
			FakeCheat.ticker.Enabled = true;
			Program.m_GlobalHook.KeyPress += this.GlobalHookKeyPress;
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0000AE23 File Offset: 0x00009023
		private void tick(object source, ElapsedEventArgs e)
		{
			if (Program.GameProcess.IsValid && (Program.GameData.MatchInfo.IsMatchmaking || Program.Debug.AllowLocal))
			{
				this.getCurrentMap();
			}
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000AE54 File Offset: 0x00009054
		private void getCurrentMap()
		{
			IntPtr intPtr = Program.GameProcess.ModuleEngine.Read(Offsets.dwClientState);
			if (intPtr != IntPtr.Zero)
			{
				int num = Program.GameProcess.Process.Read(intPtr + Offsets.dwClientState_Map);
				if (Program.GameData.CurrentMap == null || Program.GameData.CurrentMap.map_id != num)
				{
					if (Program.GameData.CurrentMap != null)
					{
						Program.GameData.CurrentMap.Dispose();
					}
					Console.WriteLine(num);
					if (num <= 1767859556)
					{
						if (num != 1667196260)
						{
							if (num != 1683973476)
							{
								if (num == 1767859556)
								{
									Program.GameData.CurrentMap = new de_inferno();
								}
							}
							else
							{
								Program.GameData.CurrentMap = new de_dust2();
							}
						}
						else
						{
							Program.GameData.CurrentMap = new de_cache();
						}
					}
					else if (num != 1834968420)
					{
						if (num != 1851745636)
						{
							if (num == 1868522852)
							{
								Program.GameData.CurrentMap = new de_overpass();
							}
						}
						else
						{
							Program.GameData.CurrentMap = new de_nuke();
						}
					}
					else
					{
						Program.GameData.CurrentMap = new de_mirage();
					}
					Analytics.TrackEvent("MapLoads", Program.GameData.CurrentMap.GetType().Name, "", 0);
				}
			}
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0000AFA7 File Offset: 0x000091A7
		public static void log(string msg)
		{
			FakeCheat.form.log(msg);
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0000AFB4 File Offset: 0x000091B4
		private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 'c')
			{
				this.pointers = "";
				this.pointerI = 0;
			}
			if (e.KeyChar == 'p')
			{
				IntPtr intPtr = Program.GameProcess.ModuleClient.Read(Offsets.dwLocalPlayer);
				if (intPtr != IntPtr.Zero)
				{
					Vector3 vector = Program.GameProcess.Process.Read(intPtr + Offsets.m_vecOrigin);
					Vector3 vector2 = Program.GameProcess.Process.Read(intPtr + Offsets.m_vecViewOffset);
					Vector3 vector3 = vector + vector2;
					this.pointerI++;
					this.pointers = string.Concat(new string[]
					{
						this.pointers,
						"x",
						this.pointerI.ToString(),
						" = ",
						((int)vector3.X).ToString(),
						", y",
						this.pointerI.ToString(),
						" = ",
						((int)vector3.Y).ToString(),
						","
					});
					if (this.pointerI == 4)
					{
						Console.WriteLine("######################################");
						Console.WriteLine("TRIPWIRE LOCATION:");
						Console.WriteLine(this.pointers);
						Console.WriteLine("z = " + ((int)vector3.Z).ToString());
						Console.WriteLine("######################################");
						this.pointers = "";
						this.pointerI = 0;
						return;
					}
					this.pointers += "\r";
				}
			}
		}

		// Token: 0x0400033D RID: 829
		public static FakeCheatForm form;

		// Token: 0x0400033E RID: 830
		private static System.Timers.Timer ticker;

		// Token: 0x0400033F RID: 831
		public static int currentMatchRound = 0;

		// Token: 0x04000340 RID: 832
		public static bool isInFreezeTime = false;

		// Token: 0x04000341 RID: 833
		public static string pathToCSGO = "";

		// Token: 0x04000343 RID: 835
		public int pointerI;

		// Token: 0x04000344 RID: 836
		public string pointers = "";
	}
}
