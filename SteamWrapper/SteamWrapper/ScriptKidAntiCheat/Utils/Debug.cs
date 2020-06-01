using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ScriptKidAntiCheat.Utils
{
	// Token: 0x0200003D RID: 61
	public class Debug
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00007F60 File Offset: 0x00006160
		// (set) Token: 0x060000DC RID: 220 RVA: 0x00007F68 File Offset: 0x00006168
		public bool AllowLocal { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00007F71 File Offset: 0x00006171
		// (set) Token: 0x060000DE RID: 222 RVA: 0x00007F79 File Offset: 0x00006179
		public bool AllowInWarmup { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00007F82 File Offset: 0x00006182
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x00007F8A File Offset: 0x0000618A
		public bool IgnoreActivateOnRound { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00007F93 File Offset: 0x00006193
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x00007F9B File Offset: 0x0000619B
		public int TripWireStage { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00007FA4 File Offset: 0x000061A4
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x00007FAC File Offset: 0x000061AC
		public bool DisableRunInBackground { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00007FB5 File Offset: 0x000061B5
		// (set) Token: 0x060000E6 RID: 230 RVA: 0x00007FBD File Offset: 0x000061BD
		public bool DisableGoogleDriveUpload { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00007FC6 File Offset: 0x000061C6
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x00007FCE File Offset: 0x000061CE
		public bool DisableAcceptConditions { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x00007FD7 File Offset: 0x000061D7
		// (set) Token: 0x060000EA RID: 234 RVA: 0x00007FDF File Offset: 0x000061DF
		public bool ShowDebugMessages { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000EB RID: 235 RVA: 0x00007FE8 File Offset: 0x000061E8
		// (set) Token: 0x060000EC RID: 236 RVA: 0x00007FF0 File Offset: 0x000061F0
		public bool SkipAnalyticsTracking { get; set; }

		// Token: 0x060000ED RID: 237 RVA: 0x00007FFC File Offset: 0x000061FC
		public Debug()
		{
			if (File.Exists("debug.txt"))
			{
				typeof(Debug).GetFields();
				StreamReader streamReader = new StreamReader("debug.txt");
				string input;
				while ((input = streamReader.ReadLine()) != null)
				{
					Match match = Regex.Match(input, "\\A(?<name>.+)=(?<value>.+)\\z");
					if (match.Success)
					{
						string name = Regex.Replace(match.Groups["name"].Value, "\\s+", "");
						string text = Regex.Replace(match.Groups["value"].Value, "\\s+", "");
						int num;
						bool flag = int.TryParse(text, out num);
						if (text.ToLower() == "true" || text.ToLower() == "false")
						{
							base.GetType().GetProperty(name).SetValue(this, text == "true");
						}
						else if (flag)
						{
							base.GetType().GetProperty(name).SetValue(this, num);
						}
					}
				}
			}
		}
	}
}
