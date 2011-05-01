using System;

namespace Manina.Math.Mesh
{
	/// <summary>
	/// Contains utility methods.
	/// </summary>
	public static class Utility
	{
		/// <summary>
		/// Determines if the given floating point numbers can be considered equal.
		/// See: http://www.cygnus-software.com/papers/comparingfloats/comparingfloats.htm
		/// </summary>
		/// <param name="a">first number.</param>
		/// <param name="b">second number.</param>
		public static bool AlmostEqual (float a, float b)
		{
			float maxRelativeError = 0.000001f;
			float maxAbsoluteError = maxRelativeError * maxRelativeError;
			
			float absa = System.Math.Abs (a);
			float absb = System.Math.Abs (b);
			float diff = System.Math.Abs (a - b);
			
			if (diff < maxAbsoluteError)
				return true;
			
			float relativeError = (absb > absa ? diff / absb : diff / absa);
			if (relativeError <= maxRelativeError)
				return true;
			
			return false;
		}

		/// <summary>
		/// Returns the distance between two points.
		/// </summary>
		/// <param name="x1">first x coordinate.</param>
		/// <param name="y1">first y coordinate.</param>
		/// <param name="x2">second x coordinate.</param>
		/// <param name="y2">second y coordinate.</param>
		public static float Distance (float x1, float y1, float x2, float y2)
		{
			float x = x1 - x2;
			float y = y1 - y2;
			return (float)System.Math.Sqrt (x * x + y * y);
		}

		/// <summary>
		/// Returns the determinant of a 2x2 matrix.
		/// </summary>
		/// <param name="a1">first element of the first row.</param>
		/// <param name="a2">second element of the first row.</param>
		/// <param name="b1">first element of the second row.</param>
		/// <param name="b2">second element of the second row.</param>
		public static float Determinant (float a1, float a2, float b1, float b2)
		{
			return a1 * b2 - a2 * b1;
		}

		/// <summary>
		/// Returns the determinant of a 3x3 matrix.
		/// </summary>
		/// <param name="a1">first element of the first row.</param>
		/// <param name="a2">second element of the first row.</param>
		/// <param name="a3">third element of the first row.</param>
		/// <param name="b1">first element of the second row.</param>
		/// <param name="b2">second element of the second row.</param>
		/// <param name="b3">third element of the second row.</param>
		/// <param name="c1">first element of the third row.</param>
		/// <param name="c2">second element of the third row.</param>
		/// <param name="c3">third element of the third row.</param>
		public static float Determinant (float a1, float a2, float a3, float b1, float b2, float b3, float c1, float c2, float c3)
		{
			return a1 * b2 * c3 - a1 * b3 * c2 - a2 * b1 * c3 + a2 * b3 * c1 + a3 * b1 * c2 - a3 * b2 * c1;
		}

		/// <summary>
		/// Returns the signed area of a triangle.
		/// </summary>
		/// <param name="x1">x coordinate of first point.</param>
		/// <param name="y1">y coordinate of first point.</param>
		/// <param name="x2">x coordinate of second point.</param>
		/// <param name="y2">y coordinate of second point.</param>
		/// <param name="x3">x coordinate of third point.</param>
		/// <param name="y3">y coordinate of third point.</param>
		public static float SignedTriangleArea (float x1, float y1, float x2, float y2, float x3, float y3)
		{
			return Determinant (x1, y1, 1.0f, x2, y2, 1.0f, x3, y3, 1.0f) / 2.0f;
		}
	}
}

