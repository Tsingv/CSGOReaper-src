using System;
using System.Diagnostics;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using ScriptKidAntiCheat.Classes;
using ScriptKidAntiCheat.Data;
using ScriptKidAntiCheat.Forms;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat
{
	// Token: 0x02000013 RID: 19
	internal static class Program
	{
		// Token: 0x0600004D RID: 77 RVA: 0x00006424 File Offset: 0x00004624
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Program.Debug = new ScriptKidAntiCheat.Utils.Debug();
			if (!Program.Debug.DisableAcceptConditions)
			{
				Application.Run(new Conditions());
			}
			Program.m_GlobalHook = Hook.GlobalEvents();
			FakeCheatForm mainForm = new FakeCheatForm();
			Process[] processesByName = Process.GetProcessesByName("SteamWrapper");
			if (Helper.getPathToCSGO() != "" && processesByName.Length == 1)
			{
				Program.GameConsole = new GameConsole();
				Program.GameProcess = new GameProcess();
				Program.GameData = new GameData(Program.GameProcess);
				Program.GameProcess.Start();
				Program.GameData.Start();
				Program.FakeCheat = new FakeCheat(mainForm);
			}
			Application.Run(mainForm);
			if (processesByName.Length == 1 && !Program.Debug.DisableRunInBackground)
			{
				Application.Run(new Hidden());
			}
			Program.Dispose();
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000064F7 File Offset: 0x000046F7
		private static void Dispose()
		{
			Program.GameData.Dispose();
			Program.GameData = null;
			Program.GameProcess.Dispose();
			Program.GameProcess = null;
		}

		// Token: 0x040000EA RID: 234
		public static string version = "v1.8.0";

		// Token: 0x040000EB RID: 235
		public static FakeCheatForm the_form;

		// Token: 0x040000EC RID: 236
		public static GameProcess GameProcess;

		// Token: 0x040000ED RID: 237
		public static GameConsole GameConsole;

		// Token: 0x040000EE RID: 238
		public static FakeCheat FakeCheat;

		// Token: 0x040000EF RID: 239
		public static GameData GameData;

		// Token: 0x040000F0 RID: 240
		public static ScriptKidAntiCheat.Utils.Debug Debug;

		// Token: 0x040000F1 RID: 241
		public static IKeyboardMouseEvents m_GlobalHook;
	}
}
