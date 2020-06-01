using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using ScriptKidAntiCheat.Win32;
using ScriptKidAntiCheat.Win32.Data;

namespace ScriptKidAntiCheat.Utils
{
	// Token: 0x0200003F RID: 63
	public static class Helper
	{
		// Token: 0x060000EE RID: 238 RVA: 0x00008120 File Offset: 0x00006320
		public static bool IsFileLocked(FileInfo file)
		{
			FileStream fileStream = null;
			try
			{
				fileStream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
			}
			catch (IOException)
			{
				return true;
			}
			finally
			{
				if (fileStream != null)
				{
					fileStream.Close();
				}
			}
			return false;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000816C File Offset: 0x0000636C
		public static Rectangle GetClientRectangle(IntPtr handle)
		{
			ScriptKidAntiCheat.Win32.Data.Point point;
			Rect rect;
			if (!User32.ClientToScreen(handle, out point) || !User32.GetClientRect(handle, out rect))
			{
				return default(Rectangle);
			}
			return new Rectangle(point.X, point.Y, rect.Right - rect.Left, rect.Bottom - rect.Top);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000081C4 File Offset: 0x000063C4
		public static ProcessModule GetProcessModule(this Process process, string moduleName)
		{
			if (process == null)
			{
				return null;
			}
			return process.Modules.OfType<ProcessModule>().FirstOrDefault((ProcessModule a) => string.Equals(a.ModuleName.ToLower(), moduleName.ToLower()));
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00008200 File Offset: 0x00006400
		public static Module GetModule(this Process process, string moduleName)
		{
			ProcessModule processModule = process.GetProcessModule(moduleName);
			if (processModule != null && !(processModule.BaseAddress == IntPtr.Zero))
			{
				return new Module(process, processModule);
			}
			return null;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00008234 File Offset: 0x00006434
		public static bool IsRunning(this Process process)
		{
			try
			{
				Process.GetProcessById(process.Id);
			}
			catch (InvalidOperationException)
			{
				return false;
			}
			catch (ArgumentException)
			{
				return false;
			}
			return true;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00008278 File Offset: 0x00006478
		public static string getPathToCSGO()
		{
			if (Helper.PathToCSGO != null)
			{
				return Helper.PathToCSGO;
			}
			object value = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Valve\\Steam\\").GetValue("SteamPath");
			if (value != null)
			{
				string str = value.ToString().Replace("/", "\\").Replace("/", "\\");
				if (Directory.Exists(str + "\\steamapps\\common\\Counter-Strike Global Offensive\\csgo"))
				{
					Helper.PathToCSGO = str + "\\steamapps\\common\\Counter-Strike Global Offensive\\csgo";
					return Helper.PathToCSGO;
				}
				if (File.Exists(str + "\\steamapps\\libraryfolders.vdf"))
				{
					StreamReader streamReader = new StreamReader(str + "\\steamapps\\libraryfolders.vdf");
					string input;
					while ((input = streamReader.ReadLine()) != null)
					{
						MatchCollection matchCollection = Regex.Matches(input, "([\"'])(?:(?=(\\\\?))\\2.)*?\\1");
						int num;
						if (matchCollection.Count >= 2 && int.TryParse(matchCollection[0].ToString().Replace("\"", ""), out num) && matchCollection[1].Length > 0)
						{
							string str2 = matchCollection[1].ToString().Replace("\"", "");
							if (Directory.Exists(str2 + "\\steamapps\\common\\Counter-Strike Global Offensive\\csgo"))
							{
								Helper.PathToCSGO = str2 + "\\steamapps\\common\\Counter-Strike Global Offensive\\csgo";
								Console.WriteLine(Helper.PathToCSGO);
								return Helper.PathToCSGO;
							}
						}
					}
				}
			}
			string text = Environment.GetEnvironmentVariable("ProgramFiles(x86)") + "\\Steam\\steamapps\\common\\Counter-Strike Global Offensive\\csgo";
			string text2 = Environment.GetEnvironmentVariable("ProgramFiles") + "\\Steam\\steamapps\\common\\Counter-Strike Global Offensive\\csgo";
			if (Directory.Exists(text2))
			{
				Helper.PathToCSGO = text2;
				return Helper.PathToCSGO;
			}
			if (Directory.Exists(text))
			{
				Helper.PathToCSGO = text;
				return Helper.PathToCSGO;
			}
			Analytics.TrackEvent("Errors", "CouldNotFindCSGOPath", "", 0);
			return "";
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00008448 File Offset: 0x00006648
		public static string getPathToSteam()
		{
			if (Helper.PathToSteam != null)
			{
				return Helper.PathToSteam;
			}
			object value = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Valve\\Steam\\").GetValue("SteamPath");
			if (value != null)
			{
				string text = value.ToString().Replace("/", "\\").Replace("/", "\\");
				if (Directory.Exists(text))
				{
					Helper.PathToSteam = text;
					return Helper.PathToSteam;
				}
			}
			string text2 = Environment.GetEnvironmentVariable("ProgramFiles(x86)") + "\\Steam";
			string text3 = Environment.GetEnvironmentVariable("ProgramFiles") + "\\Steam";
			if (Directory.Exists(text3))
			{
				Helper.PathToSteam = text3;
				return Helper.PathToSteam;
			}
			if (Directory.Exists(text2))
			{
				Helper.PathToSteam = text2;
				return Helper.PathToSteam;
			}
			Analytics.TrackEvent("Errors", "CouldNotFindSteamPath", "", 0);
			return "";
		}

		// Token: 0x04000244 RID: 580
		public static int MOUSEEVENTF_MOVE = 1;

		// Token: 0x04000245 RID: 581
		public static int MaxStudioBones = 128;

		// Token: 0x04000246 RID: 582
		public static string PathToCSGO;

		// Token: 0x04000247 RID: 583
		public static string PathToSteam;
	}
}
