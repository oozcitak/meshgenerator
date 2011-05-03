using System;

namespace Manina.Math
{
	/// <summary>
	/// Represents the relation of a point relative to a closed shape.
	/// </summary>
	internal enum PointShapeRelation
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

