using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat
{
	// Token: 0x02000002 RID: 2
	internal static class Program
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		[STAThread]
		private static void Main()
		{
			string str = "v1.8.0";
			Analytics.TrackEvent("Launcher", "Started", "", 0);
			if (!Directory.Exists(Path.GetTempPath() + "\\sheeter_" + str))
			{
				Directory.CreateDirectory(Path.GetTempPath() + "\\sheeter_" + str);
			}
			if (!File.Exists(Path.GetTempPath() + "\\sheeter_" + str + "\\SteamWrapper.exe"))
			{
				if (File.Exists("bin\\SteamWrapper.exe"))
				{
					File.Copy("bin\\SteamWrapper.exe", Path.GetTempPath() + "\\sheeter_" + str + "\\SteamWrapper.exe");
				}
				else
				{
					Analytics.TrackEvent("Launcher", "CouldNotFindBinFiles", "", 0);
					MessageBox.Show("Could not find required bin files (Make sure you extract all files from zip file)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Environment.Exit(0);
				}
			}
			if (File.Exists(Path.GetTempPath() + "\\sheeter_" + str + "\\SteamWrapper.exe"))
			{
				Process.Start(Path.GetTempPath() + "\\sheeter_" + str + "\\SteamWrapper.exe");
				return;
			}
			Analytics.TrackEvent("Launcher", "CouldNotFindExeInTmp", "", 0);
			MessageBox.Show("Could not start - Try running as administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Environment.Exit(0);
		}
	}
}
