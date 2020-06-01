using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat
{
	// Token: 0x0200000A RID: 10
	public class GameConsole
	{
		// Token: 0x0600001C RID: 28 RVA: 0x00002BC8 File Offset: 0x00000DC8
		public GameConsole()
		{
			if (!this.checkIfCfgIsReady())
			{
				this.setupUserConfigs();
			}
			this.CFG_PATH = Helper.getPathToCSGO() + "\\cfg\\cheater.cfg";
			if (!File.Exists(this.CFG_PATH))
			{
				File.Create(this.CFG_PATH);
			}
			this.CFG_INFO = new FileInfo(this.CFG_PATH);
			this.writeTimer = new Timer(100.0);
			this.writeTimer.Elapsed += this.fileWriter;
			this.writeTimer.AutoReset = true;
			this.writeTimer.Enabled = true;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002C78 File Offset: 0x00000E78
		private void setupUserConfigs()
		{
			string[] directories = Directory.GetDirectories(Helper.getPathToSteam() + "\\userdata");
			for (int i = 0; i < directories.Length; i++)
			{
				string path = directories[i] + "\\730\\local\\cfg\\config.cfg";
				if (File.Exists(path))
				{
					using (StreamWriter streamWriter = File.AppendText(path))
					{
						streamWriter.WriteLine("\rbind \"F9\" \"exec cheater.cfg\"");
					}
				}
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002CEC File Offset: 0x00000EEC
		public bool checkIfCfgIsReady()
		{
			bool result = true;
			string[] directories = Directory.GetDirectories(Helper.getPathToSteam() + "\\userdata");
			for (int i = 0; i < directories.Length; i++)
			{
				string path = directories[i] + "\\730\\local\\cfg\\config.cfg";
				if (File.Exists(path))
				{
					using (StreamReader streamReader = new StreamReader(path))
					{
						if (!streamReader.ReadToEnd().Contains("cheater.cfg"))
						{
							result = false;
						}
					}
				}
			}
			GameConsole.cfgIsReady = result;
			return result;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002D78 File Offset: 0x00000F78
		public void SendCommand(string Command)
		{
			this.CommandQueue.Add(Command);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002D86 File Offset: 0x00000F86
		private void fileWriter(object source, ElapsedEventArgs e)
		{
			if (Helper.IsFileLocked(this.CFG_INFO) || this.isWriting || this.CommandQueue.Count < 1)
			{
				return;
			}
			this.writeToCFG();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002DB4 File Offset: 0x00000FB4
		private void writeToCFG()
		{
			if (!Program.GameProcess.IsValid)
			{
				return;
			}
			this.isWriting = true;
			string text = "";
			foreach (string text2 in this.CommandQueue.ToList<string>())
			{
				if (!text2.EndsWith(";"))
				{
					text = text + text2 + ";";
				}
				else
				{
					text += text2;
				}
				this.CommandQueue.Remove(text2);
			}
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(this.CFG_PATH, false))
				{
					streamWriter.WriteLine(text);
					streamWriter.Close();
				}
				SendInput.KeyPress(KeyCode.F9);
			}
			catch (IOException)
			{
			}
			this.isWriting = false;
		}

		// Token: 0x0400009A RID: 154
		private Timer writeTimer;

		// Token: 0x0400009B RID: 155
		private string CFG_PATH;

		// Token: 0x0400009C RID: 156
		private FileInfo CFG_INFO;

		// Token: 0x0400009D RID: 157
		private bool isWriting;

		// Token: 0x0400009E RID: 158
		private List<string> CommandQueue = new List<string>();

		// Token: 0x0400009F RID: 159
		public static bool cfgIsReady = true;
	}
}
