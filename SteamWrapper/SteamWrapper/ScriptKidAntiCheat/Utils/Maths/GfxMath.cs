using System;
using ScriptKidAntiCheat.Internal.Raw;
using SharpDX;

namespace ScriptKidAntiCheat.Utils.Maths
{
	// Token: 0x0200004D RID: 77
	public static class GfxMath
	{
		// Token: 0x06000130 RID: 304 RVA: 0x00009314 File Offset: 0x00007514
		public static float AngleTo(this Vector3 vector, Vector3 other)
		{
			return (float)Math.Acos((double)vector.Normalized().Dot(other.Normalized()));
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000932E File Offset: 0x0000752E
		public static Vector3 Cross(this Vector3 left, Vector3 right)
		{
			return Vector3.Cross(left, right);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00009337 File Offset: 0x00007537
		public static float Dot(this Vector3 left, Vector3 right)
		{
			return Vector3.Dot(left, right);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00009340 File Offset: 0x00007540
		public static Vector3[] GetCircleVertices(Vector3 origin, Vector3 normal, double radius, int segments)
		{
			Matrix orthogonalMatrix = GfxMath.GetOrthogonalMatrix(normal, origin);
			Vector3[] circleVertices2D = GfxMath.GetCircleVertices2D(default(Vector3), radius, segments);
			for (int i = 0; i < circleVertices2D.Length; i++)
			{
				circleVertices2D[i] = orthogonalMatrix.Transform(circleVertices2D[i]);
			}
			return circleVertices2D;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000938C File Offset: 0x0000758C
		public static Vector3[] GetCircleVertices2D(Vector3 origin, double radius, int segments)
		{
			Vector3[] array = new Vector3[segments + 1];
			double num = 6.2831853071795862 / (double)segments;
			for (int i = 0; i < segments; i++)
			{
				double num2 = num * (double)i;
				array[i] = new Vector3((float)((double)origin.X + radius * Math.Cos(num2)), (float)((double)origin.Y + radius * Math.Sin(num2)), 0f);
			}
			array[segments] = array[0];
			return array;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00009404 File Offset: 0x00007604
		public static Vector3[][] GetHalfSphere(Vector3 origin, Vector3 normal, float radius, int segments, int layers)
		{
			normal.Normalize();
			Vector3[][] array = new Vector3[layers][];
			for (int i = 0; i < layers; i++)
			{
				float num = radius - (float)i * (radius / (float)layers);
				Vector3 origin2 = origin + normal * ((float)Math.Cos(Math.Asin((double)(num / radius))) * radius);
				array[i] = GfxMath.GetCircleVertices(origin2, normal, (double)num, segments);
			}
			return array;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00009464 File Offset: 0x00007664
		public static Matrix GetMatrix(Vector3 xAxis, Vector3 yAxis, Vector3 zAxis, Vector3 origin)
		{
			Matrix result = default(Matrix);
			result.M11 = xAxis.X;
			result.M12 = xAxis.Y;
			result.M13 = xAxis.Z;
			result.M21 = yAxis.X;
			result.M22 = yAxis.Y;
			result.M23 = yAxis.Z;
			result.M31 = zAxis.X;
			result.M32 = zAxis.Y;
			result.M33 = zAxis.Z;
			result.M41 = origin.X;
			result.M42 = origin.Y;
			result.M43 = origin.Z;
			result.M44 = 1f;
			return result;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00009524 File Offset: 0x00007724
		public static void GetOrthogonalAxis(Vector3 normal, out Vector3 xAxis, out Vector3 yAxis, out Vector3 zAxis)
		{
			zAxis = normal.Normalized();
			Vector3 vector;
			vector..ctor(0f, 0f, 1f);
			float num = zAxis.AngleTo(vector);
			if ((double)num < 0.78539816339744828 || (double)num > 2.3561944901923448)
			{
				xAxis = new Vector3(0f, 1f, 0f).Cross(zAxis).Normalized();
			}
			else
			{
				xAxis = zAxis.Cross(vector).Normalized();
			}
			yAxis = zAxis.Cross(xAxis).Normalized();
		}

		// Token: 0x06000138 RID: 312 RVA: 0x000095DC File Offset: 0x000077DC
		public static Matrix GetOrthogonalMatrix(Vector3 normal, Vector3 origin)
		{
			Vector3 xAxis;
			Vector3 yAxis;
			Vector3 zAxis;
			GfxMath.GetOrthogonalAxis(normal, out xAxis, out yAxis, out zAxis);
			return GfxMath.GetMatrix(xAxis, yAxis, zAxis, origin);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x000095FE File Offset: 0x000077FE
		public static bool IsParallelTo(this Vector3 vector, Vector3 other, float tolerance = 1E-06f)
		{
			return Math.Abs(1.0 - (double)Math.Abs(vector.Normalized().Dot(other.Normalized()))) <= (double)tolerance;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000962D File Offset: 0x0000782D
		public static Vector3 Normalized(this Vector3 value)
		{
			return Vector3.Normalize(value);
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00009638 File Offset: 0x00007838
		public static Matrix ToMatrix(this matrix3x4_t matrix)
		{
			Matrix result = default(Matrix);
			result.M11 = matrix.m00;
			result.M12 = matrix.m01;
			result.M13 = matrix.m02;
			result.M21 = matrix.m10;
			result.M22 = matrix.m11;
			result.M23 = matrix.m12;
			result.M31 = matrix.m20;
			result.M32 = matrix.m21;
			result.M33 = matrix.m22;
			result.M41 = matrix.m30;
			result.M42 = matrix.m31;
			result.M43 = matrix.m32;
			result.M44 = 1f;
			return result;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x000096F8 File Offset: 0x000078F8
		public static Vector3 Transform(this Matrix matrix, Vector3 value)
		{
			double num = 1.0 / ((double)matrix.M14 * (double)value.X + (double)matrix.M24 * (double)value.Y + (double)matrix.M34 * (double)value.Z + (double)matrix.M44);
			return new Vector3((float)(((double)matrix.M11 * (double)value.X + (double)matrix.M21 * (double)value.Y + (double)matrix.M31 * (double)value.Z + (double)matrix.M41) * num), (float)(((double)matrix.M12 * (double)value.X + (double)matrix.M22 * (double)value.Y + (double)matrix.M32 * (double)value.Z + (double)matrix.M42) * num), (float)(((double)matrix.M13 * (double)value.X + (double)matrix.M23 * (double)value.Y + (double)matrix.M33 * (double)value.Z + (double)matrix.M43) * num));
		}

		// Token: 0x0600013D RID: 317 RVA: 0x000097FA File Offset: 0x000079FA
		public static double DegreeToRadian(this double degree)
		{
			return degree * 0.017453292519943295;
		}

		// Token: 0x04000292 RID: 658
		private const double _PI_Over_180 = 0.017453292519943295;
	}
}
