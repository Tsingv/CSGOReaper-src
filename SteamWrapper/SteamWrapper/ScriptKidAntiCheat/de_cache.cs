using System;
using ScriptKidAntiCheat.Classes;
using ScriptKidAntiCheat.Punishments;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat
{
	// Token: 0x0200000D RID: 13
	internal class de_cache : Map
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00005856 File Offset: 0x00003A56
		// (set) Token: 0x06000036 RID: 54 RVA: 0x0000585E File Offset: 0x00003A5E
		public override int map_id { get; set; } = 1667196260;

		// Token: 0x06000037 RID: 55 RVA: 0x00005868 File Offset: 0x00003A68
		public de_cache()
		{
			TripWire tripWire = new TripWire(new
			{
				x1 = 226,
				y1 = -886,
				x2 = 220,
				y2 = -448,
				x3 = -426,
				y3 = -458,
				x4 = -428,
				y4 = -1034,
				z = 0
			}, 50, Team.Terrorists, 500);
			tripWire.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire);
			TripWire tripWire2 = new TripWire(new
			{
				x1 = 483,
				y1 = 1598,
				x2 = 830,
				y2 = 1639,
				x3 = 851,
				y3 = 1832,
				x4 = 504,
				y4 = 1818,
				z = 0
			}, 50, Team.Terrorists, 500);
			tripWire2.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire2);
			TripWire tripWire3 = new TripWire(new
			{
				x1 = -336,
				y1 = 1080,
				x2 = -10,
				y2 = 1120,
				x3 = -17,
				y3 = 958,
				x4 = -350,
				y4 = 937,
				z = 0
			}, 50, Team.Terrorists, 500);
			tripWire3.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire3);
			TripWire tripWire4 = new TripWire(new
			{
				x1 = 352,
				y1 = 1957,
				x2 = 131,
				y2 = 1936,
				x3 = 141,
				y3 = 2224,
				x4 = 365,
				y4 = 2230,
				z = 0
			}, 100, Team.Unknown, 500);
			tripWire4.resetOnLeave = true;
			tripWire4.OnTriggered += this.KnockKnocWhosThere;
			this.TripWires.Add(tripWire4);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000059EF File Offset: 0x00003BEF
		public void KnockKnocWhosThere(TripWire TripWire)
		{
			new KnockKnockWhosThere(TripWire);
		}
	}
}
