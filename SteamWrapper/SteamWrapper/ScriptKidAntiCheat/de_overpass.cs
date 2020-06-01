using System;
using ScriptKidAntiCheat.Classes;
using ScriptKidAntiCheat.Punishments;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat
{
	// Token: 0x02000011 RID: 17
	internal class de_overpass : Map
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00005EFE File Offset: 0x000040FE
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00005F06 File Offset: 0x00004106
		public override int map_id { get; set; } = 1868522852;

		// Token: 0x06000046 RID: 70 RVA: 0x00005F10 File Offset: 0x00004110
		public de_overpass()
		{
			TripWire tripWire = new TripWire(new
			{
				x1 = -587,
				y1 = -163,
				x2 = -360,
				y2 = -194,
				x3 = -388,
				y3 = -253,
				x4 = -587,
				y4 = -265,
				z = 0
			}, 50, Team.Terrorists, 500);
			tripWire.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire);
			TripWire tripWire2 = new TripWire(new
			{
				x1 = -1042,
				y1 = -508,
				x2 = -856,
				y2 = -536,
				x3 = -856,
				y3 = -638,
				x4 = -1036,
				y4 = -638,
				z = 0
			}, 50, Team.Terrorists, 500);
			tripWire2.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire2);
			TripWire tripWire3 = new TripWire(new
			{
				x1 = -3118,
				y1 = 598,
				x2 = -3088,
				y2 = 812,
				x3 = -2842,
				y3 = 718,
				x4 = -2908,
				y4 = 564,
				z = 0
			}, 50, Team.Terrorists, 500);
			tripWire3.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire3);
			TripWire tripWire4 = new TripWire(new
			{
				x1 = -2303,
				y1 = 298,
				x2 = -2348,
				y2 = 199,
				x3 = -2776,
				y3 = 421,
				x4 = -2729,
				y4 = 521,
				z = 0
			}, 50, Team.Terrorists, 500);
			tripWire4.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire4);
			TripWire tripWire5 = new TripWire(new
			{
				x1 = -1572,
				y1 = -738,
				x2 = -1591,
				y2 = -1107,
				x3 = -1878,
				y3 = -1112,
				x4 = -1888,
				y4 = -727,
				z = 0
			}, 100, Team.Unknown, 500);
			tripWire5.resetOnLeave = true;
			tripWire5.OnTriggered += this.KnockKnocWhosThere;
			this.TripWires.Add(tripWire5);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000059EF File Offset: 0x00003BEF
		public void KnockKnocWhosThere(TripWire TripWire)
		{
			new KnockKnockWhosThere(TripWire);
		}
	}
}
