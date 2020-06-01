using System;
using ScriptKidAntiCheat.Classes;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat
{
	// Token: 0x02000010 RID: 16
	internal class de_dust2 : Map
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00005D67 File Offset: 0x00003F67
		// (set) Token: 0x06000042 RID: 66 RVA: 0x00005D6F File Offset: 0x00003F6F
		public override int map_id { get; set; } = 1683973476;

		// Token: 0x06000043 RID: 67 RVA: 0x00005D78 File Offset: 0x00003F78
		public de_dust2()
		{
			TripWire tripWire = new TripWire(new
			{
				x1 = 1222,
				y1 = 1998,
				x2 = 1692,
				y2 = 1756,
				x3 = 1845,
				y3 = 2139,
				x4 = 1212,
				y4 = 2096,
				z = 0
			}, 50, Team.Terrorists, 500);
			tripWire.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire);
			TripWire tripWire2 = new TripWire(new
			{
				x1 = 552,
				y1 = 1811,
				x2 = 231,
				y2 = 1849,
				x3 = 196,
				y3 = 2041,
				x4 = 554,
				y4 = 2031,
				z = 0
			}, 50, Team.Terrorists, 500);
			tripWire2.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire2);
			TripWire tripWire3 = new TripWire(new
			{
				x1 = -1828,
				y1 = 1798,
				x2 = -2167,
				y2 = 1788,
				x3 = -2163,
				y3 = 1880,
				x4 = -1830,
				y4 = 1874,
				z = 0
			}, 50, Team.Terrorists, 500);
			tripWire3.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire3);
			TripWire tripWire4 = new TripWire(new
			{
				x1 = -1376,
				y1 = 2257,
				x2 = -1299,
				y2 = 2310,
				x3 = -1278,
				y3 = 2063,
				x4 = -1362,
				y4 = 2091,
				z = 0
			}, 50, Team.Terrorists, 500);
			tripWire4.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire4);
		}
	}
}
