using System;
using ScriptKidAntiCheat.Classes;
using ScriptKidAntiCheat.Punishments;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat
{
	// Token: 0x02000012 RID: 18
	internal class de_mirage : Map
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000048 RID: 72 RVA: 0x000060FB File Offset: 0x000042FB
		// (set) Token: 0x06000049 RID: 73 RVA: 0x00006103 File Offset: 0x00004303
		public override int map_id { get; set; } = 1834968420;

		// Token: 0x0600004A RID: 74 RVA: 0x0000610C File Offset: 0x0000430C
		public de_mirage()
		{
			if (Program.Debug.ShowDebugMessages)
			{
				TripWire tripWire = new TripWire(new
				{
					x1 = 1032,
					y1 = 351,
					x2 = 957,
					y2 = 431,
					x3 = 964,
					y3 = 673,
					x4 = 1135,
					y4 = 646,
					z = 0
				}, 100, Team.Terrorists, 500);
				tripWire.OnTriggered += base.tripWirePunishments;
				this.TripWires.Add(tripWire);
			}
			TripWire tripWire2 = new TripWire(new
			{
				x1 = -1952,
				y1 = 675,
				x2 = -2093,
				y2 = 671,
				x3 = -2089,
				y3 = 831,
				x4 = -1952,
				y4 = 849,
				z = 0
			}, 50, Team.Terrorists, 500);
			tripWire2.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire2);
			TripWire tripWire3 = new TripWire(new
			{
				x1 = -1723,
				y1 = 629,
				x2 = -1722,
				y2 = 523,
				x3 = -1858,
				y3 = 534,
				x4 = -1865,
				y4 = 629,
				z = 24
			}, 50, Team.Terrorists, 500);
			tripWire3.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire3);
			TripWire tripWire4 = new TripWire(new
			{
				x1 = -824,
				y1 = -843,
				x2 = -534,
				y2 = -846,
				x3 = -505,
				y3 = -1268,
				x4 = -833,
				y4 = -1251,
				z = 0
			}, 50, Team.Terrorists, 500);
			tripWire4.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire4);
			TripWire tripWire5 = new TripWire(new
			{
				x1 = -676,
				y1 = -241,
				x2 = -945,
				y2 = -295,
				x3 = -968,
				y3 = -21,
				x4 = -704,
				y4 = -22,
				z = 0
			}, 50, Team.Terrorists, 500);
			tripWire5.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire5);
			TripWire tripWire6 = new TripWire(new
			{
				x1 = 50,
				y1 = -1358,
				x2 = 38,
				y2 = -1650,
				x3 = -138,
				y3 = -1653,
				x4 = -165,
				y4 = -1365,
				z = -93
			}, 50, Team.Terrorists, 500);
			tripWire6.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire6);
			TripWire tripWire7 = new TripWire(new
			{
				x1 = -1098,
				y1 = -539,
				x2 = -1097,
				y2 = -763,
				x3 = -1073,
				y3 = -758,
				x4 = -1067,
				y4 = -520,
				z = -143
			}, 100, Team.Unknown, 50);
			tripWire7.checkFromMemory = true;
			tripWire7.OnTriggered += this.DropWeaponsBehindMe;
			this.TripWires.Add(tripWire7);
			TripWire tripWire8 = new TripWire(new
			{
				x1 = -21,
				y1 = -2166,
				x2 = -18,
				y2 = -2020,
				x3 = 150,
				y3 = -2031,
				x4 = 87,
				y4 = -2185,
				z = 0
			}, 50, Team.Terrorists, 500);
			tripWire8.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire8);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00006408 File Offset: 0x00004608
		public void DropWeaponsBehindMe(TripWire TripWire)
		{
			new Yeeeeeeeet(TripWire, -8000, -500, 10000, 0);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00006421 File Offset: 0x00004621
		public void debugging_tripwire(TripWire TripWire)
		{
		}
	}
}
