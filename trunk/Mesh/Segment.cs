using System;

namespace Manina.Math.Mesh
{
    /// <summary>
    /// Represents a line segment.
    /// </summary>
    public class Segment : IShape
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
        /// Gets the length.
        /// </summary>
        public float Length
        {
            get
            {
                if (length < 0.0f)
                    length = Vertex.Distance(V1, V2);
                return length;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="v1">first vertex of the segment.</param>
        /// <param name="v2">second vertex of the segment.</param>
        public Segment(Vertex v1, Vertex v2)
        {
            V1 = v1;
            V2 = v2;
        }
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="x1">x coordinate of the first point.</param>
        /// <param name="y1">y coordinate of the first point.</param>
        /// <param name="x2">x coordinate of the second point.</param>
        /// <param name="y2">y coordinate of the second point.</param>
        public Segment(float x1, float y1, float x2, float y2)
        {
            V1 = new Vertex(x1, y1);
            V2 = new Vertex(x2, y2);
        }
        #endregion

        #region IShape Members
        /// <summary>
        /// Gets the perimeter of the shape.
        /// </summary>
        /// <value></value>
        public float Perimeter
        {
            get { return Length; }
        }

        /// <summary>
        /// Gets the area of the shape.
        /// </summary>
        /// <value></value>
        public float Area
        {
            get { return 0.0f; }
        }
        /// <summary>
        /// Gets the circum-circle (diametral circle) of the segment.
        /// </summary>
        public Circle CircumCircle
        {
            get
            {
                if (circumCircle == null)
                    circumCircle = new Circle(MidPoint.X, midPoint.Y, Length / 2.0f);
                return circumCircle;
            }
        }
        /// <summary>
        /// Gets the mid point of the segment.
        /// </summary>
        public Vertex MidPoint
        {
            get
            {
                if (midPoint == null)
                    midPoint = (V1 + V2) / 2.0f;
                return midPoint;
            }
        }
        #endregion
    }
}

