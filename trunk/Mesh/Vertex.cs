using System;

namespace Manina.Math.Mesh
{
    /// <summary>
    /// Represents a point.
    /// </summary>
    public class Vertex : IShape
    {
        #region Member Variables
        private Vertex midPoint = null;
        private Circle circumCircle = null;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the X coordinate.
        /// </summary>
        public float X { get; private set; }
        /// <summary>
        /// Gets the Y coordinate.
        /// </summary>
        public float Y { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="x">x coordinate of the vertex.</param>
        /// <param name="y">y coordinate of the vertex.</param>
        public Vertex(float x, float y)
        {
            X = x;
            Y = y;
        }
        #endregion

        #region Operators
        /// <summary>
        /// Adds the coordinates of two vertices.
        /// </summary>
        /// <param name="v1">first vertex.</param>
        /// <param name="v2">second vertex.</param>
        public static Vertex operator +(Vertex v1, Vertex v2)
        {
            return new Vertex(v1.X + v2.X, v1.Y + v2.Y);
        }
        /// <summary>
        /// Substracts the coordinates of two vertices.
        /// </summary>
        /// <param name="v1">first vertex.</param>
        /// <param name="v2">second vertex.</param>
        public static Vertex operator -(Vertex v1, Vertex v2)
        {
            return new Vertex(v1.X - v2.X, v1.Y - v2.Y);
        }
        /// <summary>
        /// Multiplies the coordinates of a vertex with a scalar.
        /// </summary>
        /// <param name="v">the vertex.</param>
        /// <param name="a">the scalar value.</param>
        public static Vertex operator *(Vertex v, float a)
        {
            return new Vertex(v.X * a, v.Y * a);
        }
        /// <summary>
        /// Divides the coordinates of a vertex by a scalar.
        /// </summary>
        /// <param name="v">the vertex.</param>
        /// <param name="a">the scalar value.</param>
        public static Vertex operator /(Vertex v, float a)
        {
            return new Vertex(v.X / a, v.Y / a);
        }
        /// <summary>
        /// Determines if the coordinates of the two vertices are equal.
        /// </summary>
        /// <param name="v1">first vertex.</param>
        /// <param name="v2">second vertex.</param>
        public static bool operator ==(Vertex v1, Vertex v2)
        {
            return Utility.AlmostEqual(v1.X, v2.X) && Utility.AlmostEqual(v1.Y, v2.Y);
        }
        /// <summary>
        /// Determines if the coordinates of the two vertices are not equal.
        /// </summary>
        /// <param name="v1">first vertex.</param>
        /// <param name="v2">second vertex.</param>
        public static bool operator !=(Vertex v1, Vertex v2)
        {
            return !Utility.AlmostEqual(v1.X, v2.X) || !Utility.AlmostEqual(v1.Y, v2.Y);
        }
        #endregion

        #region Instance Methods
        /// <summary>
        /// Returns the distance between the two vertices.
        /// </summary>
        /// <param name="v1">first vertex.</param>
        /// <param name="v2">decond vertex.</param>
        public static float Distance(Vertex v1, Vertex v2)
        {
            return Utility.Distance(v1.X, v1.Y, v2.X, v2.Y);
        }
        /// <summary>
        /// Returns an offset of the vertex.
        /// </summary>
        /// <param name="dx">x offset.</param>
        /// <param name="dy">y offset.</param>
        public Vertex Offset(float dx, float dy)
        {
            return new Vertex(X + dx, Y + dy);
        }
        #endregion

        #region Hash & Equals
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            int intx = BitConverter.ToInt32(BitConverter.GetBytes(X), 0);
            int inty = BitConverter.ToInt32(BitConverter.GetBytes(Y), 0);
            return intx ^ inty;
        }
        /// <summary>
        /// Determines if the given objects are equal.
        /// </summary>
        /// <param name="obj">The object to test against.</param>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Vertex v = obj as Vertex;
            if (v == null)
                return false;

            return Utility.AlmostEqual(X, v.X) && Utility.AlmostEqual(Y, v.Y);
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
                    midPoint = new Vertex(X, Y);
                return midPoint;
            }
        }
        /// <summary>
        /// Gets the perimeter of the shape.
        /// </summary>
        /// <value></value>
        public float Perimeter
        {
            get { return 0.0f; }
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
        /// Gets the circumscribed circle of the shape.
        /// </summary>
        /// <value></value>
        public Circle CircumCircle
        {
            get
            {
                if (circumCircle == null)
                {
                    circumCircle = new Circle(X, Y, 0.0f);
                }
                return circumCircle;
            }
        }
        #endregion
    }
}

