using System;

namespace Manina.Math
{
    /// <summary>
    /// Represents a polyline.
    /// </summary>
    internal class Polyline 
    {
        #region Member Variables
        private Vertex centroid = null;
        private float perimeter = -1.0f;
        private float area = -1.0f;
        private Circle circumCircle = null;
        private bool isCyclic = false;
        private bool isCyclicCalculated = false;
        private Segment[] segments = null;
        #endregion

        #region Properties
        /// <summary>
        /// Identifies this object.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Determines if the polyline is closed.
        /// </summary>
        public bool Closed { get; private set; }
        /// <summary>
        /// Gets the vertices.
        /// </summary>
        public Vertex[] Vertices { get; private set; }
        /// <summary>
        /// Gets the segments of the polyline.
        /// </summary>
        public Segment[] Segments
        {
            get
            {
                if (segments == null)
                {
                    int count = (Closed ? Vertices.Length : Vertices.Length - 1);
                    segments = new Segment[count];
                    for (int i = 0; i < count; i++)
                    {
                        int j = (i == Vertices.Length - 1 ? 0 : i + 1);
                        segments[i] = new Segment(Vertices[i], Vertices[j]);
                    }
                }
                return segments;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="closed">true if the polyline is closed; otherwise false.</param>
        /// <param name="vertices">array of vertices.</param>
        public Polyline(bool closed, params Vertex[] vertices)
        {
            if (vertices.Length < 2)
            {
                throw new ArgumentException("The polyline needs at least two vertices.");
            }
            Vertices = vertices;
            Closed = closed;
        }
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="vertices">array of vertices.</param>
        public Polyline(params Vertex[] vertices)
            : this(false, vertices)
        {
            ;
        }
        #endregion

        #region Instance Methods

        #endregion

        #region Shape Members
        /// <summary>
        /// Gets the geometric center of the shape.
        /// </summary>
        public Vertex Centroid
        {
            get
            {
                if (centroid == null)
                {
                    centroid = new Vertex(0.0f, 0.0f);
                    foreach (Vertex v in Vertices)
                    {
                        centroid += v;
                    }
                    centroid /= Vertices.Length;
                }
                return centroid;
            }
        }
        /// <summary>
        /// Gets the perimeter.
        /// </summary>
        public float Perimeter
        {
            get
            {
                if (perimeter < 0.0f)
                {
                    perimeter = 0.0f;
                    for (int i = 0; i < Vertices.Length; i++)
                    {
                        int j = (i == Vertices.Length - 1 ? 0 : i + 1);
                        perimeter += Vertex.Distance(Vertices[i], Vertices[j]);
                    }
                }
                return perimeter;
            }
        }
        /// <summary>
        /// Gets the area.
        /// </summary>
        public float Area
        {
            get
            {
                if (area < 0.0f)
                {
                    area = 0.0f;
                    for (int i = 0; i < Vertices.Length; i++)
                    {
                        int j = (i == Vertices.Length - 1 ? 0 : i + 1);
                        area += Vertices[i].X * Vertices[j].Y - Vertices[j].X * Vertices[i].Y;
                    }
                    area = 0.5f * System.Math.Abs(area);
                }
                return area;
            }
        }
        /// <summary>
        /// Determines if the shape contains the given point.
        /// </summary>
        /// <param name="v">the vertex to check.</param>
        /// <returns></returns>
        public PointShapeRelation Contains(Vertex v)
        {
            int signCheck = 0;
            for (int i = 0; i < Vertices.Length; i++)
            {
                int j = (i == Vertices.Length - 1 ? 0 : i + 1);
                float area = Utility.SignedTriangleArea(Vertices[i].X, Vertices[i].Y, Vertices[j].X, Vertices[j].Y, v.X, v.Y);
                if (Utility.AlmostZero(area))
                {
                    return PointShapeRelation.On;
                }

                if (Vertices.Length == 2)
                {
                    return PointShapeRelation.Outside;
                }

                int sign = System.Math.Sign(area);
                if (i == 0)
                {
                    signCheck = sign;
                }
                else if (sign != signCheck)
                {
                    return PointShapeRelation.Outside;
                }
            }

            return PointShapeRelation.Inside;
        }
        #endregion
    }
}

