using System;

namespace Manina.Math.Mesh
{
    /// <summary>
    /// Represents a triangle.
    /// </summary>
    public class Triangle : IShape
    {
        #region Member Variables
        private Vertex midPoint = null;
        private float perimeter = -1.0f;
        private float area = -1.0f;
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
        /// Gets the third vertex.
        /// </summary>
        public Vertex V3 { get; private set; }
        /// <summary>
        /// Gets the first neighbour.
        /// </summary>
        public Triangle N1 { get; set; }
        /// <summary>
        /// Gets the second neighbour.
        /// </summary>
        public Triangle N2 { get; set; }
        /// <summary>
        /// Gets the third neighbour.
        /// </summary>
        public Triangle N3 { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="v1">first vertex of the triangle.</param>
        /// <param name="v2">second vertex of the triangle.</param>
        /// <param name="v3">third vertex of the triangle.</param>
        public Triangle(Vertex v1, Vertex v2, Vertex v3)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;

            N1 = null;
            N2 = null;
            N3 = null;
        }
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="x1">x coordinate of the first point.</param>
        /// <param name="y1">y coordinate of the first point.</param>
        /// <param name="x2">x coordinate of the second point.</param>
        /// <param name="y2">y coordinate of the second point.</param>
        /// <param name="x3">x coordinate of the third point.</param>
        /// <param name="y3">y coordinate of the third point.</param>
        public Triangle(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            V1 = new Vertex(x1, y1);
            V2 = new Vertex(x2, y2);
            V3 = new Vertex(x3, y3);

            N1 = null;
            N2 = null;
            N3 = null;
        }
        #endregion

        #region Instance Methods
        /// <summary>
        /// Sets a neighbour of the triangle.
        /// </summary>
        /// <param name="oldNeighbour">the neighbour to change.</param>
        /// <param name="newNeighbour">the triangle to set as the new neighbour.</param>
        public void SetNeighbour(Triangle oldNeighbour, Triangle newNeighbour)
        {
            if (oldNeighbour == null)
            {
                throw new ArgumentException("Neighbour cannot be null.", "oldNeighbour");
            }

            if (ReferenceEquals(N1, oldNeighbour))
            {
                N1 = newNeighbour;
            }
            else if (ReferenceEquals(N2, oldNeighbour))
            {
                N2 = newNeighbour;
            }
            else if (ReferenceEquals(N3, oldNeighbour))
            {
                N3 = newNeighbour;
            }
            else
            {
                throw new ArgumentException("Neighbour not found.", "oldNeighbour");
            }
        }
        /// <summary>
        /// Determines if the triangle contains the given vertex.
        /// </summary>
        /// <param name="v">the vertex to check.</param>
        public PointShapeRelation Contains(Vertex v)
        {
            float a1 = Utility.SignedTriangleArea(V1.X, V1.Y, V2.X, V2.Y, v.X, v.Y);
            if (Utility.AlmostEqual(a1, 0.0f))
            {
                return PointShapeRelation.On;
            }
            else if (a1 < 0)
            {
                return PointShapeRelation.Outside;
            }

            float a2 = Utility.SignedTriangleArea(V2.X, V2.Y, V3.X, V3.Y, v.X, v.Y);
            if (Utility.AlmostEqual(a2, 0.0f))
            {
                return PointShapeRelation.On;
            }
            else if (a2 < 0)
            {
                return PointShapeRelation.Outside;
            }

            float a3 = Utility.SignedTriangleArea(V3.X, V3.Y, V1.X, V1.Y, v.X, v.Y);
            if (Utility.AlmostEqual(a3, 0.0f))
            {
                return PointShapeRelation.On;
            }
            else if (a3 < 0)
            {
                return PointShapeRelation.Outside;
            }

            return PointShapeRelation.Inside;
        }
        /// <summary>
        /// Determines if the triangle contains the given vertex.
        /// </summary>
        /// <param name="x">x coordinate.</param>
        /// <param name="y">y coordinate.</param>
        public PointShapeRelation Contains(float x, float y)
        {
            return Contains(new Vertex(x, y));
        }
        #endregion

        #region IShape Members
        /// <summary>
        /// Gets the geometric mid point of the triangle.
        /// </summary>
        public Vertex MidPoint
        {
            get
            {
                if (midPoint == null)
                    midPoint = (V1 + V2 + V3) / 3.0f;
                return midPoint;
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
                    perimeter = Vertex.Distance(V1, V2) + Vertex.Distance(V2, V3) + Vertex.Distance(V3, V1);
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
                    area = System.Math.Abs(Utility.SignedTriangleArea(V1.X, V1.Y, V2.X, V2.Y, V3.X, V3.Y));
                }
                return area;
            }
        }
        /// <summary>
        /// Gets the circum-circle.
        /// </summary>
        public Circle CircumCircle
        {
            get
            {
                if (circumCircle == null)
                {
                    float a = Utility.Determinant(V1.X, V1.Y, 1.0f, V2.X, V2.Y, 1.0f, V3.X, V3.Y, 1.0f);
                    float n1 = V1.X * V1.X + V1.Y * V1.Y;
                    float n2 = V2.X * V2.X + V2.Y * V2.Y;
                    float n3 = V3.X * V3.X + V3.Y * V3.Y;
                    float bbx = -1.0f * Utility.Determinant(n1, V1.Y, 1.0f, n2, V2.Y, 1.0f, n3, V3.Y, 1.0f);
                    float bby = Utility.Determinant(n1, V1.X, 1.0f, n2, V2.X, 1.0f, n3, V3.X, 1.0f);
                    float c = Utility.Determinant(n1, V1.X, V1.Y, n2, V2.X, V2.Y, n3, V3.X, V3.Y);
                    float x = -bbx / (2.0f * a);
                    float y = -bby / (2.0f * a);
                    float r = (float)(System.Math.Sqrt(bbx * bbx + bby * bby - 4.0f * a * c) / System.Math.Abs(2.0f * a));
                    circumCircle = new Circle(x, y, r);
                }
                return circumCircle;
            }
        }
        #endregion
    }
}

