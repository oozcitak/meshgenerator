using System;

namespace Manina.Math
{
    /// <summary>
    /// Represents a line segment.
    /// </summary>
    internal class Segment
    {
        #region Member Variables
        private Vertex centroid = null;
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

        #region Operators
        /// <summary>
        /// Determines if the coordinates of the two segments are equal.
        /// </summary>
        /// <param name="s1">first segment.</param>
        /// <param name="s2">second segment.</param>
        public static bool operator ==(Segment s1, Segment s2)
        {
            if (ReferenceEquals(s1, s2)) return true;
            if ((s1.V1 == s2.V1) && (s1.V2 == s2.V2)) return true;
            if ((s1.V1 == s2.V2) && (s1.V2 == s2.V1)) return true;

            return false;
        }
        /// <summary>
        /// Determines if the coordinates of the two segments are not equal.
        /// </summary>
        /// <param name="s1">first segment.</param>
        /// <param name="s2">second segment.</param>
        public static bool operator !=(Segment s1, Segment s2)
        {
            if (ReferenceEquals(s1, s2)) return false;
            if ((s1.V1 == s2.V1) && (s1.V2 == s2.V2)) return false;
            if ((s1.V1 == s2.V2) && (s1.V2 == s2.V1)) return false;

            return true;
        }
        #endregion

        #region Hash & Equals
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            return V1.GetHashCode() ^ V2.GetHashCode();
        }
        /// <summary>
        /// Determines if the given objects are equal.
        /// </summary>
        /// <param name="obj">The object to test against.</param>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Segment s = obj as Segment;
            if (s == null)
                return false;

            return (this == s);
        }
        #endregion

        #region Shape Members
        /// <summary>
        /// Gets the circumcircle (diametral circle) of the segment.
        /// </summary>
        public Circle CircumCircle
        {
            get
            {
                if (circumCircle == null)
                    circumCircle = new Circle(Centroid.X, Centroid.Y, Length / 2.0f);
                return circumCircle;
            }
        }
        /// <summary>
        /// Gets the geometric center of the segment.
        /// </summary>
        public Vertex Centroid
        {
            get
            {
                if (centroid == null)
                    centroid = (V1 + V2) / 2.0f;
                return centroid;
            }
        }
        #endregion
    }
}

