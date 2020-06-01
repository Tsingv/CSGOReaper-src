using System;
using ScriptKidAntiCheat.Classes;
using ScriptKidAntiCheat.Punishments;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat
{
	// Token: 0x0200000E RID: 14
	internal class de_nuke : Map
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000039 RID: 57 RVA: 0x000059F8 File Offset: 0x00003BF8
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00005A00 File Offset: 0x00003C00
		public override int map_id { get; set; } = 1851745636;

		// Token: 0x0600003B RID: 59 RVA: 0x00005A0C File Offset: 0x00003C0C
		public de_nuke()
		{
			TripWire tripWire = new TripWire(new
			{
				x1 = 320,
				y1 = -887,
				x2 = 321,
				y2 = -796,
				x3 = 478,
				y3 = -788,
				x4 = 477,
				y4 = -891,
				z = -351
			}, 50, Team.Terrorists, 500);
			tripWire.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire);
			TripWire tripWire2 = new TripWire(new
			{
				x1 = 765,
				y1 = -1467,
				x2 = 391,
				y2 = -1482,
				x3 = 391,
				y3 = -1207,
				x4 = 799,
				y4 = -1208,
				z = -351
			}, 50, Team.Terrorists, 500);
			tripWire2.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire2);
			TripWire tripWire3 = new TripWire(new
			{
				x1 = 95,
				y1 = -1163,
				x2 = 104,
				y2 = -1378,
				x3 = 467,
				y3 = -1369,
				x4 = 446,
				y4 = -1193,
				z = 0
			}, 100, Team.Unknown, 500);
			tripWire3.resetOnLeave = true;
			tripWire3.OnTriggered += this.KnockKnocWhosThere;
			this.TripWires.Add(tripWire3);
			TripWire tripWire4 = new TripWire(new
			{
				x1 = 931,
				y1 = -882,
				x2 = 1196,
				y2 = -872,
				x3 = 1205,
				y3 = -1167,
				x4 = 964,
				y4 = -1162,
				z = 0
			}, 100, Team.Unknown, 500);
			tripWire4.resetOnLeave = true;
			tripWire4.OnTriggered += this.KnockKnocWhosThere;
			this.TripWires.Add(tripWire4);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00005BA2 File Offset: 0x00003DA2
		public void KnockKnocWhosThere(TripWire TripWire)
		{
			Console.WriteLine("test");
			new KnockKnockWhosThere(TripWire);
		}
	}
}
