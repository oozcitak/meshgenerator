using System;

namespace Manina.Math.Mesh
{
	/// <summary>
	/// Represents a circle.
	/// </summary>
	public class Circle
	{
		#region Member Variables
		private float area = -1.0f;
		private float perimeter = -1.0f;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the center point.
		/// </summary>
		public Vertex V { get; private set; }
		/// <summary>
		/// Gets the radius.
		/// </summary>
		public float R { get; private set; }
		/// <summary>
		/// Gets the diameter.
		/// </summary>
		public float D { get; private set; }
		/// <summary>
		/// Gets the area.
		/// </summary>
		public float Area {
			get {
				if (area < 0.0f)
					area = (float)(System.Math.PI) * R * R;
				return area;
			}
		}
		/// <summary>
		/// Gets the perimeter.
		/// </summary>
		public float Perimeter {
			get {
				if (perimeter < 0.0f)
					perimeter = 2.0f * (float)(System.Math.PI) * R;
				return perimeter;
			}
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		/// <param name="v">center point of the circle.</param>
		/// <param name="r">radius of the circle.</param>
		public Circle (Vertex v, float r)
		{
			V = v;
			R = r;
			D = 2.0f * r;
		}
		#endregion

		#region Instance Methods
		/// <summary>
		/// Determines if the circle contains the given vertex.
		/// </summary>
		/// <param name="v">the vertex to check.</param>
		public PointShapeRelation Contains (Vertex v)
		{
			float x = Vertex.Distance (V, v);
			if (Utility.AlmostEqual (x, R)) {
				return PointShapeRelation.On;
			} else if (x < R) {
				return PointShapeRelation.Inside;
			} else {
				return PointShapeRelation.Outside;
			}
		}
		#endregion
	}
}

