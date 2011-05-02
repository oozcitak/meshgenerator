using System;
using System.Collections;
using System.Collections.Generic;

namespace Manina.Math.Mesh
{
    /// <summary>
    /// Represents a collection of points.
    /// </summary>
    public class VertexCollection : ShapeCollection<Vertex>
    {
        #region Instance Methods
        /// <summary>
        /// Adds a new item to the collection.
        /// </summary>
        /// <param name="x">x coordinate.</param>
        /// <param name="y">y coordinate.</param>
        public void Add(float x, float y)
        {
            Add(new Vertex(x, y));
        }
        /// <summary>
        /// Returns the vertex at the given coordinates, or null
        /// if a vertex wasn't found.
        /// </summary>
        /// <param name="x">x coordinate.</param>
        /// <param name="y">y coordinate.</param>
        /// </returns>
        public Vertex FindByCoordinates(float x, float y)
        {
            Vertex target = new Vertex(x, y);
            foreach (Vertex v in this)
            {
                if (target == v)
                {
                    return v;
                }
            }
            return null;
        }
        #endregion
    }
}

