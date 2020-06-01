using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ScriptKidAntiCheat.Utils
{
	// Token: 0x0200003B RID: 59
	public static class Offsets
	{
		// Token: 0x060000D8 RID: 216 RVA: 0x00007E00 File Offset: 0x00006000
		static Offsets()
		{
			FieldInfo[] fields = typeof(Offsets).GetFields();
			try
			{
				StreamReader streamReader;
				if (File.Exists("Offsets\\offsets.txt"))
				{
					streamReader = new StreamReader("Offsets\\offsets.txt");
				}
				else
				{
					streamReader = new StreamReader(new WebClient().OpenRead("https://gitlab.com/sheetergang/csgo-memory-offsets/-/raw/master/offsets.txt"));
				}
				string input;
				while ((input = streamReader.ReadLine()) != null)
				{
					Match match = Regex.Match(input, "\\A(?<name>.+) = (?<value>.+)\\z");
					if (match.Success)
					{
						string value = match.Groups["value"].Value;
						int num;
						if (int.TryParse(value, out num) || int.TryParse(value.Substring(2, value.Length - 2), NumberStyles.HexNumber, null, out num))
						{
							FieldInfo fieldInfo = fields.FirstOrDefault((FieldInfo fi) => string.Equals(fi.Name, match.Groups["name"].Value) && fi.FieldType == typeof(int));
							if (fieldInfo != null)
							{
								fieldInfo.SetValue(null, num);
							}
						}
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Could not load memory offsets", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Environment.Exit(0);
			}
		}

		// Token: 0x04000211 RID: 529
		public const string OffsetsURL = "https://gitlab.com/sheetergang/csgo-memory-offsets/-/raw/master/offsets.txt";

		// Token: 0x04000212 RID: 530
		public const int MAXSTUDIOBONES = 128;

		// Token: 0x04000213 RID: 531
		public const float weapon_recoil_scale = 2f;

		// Token: 0x04000214 RID: 532
		public static int dwClientState;

		// Token: 0x04000215 RID: 533
		public static int dwClientState_Map;

		// Token: 0x04000216 RID: 534
		public static int dwClientState_ViewAngles;

		// Token: 0x04000217 RID: 535
		public static int dwLocalPlayer;

		// Token: 0x04000218 RID: 536
		public static int dwEntityList;

		// Token: 0x04000219 RID: 537
		public static int m_bDormant;

		// Token: 0x0400021A RID: 538
		public static int m_pStudioHdr;

		// Token: 0x0400021B RID: 539
		public static int dwGameRulesProxy;

		// Token: 0x0400021C RID: 540
		public static int dwGlobalVars;

		// Token: 0x0400021D RID: 541
		public static int m_vecOrigin;

		// Token: 0x0400021E RID: 542
		public static int m_vecViewOffset;

		// Token: 0x0400021F RID: 543
		public static int m_vecVelocity;

		// Token: 0x04000220 RID: 544
		public static int m_dwBoneMatrix;

		// Token: 0x04000221 RID: 545
		public static int m_lifeState;

		// Token: 0x04000222 RID: 546
		public static int m_iHealth;

		// Token: 0x04000223 RID: 547
		public static int m_iTeamNum;

		// Token: 0x04000224 RID: 548
		public static int m_bIsQueuedMatchmaking;

		// Token: 0x04000225 RID: 549
		public static int m_bBombPlanted;

		// Token: 0x04000226 RID: 550
		public static int m_hActiveWeapon;

		// Token: 0x04000227 RID: 551
		public static int m_iItemDefinitionIndex;

		// Token: 0x04000228 RID: 552
		public static int m_bIsDefusing;

		// Token: 0x04000229 RID: 553
		public static int m_bHasDefuser;

		// Token: 0x0400022A RID: 554
		public static int m_bIsScoped;

		// Token: 0x0400022B RID: 555
		public static int m_iShotsFired;

		// Token: 0x0400022C RID: 556
		public static int m_aimPunchAngle;

		// Token: 0x0400022D RID: 557
		public static int m_bStartedArming;

		// Token: 0x0400022E RID: 558
		public static int m_bFreezePeriod;

		// Token: 0x0400022F RID: 559
		public static int m_bWarmupPeriod;

		// Token: 0x04000230 RID: 560
		public static int m_totalRoundsPlayed;

		// Token: 0x04000231 RID: 561
		public static int m_fRoundStartTime;

		// Token: 0x04000232 RID: 562
		public static int m_IRoundTime;

		// Token: 0x04000233 RID: 563
		public static int m_iFOV;
	}
}
