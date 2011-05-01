using System;

namespace Manina.Math.Mesh
{
	/// <summary>
	/// Represents the relation of a point relative to a closed shape.
	/// </summary>
	public enum PointShapeRelation
	{
		/// <summary>
		/// The point is inside the shape.
		/// </summary>
		Inside,
		/// <summary>
		/// The point is outside the shape.
		/// </summary>
		Outside,
		/// <summary>
		/// The point is directly on the shape.
		/// </summary>
		On
	}
}

