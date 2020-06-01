using System;
using SharpDX;

namespace ScriptKidAntiCheat.Utils.Maths
{
	// Token: 0x0200004E RID: 78
	public readonly struct Line3D
	{
		// Token: 0x0600013E RID: 318 RVA: 0x00009808 File Offset: 0x00007A08
		public Line3D(Vector3 startPoint, Vector3 endPoint)
		{
			this.StartPoint = startPoint;
			this.EndPoint = endPoint;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00009818 File Offset: 0x00007A18
		public ValueTuple<Vector3, Vector3> ClosestPointsBetween(Line3D other)
		{
			if (this.IsParallelTo(other))
			{
				return new ValueTuple<Vector3, Vector3>(this.StartPoint, other.ClosestPointTo(this.StartPoint, false));
			}
			Vector3 direction = this.GetDirection();
			Vector3 direction2 = other.GetDirection();
			Vector3 right = this.StartPoint - other.StartPoint;
			float num = direction.Dot(direction);
			float num2 = direction.Dot(direction2);
			float num3 = direction2.Dot(direction2);
			float num4 = direction.Dot(right);
			float num5 = direction2.Dot(right);
			float num6 = (num2 * num5 - num3 * num4) / (num * num3 - num2 * num2);
			float num7 = (num * num5 - num2 * num4) / (num * num3 - num2 * num2);
			return new ValueTuple<Vector3, Vector3>(this.StartPoint + num6 * direction, other.StartPoint + num7 * direction2);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x000098F0 File Offset: 0x00007AF0
		public ValueTuple<Vector3, Vector3> ClosestPointsBetween(Line3D other, bool mustBeOnSegments)
		{
			if (!this.IsParallelTo(other) || !mustBeOnSegments)
			{
				ValueTuple<Vector3, Vector3> valueTuple = this.ClosestPointsBetween(other);
				if (!mustBeOnSegments)
				{
					return valueTuple;
				}
				if ((valueTuple.Item1 - this.StartPoint).Length() <= this.GetLength() && (valueTuple.Item1 - this.EndPoint).Length() <= this.GetLength() && (valueTuple.Item2 - other.StartPoint).Length() <= other.GetLength() && (valueTuple.Item2 - other.EndPoint).Length() <= other.GetLength())
				{
					return valueTuple;
				}
			}
			Vector3 vector = other.ClosestPointTo(this.StartPoint, true);
			float num = (vector - this.StartPoint).Length();
			ValueTuple<Vector3, Vector3> result = new ValueTuple<Vector3, Vector3>(this.StartPoint, vector);
			float num2 = num;
			vector = other.ClosestPointTo(this.EndPoint, true);
			num = (vector - this.EndPoint).Length();
			if (num < num2)
			{
				result = new ValueTuple<Vector3, Vector3>(this.EndPoint, vector);
				num2 = num;
			}
			vector = this.ClosestPointTo(other.StartPoint, true);
			num = (vector - other.StartPoint).Length();
			if (num < num2)
			{
				result = new ValueTuple<Vector3, Vector3>(vector, other.StartPoint);
				num2 = num;
			}
			vector = this.ClosestPointTo(other.EndPoint, true);
			num = (vector - other.EndPoint).Length();
			if (num < num2)
			{
				result = new ValueTuple<Vector3, Vector3>(vector, other.EndPoint);
			}
			return result;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00009A88 File Offset: 0x00007C88
		public Vector3 ClosestPointTo(Vector3 value, bool mustBeOnSegment)
		{
			Vector3 direction = this.GetDirection();
			float num = (value - this.StartPoint).Dot(direction);
			if (mustBeOnSegment)
			{
				if (num < 0f)
				{
					num = 0f;
				}
				float length = this.GetLength();
				if (num > length)
				{
					num = length;
				}
			}
			return this.StartPoint + num * direction;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00009ADF File Offset: 0x00007CDF
		public Vector3 GetDirection()
		{
			return (this.EndPoint - this.StartPoint).Normalized();
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00009AF8 File Offset: 0x00007CF8
		public float GetLength()
		{
			return (this.EndPoint - this.StartPoint).Length();
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00009B1E File Offset: 0x00007D1E
		public bool IsParallelTo(Line3D other)
		{
			return this.GetDirection().IsParallelTo(other.GetDirection(), 1E-06f);
		}

		// Token: 0x04000293 RID: 659
		public readonly Vector3 StartPoint;

		// Token: 0x04000294 RID: 660
		public readonly Vector3 EndPoint;
	}
}
