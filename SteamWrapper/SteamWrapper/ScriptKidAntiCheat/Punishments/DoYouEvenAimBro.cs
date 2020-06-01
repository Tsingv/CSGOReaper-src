using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using ScriptKidAntiCheat.Internal;
using ScriptKidAntiCheat.Internal.Raw;
using ScriptKidAntiCheat.Utils;
using ScriptKidAntiCheat.Utils.Maths;
using SharpDX;

namespace ScriptKidAntiCheat.Punishments
{
	// Token: 0x02000035 RID: 53
	internal class DoYouEvenAimBro : Punishment
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x00007761 File Offset: 0x00005961
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x00007769 File Offset: 0x00005969
		public override int ActivateOnRound { get; set; } = 8;

		// Token: 0x060000C5 RID: 197 RVA: 0x00007772 File Offset: 0x00005972
		public DoYouEvenAimBro() : base(0, false, 100)
		{
			base.GameData = Program.GameData;
			base.Player = Program.GameData.Player;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000077A0 File Offset: 0x000059A0
		public override void Tick(object source, ElapsedEventArgs e)
		{
			if (!Program.GameProcess.IsValid || !base.Player.IsAlive() || !base.CanActivate())
			{
				return;
			}
			Vector3 aimDirection = base.Player.AimDirection;
			Vector3 eyePosition = base.Player.EyePosition;
			if ((double)aimDirection.Length() < 0.001)
			{
				return;
			}
			Line3D aimRayWorld = new Line3D(eyePosition, eyePosition + aimDirection * 8192f);
			Team team = base.Player.Team;
			foreach (Entity entity in base.GameData.Entities)
			{
				if (entity.IsAlive() && !(entity.AddressBase == base.Player.AddressBase))
				{
					if (DoYouEvenAimBro.IntersectsHitBox(aimRayWorld, entity) >= 0)
					{
						this.ActivatePunishment(entity.Team);
					}
					Thread.Sleep(10);
				}
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00007888 File Offset: 0x00005A88
		public static int IntersectsHitBox(Line3D aimRayWorld, Entity entity)
		{
			for (int i = 0; i < entity.StudioHitBoxSet.numhitboxes; i++)
			{
				mstudiobbox_t mstudiobbox_t = entity.StudioHitBoxes[i];
				int bone = mstudiobbox_t.bone;
				if (bone >= 0 && bone <= Helper.MaxStudioBones && mstudiobbox_t.radius > 0f)
				{
					float num;
					if (entity.Team == DoYouEvenAimBro.PlayerTeam)
					{
						num = 0.9f;
					}
					else
					{
						num = 1f;
					}
					Matrix matrix = entity.BonesMatrices[bone];
					Vector3 startPoint = matrix.Transform(mstudiobbox_t.bbmin);
					Vector3 endPoint = matrix.Transform(mstudiobbox_t.bbmax);
					Line3D other = new Line3D(startPoint, endPoint);
					ValueTuple<Vector3, Vector3> valueTuple = aimRayWorld.ClosestPointsBetween(other, true);
					Vector3 item = valueTuple.Item1;
					if ((valueTuple.Item2 - item).Length() < mstudiobbox_t.radius * num)
					{
						return i;
					}
				}
			}
			return -1;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00007970 File Offset: 0x00005B70
		public void ActivatePunishment(Team EntityTeam)
		{
			if (!base.CanActivate())
			{
				return;
			}
			if (EntityTeam == base.Player.Team)
			{
				if (base.GameData.MatchInfo.RoundNumber < 10 && !Program.Debug.IgnoreActivateOnRound)
				{
					return;
				}
				SendInput.MouseLeftDown();
				SendInput.MouseLeftUp();
			}
			else
			{
				Task.Run(delegate()
				{
					for (int i = 0; i < 150; i += 25)
					{
						SendInput.MouseMove(-25, 0);
						Thread.Sleep(10);
					}
				});
			}
			if (!DoYouEvenAimBro.logDelay)
			{
				DoYouEvenAimBro.logDelay = true;
				base.AfterActivate(true);
				Task.Run(delegate()
				{
					Thread.Sleep(10000);
					DoYouEvenAimBro.logDelay = false;
				});
			}
		}

		// Token: 0x040001FE RID: 510
		public static Team PlayerTeam;

		// Token: 0x040001FF RID: 511
		public static bool logDelay;
	}
}
