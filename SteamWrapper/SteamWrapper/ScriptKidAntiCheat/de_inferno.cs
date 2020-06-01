using System;
using ScriptKidAntiCheat.Classes;
using ScriptKidAntiCheat.Punishments;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat
{
	// Token: 0x0200000F RID: 15
	internal class de_inferno : Map
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00005BB5 File Offset: 0x00003DB5
		// (set) Token: 0x0600003E RID: 62 RVA: 0x00005BBD File Offset: 0x00003DBD
		public override int map_id { get; set; } = 1767859556;

		// Token: 0x0600003F RID: 63 RVA: 0x00005BC8 File Offset: 0x00003DC8
		public de_inferno()
		{
			this.Punishments.Add(new BurningMan());
			TripWire tripWire = new TripWire(new
			{
				x1 = 1928,
				y1 = 178,
				x2 = 2016,
				y2 = 180,
				x3 = 2024,
				y3 = -262,
				x4 = 1934,
				y4 = -261,
				z = 0
			}, 50, Team.Terrorists, 500);
			tripWire.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire);
			TripWire tripWire2 = new TripWire(new
			{
				x1 = 1796,
				y1 = -251,
				x2 = 1793,
				y2 = -395,
				x3 = 1708,
				y3 = -383,
				x4 = 1709,
				y4 = -246,
				z = 0
			}, 100, Team.Unknown, 50);
			tripWire2.checkFromMemory = true;
			tripWire2.OnTriggered += this.DropThatGun;
			this.TripWires.Add(tripWire2);
			TripWire tripWire3 = new TripWire(new
			{
				x1 = 661,
				y1 = 2292,
				x2 = 910,
				y2 = 2320,
				x3 = 908,
				y3 = 2436,
				x4 = 653,
				y4 = 2428,
				z = 0
			}, 50, Team.Terrorists, 50);
			tripWire3.OnTriggered += base.tripWirePunishments;
			this.TripWires.Add(tripWire3);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00005D08 File Offset: 0x00003F08
		public void DropThatGun(TripWire TripWire)
		{
			if (Program.GameData.Player.AimDirection.X < 0f)
			{
				new Yeeeeeeeet(TripWire, -5000, -1000, 5000, 1000);
				return;
			}
			new Yeeeeeeeet(TripWire, 5000, -1000, -5000, 1000);
		}
	}
}
