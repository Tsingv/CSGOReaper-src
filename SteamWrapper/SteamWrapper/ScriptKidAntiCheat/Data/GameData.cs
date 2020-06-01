using System;
using System.Linq;
using ScriptKidAntiCheat.Classes;
using ScriptKidAntiCheat.Internal;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat.Data
{
	// Token: 0x0200005F RID: 95
	public class GameData : U_ThreadedComponent
	{
		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x0000A88D File Offset: 0x00008A8D
		protected override string ThreadName
		{
			get
			{
				return "GameData";
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x0000A894 File Offset: 0x00008A94
		// (set) Token: 0x060001A4 RID: 420 RVA: 0x0000A89C File Offset: 0x00008A9C
		private GameProcess GameProcess { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x0000A8A5 File Offset: 0x00008AA5
		// (set) Token: 0x060001A6 RID: 422 RVA: 0x0000A8AD File Offset: 0x00008AAD
		public Player Player { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x0000A8B6 File Offset: 0x00008AB6
		// (set) Token: 0x060001A8 RID: 424 RVA: 0x0000A8BE File Offset: 0x00008ABE
		public Map CurrentMap { get; set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x0000A8C7 File Offset: 0x00008AC7
		// (set) Token: 0x060001AA RID: 426 RVA: 0x0000A8CF File Offset: 0x00008ACF
		public MatchInfo MatchInfo { get; set; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060001AB RID: 427 RVA: 0x0000A8D8 File Offset: 0x00008AD8
		// (set) Token: 0x060001AC RID: 428 RVA: 0x0000A8E0 File Offset: 0x00008AE0
		public Entity[] Entities { get; private set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001AD RID: 429 RVA: 0x0000A8E9 File Offset: 0x00008AE9
		// (set) Token: 0x060001AE RID: 430 RVA: 0x0000A8F1 File Offset: 0x00008AF1
		public int PlayerID { get; private set; }

		// Token: 0x060001AF RID: 431 RVA: 0x0000A8FC File Offset: 0x00008AFC
		public GameData(GameProcess gameProcess)
		{
			this.GameProcess = gameProcess;
			this.Player = new Player();
			this.MatchInfo = new MatchInfo();
			this.Entities = (from index in Enumerable.Range(0, 64)
			select new Entity(index)).ToArray<Entity>();
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0000A963 File Offset: 0x00008B63
		public override void Dispose()
		{
			base.Dispose();
			this.MatchInfo = null;
			this.Entities = null;
			this.Player = null;
			this.GameProcess = null;
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0000A988 File Offset: 0x00008B88
		protected override void FrameAction()
		{
			if (!this.GameProcess.IsValid)
			{
				return;
			}
			this.GameProcess.ModuleClient.Read(85535256);
			this.Player.Update(this.GameProcess);
			this.MatchInfo.Update(this.GameProcess);
			Entity[] entities = this.Entities;
			for (int i = 0; i < entities.Length; i++)
			{
				entities[i].Update(this.GameProcess);
			}
		}
	}
}
