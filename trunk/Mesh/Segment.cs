using System;

namespace Manina.Math.Mesh
{
	/// <summary>
	/// Represents a line segment.
	/// </summary>
	public class Segment
	{
		#region Member Variables
		private Vertex midPoint = null;
		private float length = -1.0f;
		private Circle circumCircle = null;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the first vertex.
		/// </summary>
		public Vertex V1 { get; private set; }
		/// <summary>
		/// Gets the second vertex.
		/// </summary>
		public Vertex V2 { get; private set; }
		/// <summary>
		/// Gets the mid point of the segment.
		/// </summary>
		public Vertex MidPoint {
			get {
				if (midPoint == null)
					midPoint = (V1 + V2) / 2.0f;
				return midPoint;
			}
		}
		/// <summary>
		/// Gets the length.
		/// </summary>
		public float Length {
			get {
				if (length < 0.0f)
					length = Vertex.Distance (V1, V2);
				return length;
			}
		}
		/// <summary>
		/// Gets the circum-circle (diametral circle) of the segment.
		/// </summary>
		public Circle CircumCircle {
			get {
				if (circumCircle == null)
					circumCircle = new Circle (MidPoint, Length / 2.0f);
				return circumCircle;
			}
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		/// <param name="v1">first vertex of the segment.</param>
		/// <param name="v2">second vertex of the segment.</param>
		public Segment (Vertex v1, Vertex v2)
		{
			V1 = v1;
			V2 = v2;
		}
		#endregion
	}
}

