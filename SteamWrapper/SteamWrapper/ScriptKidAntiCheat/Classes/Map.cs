using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ScriptKidAntiCheat.Punishments;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat.Classes
{
	// Token: 0x02000063 RID: 99
	public abstract class Map : IDisposable
	{
		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001D6 RID: 470 RVA: 0x0000B16E File Offset: 0x0000936E
		// (set) Token: 0x060001D7 RID: 471 RVA: 0x0000B176 File Offset: 0x00009376
		public virtual int map_id { get; set; }

		// Token: 0x060001D8 RID: 472 RVA: 0x0000B180 File Offset: 0x00009380
		protected Map()
		{
			Task.Run(delegate()
			{
				this.StartRecording();
			});
			this.Punishments.Add(new InvertMouseAds());
			this.Punishments.Add(new NoPlantOrDefuse());
			this.Punishments.Add(new NoSilentWalk());
			this.Punishments.Add(new FlashInYourFace());
			this.Punishments.Add(new NoSpray4U());
			this.Punishments.Add(new DoYouEvenAimBro());
			this.Punishments.Add(new BurningMan());
			this.Punishments.Add(new BigSpender());
			this.NewRound(null, null);
			Program.GameData.MatchInfo.OnMatchNewRound += this.NewRound;
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x0000B26C File Offset: 0x0000946C
		public void StartRecording()
		{
			Console.WriteLine("Started recording");
			this.RecordingStarted = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
			this.RecordingName = this.RecordingStarted.ToString() + "-" + base.GetType().Name;
			Program.GameConsole.SendCommand("stop; voice_scale 0; record " + this.RecordingName);
			Program.GameConsole.SendCommand("host_writeconfig reset.cfg");
			Thread.Sleep(1000);
			Program.GameConsole.SendCommand("clear");
			ReplayLogger.Log(Program.version, false, this.RecordingName);
		}

		// Token: 0x060001DA RID: 474 RVA: 0x0000B314 File Offset: 0x00009514
		public void resetTripWires()
		{
			Console.WriteLine("Reset traps");
			foreach (TripWire tripWire in this.TripWires)
			{
				tripWire.reset();
			}
		}

		// Token: 0x060001DB RID: 475 RVA: 0x0000B370 File Offset: 0x00009570
		public float GetRoundTime()
		{
			return 0f;
		}

		// Token: 0x060001DC RID: 476 RVA: 0x0000B377 File Offset: 0x00009577
		public virtual void NewRound(object sender, EventArgs e)
		{
			this.resetTripWires();
		}

		// Token: 0x060001DD RID: 477 RVA: 0x0000B380 File Offset: 0x00009580
		public void Dispose()
		{
			foreach (Punishment punishment in this.Punishments)
			{
				punishment.Dispose();
			}
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060001DE RID: 478 RVA: 0x0000B3E0 File Offset: 0x000095E0
		protected virtual void Dispose(bool disposing)
		{
			if (this.disposed)
			{
				return;
			}
			if (disposing)
			{
				Console.WriteLine("disposed");
			}
			this.disposed = true;
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0000B400 File Offset: 0x00009600
		public void tripWirePunishments(TripWire TripWire)
		{
			string str = "";
			if (Program.GameData.MatchInfo.RoundNumber > 10 || Program.Debug.TripWireStage == 3)
			{
				str = ((Map.stage3TripWirePunishments)new Random().Next(0, 2)).ToString();
			}
			else if (Program.GameData.MatchInfo.RoundNumber >= 3 || Program.Debug.TripWireStage == 2)
			{
				str = ((Map.stage2TripWirePunishments)new Random().Next(0, 2)).ToString();
			}
			else if (Program.GameData.MatchInfo.RoundNumber < 3 || Program.Debug.TripWireStage == 1)
			{
				str = ((Map.stage1TripWirePunishments)new Random().Next(0, 1)).ToString();
			}
			Activator.CreateInstance(Type.GetType("ScriptKidAntiCheat.Punishments." + str));
			Thread.Sleep(500);
			if (Program.Debug.ShowDebugMessages)
			{
				Program.GameConsole.SendCommand("Say \"TripWire Triggered (" + str + ")\"");
			}
		}

		// Token: 0x04000345 RID: 837
		private bool disposed;

		// Token: 0x04000347 RID: 839
		public string RecordingName = "";

		// Token: 0x04000348 RID: 840
		public List<Punishment> Punishments = new List<Punishment>();

		// Token: 0x04000349 RID: 841
		public List<TripWire> TripWires = new List<TripWire>();

		// Token: 0x0400034A RID: 842
		public long RecordingStarted;

		// Token: 0x02000064 RID: 100
		public enum stage1TripWirePunishments
		{
			// Token: 0x0400034C RID: 844
			NoCrosshairChallenge
		}

		// Token: 0x02000065 RID: 101
		public enum stage2TripWirePunishments
		{
			// Token: 0x0400034E RID: 846
			NoCrosshairChallenge,
			// Token: 0x0400034F RID: 847
			ButterFingers
		}

		// Token: 0x02000066 RID: 102
		public enum stage3TripWirePunishments
		{
			// Token: 0x04000351 RID: 849
			ViolenceSpeedMomentum,
			// Token: 0x04000352 RID: 850
			ButterFingers
		}
	}
}
