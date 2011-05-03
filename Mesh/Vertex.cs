using System;

namespace Manina.Math
{
    /// <summary>
    /// Represents a point.
    /// </summary>
    internal class Vertex : IComparable<Vertex>
    {
        #region Member Variables
        private Vertex centroid = null;
        private Circle circumCircle = null;
        internal int internalID;
        #endregion

        #region Properties
        /// <summary>
        /// Identifies this object.
        /// </summary>
        public int ID { get; set; }
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
            return ReferenceEquals(v1, v2) || (Utility.AlmostEqual(v1.X, v2.X) && Utility.AlmostEqual(v1.Y, v2.Y));
        }
        /// <summary>
        /// Determines if the coordinates of the two vertices are not equal.
        /// </summary>
        /// <param name="v1">first vertex.</param>
        /// <param name="v2">second vertex.</param>
        public static bool operator !=(Vertex v1, Vertex v2)
        {
            return !ReferenceEquals(v1, v2) && (!Utility.AlmostEqual(v1.X, v2.X) || !Utility.AlmostEqual(v1.Y, v2.Y));
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

            return (this == v);
        }
        #endregion

        #region IComparable Members
        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the objects 
        /// being compared. The return value has the following meanings:
        /// Less than zero if this object is less than the <paramref name="other"/> parameter.
        /// Zero if this object is equal to <paramref name="other"/>.
        /// Greater than zero if this object is greater than <paramref name="other"/>.
        /// </returns>
        public int CompareTo(Vertex other)
        {
            if (Utility.AlmostEqual(X, other.X))
            {
                if (Utility.AlmostEqual(Y, other.Y))
                {
                    return 0;
                }
                else if (Y < other.Y)
                {
                    return -1;
                }
                else // if (Y > other.Y)
                {
                    return 1;
                }
            }
            else if (X < other.X)
            {
                return -1;
            }
            else // if (X > other.X)
            {
                return 1;
            }
        }
        #endregion
    }
}

