using System;
using System.Runtime.CompilerServices;
using System.Timers;
using Microsoft.CSharp.RuntimeBinder;
using SharpDX;

namespace ScriptKidAntiCheat.Utils
{
	// Token: 0x02000041 RID: 65
	public class TripWire
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x00008553 File Offset: 0x00006753
		// (set) Token: 0x060000F9 RID: 249 RVA: 0x0000855B File Offset: 0x0000675B
		public bool IsBeingTripped { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000FA RID: 250 RVA: 0x00008564 File Offset: 0x00006764
		// (set) Token: 0x060000FB RID: 251 RVA: 0x0000856C File Offset: 0x0000676C
		public bool disableOnTriggered { get; set; } = true;

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000FC RID: 252 RVA: 0x00008575 File Offset: 0x00006775
		// (set) Token: 0x060000FD RID: 253 RVA: 0x0000857D File Offset: 0x0000677D
		public bool resetOnLeave { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000FE RID: 254 RVA: 0x00008586 File Offset: 0x00006786
		// (set) Token: 0x060000FF RID: 255 RVA: 0x0000858E File Offset: 0x0000678E
		public bool checkFromMemory { get; set; }

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000100 RID: 256 RVA: 0x00008598 File Offset: 0x00006798
		// (remove) Token: 0x06000101 RID: 257 RVA: 0x000085D0 File Offset: 0x000067D0
		public event TripWire.TripWireTrigger OnTriggered;

		// Token: 0x06000102 RID: 258 RVA: 0x00008608 File Offset: 0x00006808
		public TripWire(dynamic points, int triggerChance = 100, Team triggerOnlyForTeam = Team.Unknown, int checkSpeed = 500)
		{
			if (TripWire.<>o__33.<>p__1 == null)
			{
				TripWire.<>o__33.<>p__1 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(TripWire)));
			}
			Func<CallSite, object, int> target = TripWire.<>o__33.<>p__1.Target;
			CallSite <>p__ = TripWire.<>o__33.<>p__1;
			if (TripWire.<>o__33.<>p__0 == null)
			{
				TripWire.<>o__33.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "x1", typeof(TripWire), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			this.x1 = target(<>p__, TripWire.<>o__33.<>p__0.Target(TripWire.<>o__33.<>p__0, points));
			if (TripWire.<>o__33.<>p__3 == null)
			{
				TripWire.<>o__33.<>p__3 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(TripWire)));
			}
			Func<CallSite, object, int> target2 = TripWire.<>o__33.<>p__3.Target;
			CallSite <>p__2 = TripWire.<>o__33.<>p__3;
			if (TripWire.<>o__33.<>p__2 == null)
			{
				TripWire.<>o__33.<>p__2 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "y1", typeof(TripWire), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			this.y1 = target2(<>p__2, TripWire.<>o__33.<>p__2.Target(TripWire.<>o__33.<>p__2, points));
			if (TripWire.<>o__33.<>p__5 == null)
			{
				TripWire.<>o__33.<>p__5 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(TripWire)));
			}
			Func<CallSite, object, int> target3 = TripWire.<>o__33.<>p__5.Target;
			CallSite <>p__3 = TripWire.<>o__33.<>p__5;
			if (TripWire.<>o__33.<>p__4 == null)
			{
				TripWire.<>o__33.<>p__4 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "x2", typeof(TripWire), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			this.x2 = target3(<>p__3, TripWire.<>o__33.<>p__4.Target(TripWire.<>o__33.<>p__4, points));
			if (TripWire.<>o__33.<>p__7 == null)
			{
				TripWire.<>o__33.<>p__7 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(TripWire)));
			}
			Func<CallSite, object, int> target4 = TripWire.<>o__33.<>p__7.Target;
			CallSite <>p__4 = TripWire.<>o__33.<>p__7;
			if (TripWire.<>o__33.<>p__6 == null)
			{
				TripWire.<>o__33.<>p__6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "y2", typeof(TripWire), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			this.y2 = target4(<>p__4, TripWire.<>o__33.<>p__6.Target(TripWire.<>o__33.<>p__6, points));
			if (TripWire.<>o__33.<>p__9 == null)
			{
				TripWire.<>o__33.<>p__9 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(TripWire)));
			}
			Func<CallSite, object, int> target5 = TripWire.<>o__33.<>p__9.Target;
			CallSite <>p__5 = TripWire.<>o__33.<>p__9;
			if (TripWire.<>o__33.<>p__8 == null)
			{
				TripWire.<>o__33.<>p__8 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "x3", typeof(TripWire), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			this.x3 = target5(<>p__5, TripWire.<>o__33.<>p__8.Target(TripWire.<>o__33.<>p__8, points));
			if (TripWire.<>o__33.<>p__11 == null)
			{
				TripWire.<>o__33.<>p__11 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(TripWire)));
			}
			Func<CallSite, object, int> target6 = TripWire.<>o__33.<>p__11.Target;
			CallSite <>p__6 = TripWire.<>o__33.<>p__11;
			if (TripWire.<>o__33.<>p__10 == null)
			{
				TripWire.<>o__33.<>p__10 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "y3", typeof(TripWire), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			this.y3 = target6(<>p__6, TripWire.<>o__33.<>p__10.Target(TripWire.<>o__33.<>p__10, points));
			if (TripWire.<>o__33.<>p__13 == null)
			{
				TripWire.<>o__33.<>p__13 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(TripWire)));
			}
			Func<CallSite, object, int> target7 = TripWire.<>o__33.<>p__13.Target;
			CallSite <>p__7 = TripWire.<>o__33.<>p__13;
			if (TripWire.<>o__33.<>p__12 == null)
			{
				TripWire.<>o__33.<>p__12 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "x4", typeof(TripWire), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			this.x4 = target7(<>p__7, TripWire.<>o__33.<>p__12.Target(TripWire.<>o__33.<>p__12, points));
			if (TripWire.<>o__33.<>p__15 == null)
			{
				TripWire.<>o__33.<>p__15 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(TripWire)));
			}
			Func<CallSite, object, int> target8 = TripWire.<>o__33.<>p__15.Target;
			CallSite <>p__8 = TripWire.<>o__33.<>p__15;
			if (TripWire.<>o__33.<>p__14 == null)
			{
				TripWire.<>o__33.<>p__14 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "y4", typeof(TripWire), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			this.y4 = target8(<>p__8, TripWire.<>o__33.<>p__14.Target(TripWire.<>o__33.<>p__14, points));
			if (TripWire.<>o__33.<>p__17 == null)
			{
				TripWire.<>o__33.<>p__17 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(TripWire)));
			}
			Func<CallSite, object, int> target9 = TripWire.<>o__33.<>p__17.Target;
			CallSite <>p__9 = TripWire.<>o__33.<>p__17;
			if (TripWire.<>o__33.<>p__16 == null)
			{
				TripWire.<>o__33.<>p__16 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "z", typeof(TripWire), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			this.z = target9(<>p__9, TripWire.<>o__33.<>p__16.Target(TripWire.<>o__33.<>p__16, points));
			this.chance = triggerChance;
			this.active = true;
			this.triggerForTeam = triggerOnlyForTeam;
			TripWire.ticker = new Timer((double)checkSpeed);
			TripWire.ticker.Elapsed += this.checkTripWire;
			TripWire.ticker.AutoReset = true;
			TripWire.ticker.Enabled = true;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00008B80 File Offset: 0x00006D80
		public void checkTripWire(object source, ElapsedEventArgs e)
		{
			if (!Program.GameProcess.IsValid || !Program.GameData.Player.IsAlive() || (Program.GameData.MatchInfo.isWarmup && !Program.Debug.AllowInWarmup))
			{
				return;
			}
			if (!this.active && !this.resetOnLeave)
			{
				return;
			}
			this.IsBeingTripped = this.isTripWireBeingTripped();
			if (this.IsBeingTripped)
			{
				if (this.active)
				{
					this.TripWireTriggeredCallback();
					return;
				}
			}
			else if (this.resetOnLeave && !this.active)
			{
				this.active = true;
			}
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00008C14 File Offset: 0x00006E14
		public bool isTripWireBeingTripped()
		{
			Vector3 vector;
			if (!this.checkFromMemory)
			{
				vector = Program.GameData.Player.EyePosition;
			}
			else
			{
				vector = Program.GameData.Player.getPlayerEyePosition(Program.GameProcess);
			}
			return TripWire.is_player_at_location(this.x1, this.y1, this.x2, this.y2, this.x3, this.y3, this.x4, this.y4, this.z, (int)vector.X, (int)vector.Y, (int)vector.Z) && (this.triggerForTeam == Team.Unknown || Program.GameData.Player.Team == this.triggerForTeam);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00008CC8 File Offset: 0x00006EC8
		public void TripWireTriggeredCallback()
		{
			if (this.disableOnTriggered)
			{
				this.active = false;
			}
			if (this.chance != 100)
			{
				if (new Random().Next(100) >= 100 - this.chance)
				{
					this.OnTriggered(this);
					return;
				}
			}
			else
			{
				this.OnTriggered(this);
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00008D1E File Offset: 0x00006F1E
		private static float area(int x1, int y1, int x2, int y2, int x3, int y3)
		{
			return (float)Math.Abs((double)(x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2.0);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00008D48 File Offset: 0x00006F48
		private static bool is_player_at_location(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int z, int playerX, int playerY, int playerZ)
		{
			if (z != 0 && playerZ < z)
			{
				return false;
			}
			if (playerX == 0 && playerY == 0 && playerZ == 0)
			{
				return false;
			}
			float num = TripWire.area(x1, y1, x2, y2, x3, y3) + TripWire.area(x1, y1, x4, y4, x3, y3);
			float num2 = TripWire.area(playerX, playerY, x1, y1, x2, y2);
			float num3 = TripWire.area(playerX, playerY, x2, y2, x3, y3);
			float num4 = TripWire.area(playerX, playerY, x3, y3, x4, y4);
			float num5 = TripWire.area(playerX, playerY, x1, y1, x4, y4);
			return num == num2 + num3 + num4 + num5;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00008DD5 File Offset: 0x00006FD5
		public void reset()
		{
			this.active = true;
		}

		// Token: 0x04000249 RID: 585
		public bool active;

		// Token: 0x0400024B RID: 587
		public int x1;

		// Token: 0x0400024C RID: 588
		public int y1;

		// Token: 0x0400024D RID: 589
		public int x2;

		// Token: 0x0400024E RID: 590
		public int y2;

		// Token: 0x0400024F RID: 591
		public int x3;

		// Token: 0x04000250 RID: 592
		public int y3;

		// Token: 0x04000251 RID: 593
		public int x4;

		// Token: 0x04000252 RID: 594
		public int y4;

		// Token: 0x04000253 RID: 595
		public int z;

		// Token: 0x04000254 RID: 596
		public Team triggerForTeam;

		// Token: 0x04000255 RID: 597
		public int chance;

		// Token: 0x0400025A RID: 602
		private static Timer ticker;

		// Token: 0x02000042 RID: 66
		// (Invoke) Token: 0x0600010A RID: 266
		public delegate void TripWireTrigger(TripWire TripWire);
	}
}
