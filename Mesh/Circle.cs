using System;

namespace Manina.Math
{
    /// <summary>
    /// Represents a circle.
    /// </summary>
    internal class Circle
    {
        #region Member Variables
        private float area = -1.0f;
        private float perimeter = -1.0f;
        private Vertex centroid = null;
        private Circle circumCircle = null;
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
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="v">center point of the circle.</param>
        /// <param name="r">radius of the circle.</param>
        public Circle(Vertex v, float r)
        {
            V = v;
            R = r;
            D = 2.0f * r;
        }
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="x">x coordinate of the center point.</param>
        /// <param name="y">y coordinate of the center point.</param>
        /// <param name="r">radius of the circle.</param>
        public Circle(float x, float y, float r)
        {
            V = new Vertex(x, y);
            R = r;
            D = 2.0f * r;
        }
        #endregion

        #region Shape Members
         /// <summary>
        /// Gets the area of the shape.
        /// </summary>
        public float Area
        {
            get
            {
                if (area < 0.0f)
                    area = (float)(System.Math.PI) * R * R;
                return area;
            }
        }
        /// <summary>
        /// Gets the perimeter of the shape.
        /// </summary>
        public float Perimeter
        {
            get
            {
                if (perimeter < 0.0f)
                    perimeter = 2.0f * (float)(System.Math.PI) * R;
                return perimeter;
            }
        }
        /// <summary>
        /// Determines if the shape contains the given point.
        /// </summary>
        /// <param name="v">the vertex to check.</param>
        public PointShapeRelation Contains(Vertex v)
        {
            float dist = Vertex.Distance(V, v);
            if (Utility.AlmostEqual(dist, R))
            {
                return PointShapeRelation.On;
            }
            else if (dist < R)
            {
                return PointShapeRelation.Inside;
            }
            else
            {
                return PointShapeRelation.Outside;
            }
        }
        #endregion
    }
}

