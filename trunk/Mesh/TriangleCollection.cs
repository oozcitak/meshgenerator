using System;
using System.Collections;
using System.Collections.Generic;

namespace Manina.Math.Mesh
{
    /// <summary>
    /// Represents a collection of triangles.
    /// </summary>
    public class TriangleCollection : ShapeCollection<Triangle>
    {
        #region Instance Methods
        /// <summary>
        /// Adds a new item to the collection.
        /// </summary>
        /// <param name="x1">x coordinate of the first point.</param>
        /// <param name="y1">y coordinate of the first point.</param>
        /// <param name="x2">x coordinate of the second point.</param>
        /// <param name="y2">y coordinate of the second point.</param>
        /// <param name="x3">x coordinate of the third point.</param>
        /// <param name="y3">y coordinate of the third point.</param>
        public void Add(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            Add(new Triangle(x1, y1, x2, y2, x3, y3));
        }
        /// <summary>
        /// Returns the triangle containing the given coordinates, or null
        /// if a triangle wasn't found.
        /// </summary>
        /// <param name="x">x coordinate.</param>
        /// <param name="y">y coordinate.</param>
        public Triangle FindByCoordinates(float x, float y)
        {
            foreach (Triangle t in this)
            {
                if (t.Contains(x, y) != PointShapeRelation.Outside)
                {
                    return t;
                }
            }

            return null;
        }
        #endregion
    }
}

