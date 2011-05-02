using System;
using System.Collections;
using System.Collections.Generic;

namespace Manina.Math.Mesh
{
    /// <summary>
    /// Represents a collection of segments.
    /// </summary>
    public class SegmentCollection : ShapeCollection<Segment>
    {
        #region Instance Methods
        /// <summary>
        /// Adds a new item to the collection.
        /// </summary>
        /// <param name="x1">x coordinate of the first point.</param>
        /// <param name="y1">y coordinate of the first point.</param>
        /// <param name="x2">x coordinate of the second point.</param>
        /// <param name="y2">y coordinate of the second point.</param>
        public void Add(float x1, float y1, float x2, float y2)
        {
            Add(new Segment(x1, y1, x2, y2));
        }
        #endregion
    }
}

