using System;
using System.Reflection;
using System.Threading.Tasks;
using ScriptKidAntiCheat.Data;
using ScriptKidAntiCheat.Internal.Raw;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat.Internal
{
	// Token: 0x02000051 RID: 81
	public class MatchInfo
	{
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600016C RID: 364 RVA: 0x0000A04F File Offset: 0x0000824F
		// (set) Token: 0x0600016D RID: 365 RVA: 0x0000A057 File Offset: 0x00008257
		public IntPtr AddressBase { get; protected set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600016E RID: 366 RVA: 0x0000A060 File Offset: 0x00008260
		// (set) Token: 0x0600016F RID: 367 RVA: 0x0000A068 File Offset: 0x00008268
		public IntPtr GameRulesProxy { get; protected set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000170 RID: 368 RVA: 0x0000A071 File Offset: 0x00008271
		// (set) Token: 0x06000171 RID: 369 RVA: 0x0000A079 File Offset: 0x00008279
		public GlobalVars GlobalVars { get; protected set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000172 RID: 370 RVA: 0x0000A082 File Offset: 0x00008282
		// (set) Token: 0x06000173 RID: 371 RVA: 0x0000A08A File Offset: 0x0000828A
		public RoundResults RoundResults { get; protected set; }

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000174 RID: 372 RVA: 0x0000A094 File Offset: 0x00008294
		// (remove) Token: 0x06000175 RID: 373 RVA: 0x0000A0CC File Offset: 0x000082CC
		public event EventHandler OnMatchNewRound;

		// Token: 0x06000176 RID: 374 RVA: 0x0000A101 File Offset: 0x00008301
		protected IntPtr ReadAddressBase(GameProcess gameProcess)
		{
			return gameProcess.ModuleClient.Read(Offsets.dwLocalPlayer);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000A113 File Offset: 0x00008313
		protected IntPtr ReadGameRulesProxy(GameProcess gameProcess)
		{
			return gameProcess.ModuleClient.Read(Offsets.dwGameRulesProxy);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000A125 File Offset: 0x00008325
		protected GlobalVars ReadGlobalVars(GameProcess gameProcess)
		{
			return gameProcess.ModuleEngine.Read(Offsets.dwGlobalVars);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000A137 File Offset: 0x00008337
		public bool checkFreezetime(GameProcess gameProcess)
		{
			return this.GameRulesProxy != IntPtr.Zero && gameProcess.Process.Read(this.GameRulesProxy + Offsets.m_bFreezePeriod) == 1;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000A16C File Offset: 0x0000836C
		public bool checkWarmup(GameProcess gameProcess)
		{
			return this.GameRulesProxy != IntPtr.Zero && gameProcess.Process.Read(this.GameRulesProxy + Offsets.m_bWarmupPeriod);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000A19D File Offset: 0x0000839D
		public bool checkGameType(GameProcess gameProcess)
		{
			return this.GameRulesProxy != IntPtr.Zero && gameProcess.Process.Read(this.GameRulesProxy + Offsets.m_bIsQueuedMatchmaking) == 1;
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000A1D2 File Offset: 0x000083D2
		public bool checkBombPlanted(GameProcess gameProcess)
		{
			return this.GameRulesProxy != IntPtr.Zero && gameProcess.Process.Read(this.GameRulesProxy + Offsets.m_bBombPlanted) == 1;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000A207 File Offset: 0x00008407
		public int GetCurrentMatchRound(GameProcess gameProcess)
		{
			if (this.GameRulesProxy != IntPtr.Zero)
			{
				return gameProcess.Process.Read(this.GameRulesProxy + Offsets.m_totalRoundsPlayed) + 1;
			}
			return 0;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000A23C File Offset: 0x0000843C
		public string GetCurrentRoundTime(GameProcess gameProcess)
		{
			if (!(this.GameRulesProxy != IntPtr.Zero))
			{
				return "";
			}
			float num = gameProcess.Process.Read(this.GameRulesProxy + Offsets.m_fRoundStartTime);
			int num2 = gameProcess.Process.Read(this.GameRulesProxy + Offsets.m_IRoundTime);
			int num3 = (int)(num + (float)num2) - (int)this.GlobalVars.curtime;
			int num4 = num3 / 60;
			int num5 = num3 - num4 * 60;
			if (num5 < 0 || num5 < 0)
			{
				return "00:00";
			}
			return string.Format("{0:D2}", num4) + ":" + string.Format("{0:D2}", num5);
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000A2F0 File Offset: 0x000084F0
		public RoundResults GetRoundResults(GameProcess gameProcess)
		{
			if (this.GameRulesProxy != IntPtr.Zero)
			{
				return gameProcess.Process.Read(this.GameRulesProxy + 2480);
			}
			return default(RoundResults);
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000A334 File Offset: 0x00008534
		public bool Update(GameProcess gameProcess)
		{
			this.AddressBase = this.ReadAddressBase(gameProcess);
			this.GameRulesProxy = this.ReadGameRulesProxy(gameProcess);
			this.GlobalVars = this.ReadGlobalVars(gameProcess);
			this.isFreezeTime = this.checkFreezetime(gameProcess);
			this.isWarmup = this.checkWarmup(gameProcess);
			this.IsMatchmaking = this.checkGameType(gameProcess);
			this.isBombPlanted = this.checkBombPlanted(gameProcess);
			this.RoundNumber = this.GetCurrentMatchRound(gameProcess);
			this.RoundTime = this.GetCurrentRoundTime(gameProcess);
			this.RoundResults = this.GetRoundResults(gameProcess);
			int num = 0;
			int num2 = 0;
			FieldInfo[] fields = typeof(RoundResults).GetFields();
			for (int i = 0; i < fields.Length; i++)
			{
				int num3 = (int)fields[i].GetValue(this.RoundResults);
				if (num3 != 0)
				{
					if (num3 > 4)
					{
						num++;
					}
					else
					{
						num2++;
					}
				}
			}
			this.T_Score = num;
			this.CT_Score = num2;
			if (this.T_Score == 15 || this.CT_Score == 15)
			{
				this.isMatchPoint = true;
			}
			else
			{
				this.isMatchPoint = false;
			}
			if (this.RoundNumber != this.LastFreezeTimeRound && this.isFreezeTime)
			{
				this.LastFreezeTimeRound = this.RoundNumber;
				Task.Run(delegate()
				{
					EventHandler onMatchNewRound = this.OnMatchNewRound;
					if (onMatchNewRound == null)
					{
						return;
					}
					onMatchNewRound(this, null);
				});
			}
			return true;
		}

		// Token: 0x040002A9 RID: 681
		public bool isMatchPoint;

		// Token: 0x040002AA RID: 682
		public bool isFreezeTime;

		// Token: 0x040002AB RID: 683
		public bool isWarmup;

		// Token: 0x040002AC RID: 684
		public bool IsMatchmaking;

		// Token: 0x040002AD RID: 685
		public bool isBombPlanted;

		// Token: 0x040002AE RID: 686
		public int T_Score;

		// Token: 0x040002AF RID: 687
		public int CT_Score;

		// Token: 0x040002B0 RID: 688
		public int LastFreezeTimeRound = -1;

		// Token: 0x040002B1 RID: 689
		public int RoundNumber;

		// Token: 0x040002B2 RID: 690
		public string RoundTime = "";
	}
}
