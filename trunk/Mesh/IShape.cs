using System;
using System.Collections.Generic;
using System.Text;

namespace Manina.Math.Mesh
{
    /// <summary>
    /// Represents a generic shape.
    /// </summary>
    public interface IShape
    {
        #region Properties
        /// <summary>
        /// Gets the geometric mid point of the shape.
        /// </summary>
        Vertex MidPoint { get; }
        /// <summary>
        /// Gets the perimeter of the shape.
        /// </summary>
        float Perimeter { get; }
        /// <summary>
        /// Gets the area of the shape.
        /// </summary>
        float Area { get; }
        /// <summary>
        /// Gets the circumscribed circle of the shape.
        /// </summary>
        Circle CircumCircle { get; }
        #endregion
    }
}
