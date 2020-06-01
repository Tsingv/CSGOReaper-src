using System;
using System.IO;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat
{
	// Token: 0x02000006 RID: 6
	public static class ReplayLogger
	{
		// Token: 0x06000011 RID: 17 RVA: 0x00002530 File Offset: 0x00000730
		public static void Log(string Message, bool PrependScoreAndRoundTime = true, string RecordingName = "")
		{
			string path;
			string path2;
			if (RecordingName == "")
			{
				if (!Program.GameProcess.IsValid || Program.GameData.CurrentMap == null)
				{
					return;
				}
				path = Helper.getPathToCSGO() + "\\" + Program.GameData.CurrentMap.RecordingName + ".log";
				path2 = Helper.getPathToCSGO() + "\\" + Program.GameData.CurrentMap.RecordingName + ".dem";
			}
			else
			{
				path = Helper.getPathToCSGO() + "\\" + RecordingName + ".log";
				path2 = Helper.getPathToCSGO() + "\\" + RecordingName + ".dem";
			}
			try
			{
				using (StreamWriter streamWriter = File.AppendText(path))
				{
					if (PrependScoreAndRoundTime)
					{
						float num = 1f / Program.GameData.MatchInfo.GlobalVars.interval_per_tick;
						float num2 = (float)(new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds() - Program.GameData.CurrentMap.RecordingStarted) * num;
						num2 -= num * 5f;
						streamWriter.WriteLine(string.Concat(new string[]
						{
							"ROUND: ",
							string.Format("{0:D2}", Program.GameData.MatchInfo.RoundNumber),
							" | TIME: ",
							Program.GameData.MatchInfo.RoundTime,
							" | TICK: ",
							num2.ToString(),
							" | EVENT: ",
							Message
						}));
						if (!File.Exists(path2))
						{
							Program.GameData.CurrentMap.StartRecording();
						}
					}
					else
					{
						streamWriter.WriteLine(Message);
					}
				}
			}
			catch (IOException)
			{
			}
		}
	}
}
