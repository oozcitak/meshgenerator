using System;

namespace Manina.Math.Mesh
{
    /// <summary>
    /// Represents a circle.
    /// </summary>
    public class Circle : IShape
    {
        #region Member Variables
        private float area = -1.0f;
        private float perimeter = -1.0f;
        private Vertex midPoint = null;
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

        #region Instance Methods
        /// <summary>
        /// Determines if the circle contains the given vertex.
        /// </summary>
        /// <param name="v">the vertex to check.</param>
        public PointShapeRelation Contains(Vertex v)
        {
            float x = Vertex.Distance(V, v);
            if (Utility.AlmostEqual(x, R))
            {
                return PointShapeRelation.On;
            }
            else if (x < R)
            {
                return PointShapeRelation.Inside;
            }
            else
            {
                return PointShapeRelation.Outside;
            }
        }
        #endregion

        #region IShape Members
        /// <summary>
        /// Gets the geometric mid point of the shape.
        /// </summary>
        /// <value></value>
        public Vertex MidPoint
        {
            get
            {
                if (midPoint == null)
                    midPoint = new Vertex(V.X, V.Y);
                return midPoint;
            }
        }
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
        /// Gets the circumscribed circle of the shape.
        /// </summary>
        /// <value></value>
        public Circle CircumCircle
        {
            get
            {
                if (circumCircle == null)
                {
                    circumCircle = new Circle(V.X, V.Y, R);
                }
                return circumCircle;
            }
        }
        #endregion
    }
}

