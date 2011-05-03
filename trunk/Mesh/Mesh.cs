using System;
using System.Collections.Generic;

namespace Manina.Math
{
    /// <summary>
    /// Represents a mesh generator.
    /// </summary>
    public class Mesh
    {
        #region Member Variables
        private SortedList<Vertex, bool> inputVertices = new SortedList<Vertex, bool>();
        private List<Polyline> inputShapes = new List<Polyline>();
        private Dictionary<int, Polyline> inputRegions = new Dictionary<int, Polyline>();
        private Quad limit = new Quad(0.0f, 0.0f, 0.0f, 0.0f);
        #endregion

        #region Properties

        #endregion

        #region Mesh Generators
        /// <summary>
        /// Generates a triangular mesh using Ruppert's 
        /// Delaunay refinement algorithm.
        /// </summary>
        public void Triangulate()
        {
            if (inputVertices.Count == 0)
                return;

            SortedList<Vertex, bool> vertices = new SortedList<Vertex, bool>();
            List<Triangle> triangles = new List<Triangle>();

            // Create a super triangle enclosing all input vertices
            Triangle super = GetSuperTriangle();
            vertices.Add(super.V1, false);
            vertices.Add(super.V2, false);
            vertices.Add(super.V3, false);

            // Insert input vertices
            foreach (Vertex v in inputVertices.Keys)
            {
                if (!vertices.ContainsKey(v))
                {
                    vertices.Add(v, false);
                    InsertVertex(triangles, v);
                }
            }

            // Remove super triangles and vertices
            triangles.RemoveAll(t => t.V1.internalID == -1 ||
                t.V2.internalID == -1 || t.V3.internalID == -1);
            vertices.Remove(super.V1);
            vertices.Remove(super.V2);
            vertices.Remove(super.V3);
        }
        #endregion

        #region Instance Methods
        /// <summary>
        /// Adds a vertex to the mesh domain. Duplicate input vertices are
        /// ignored.
        /// </summary>
        /// <param name="x">x coordinate of the vertex.</param>
        /// <param name="y">y coordinate of the vertex.</param>
        public void AddVertex(float x, float y)
        {
            Vertex v = new Vertex(x, y);
            if (!inputVertices.ContainsKey(v))
            {
                inputVertices.Add(v, false);
                UpdateLimit(x, y);
            }
        }
        /// <summary>
        /// Adds a line segment to the mesh domain.
        /// </summary>
        /// <param name="x1">x coordinate of the first point.</param>
        /// <param name="y1">y coordinate of the first point.</param>
        /// <param name="x2">x coordinate of the second point.</param>
        /// <param name="y2">y coordinate of the second point.</param>
        public void AddLine(float x1, float y1, float x2, float y2)
        {
            AddPolyline(0, false, x1, y1, x2, y2);
        }
        /// <summary>
        /// Adds a polyline to the mesh domain.
        /// </summary>
        /// <param name="coordinates">x and y coordinates of input vertices.</param>
        public void AddPolyline(params float[] coordinates)
        {
            AddPolyline(0, false, coordinates);
        }
        /// <summary>
        /// Adds a polygon to the mesh domain.
        /// </summary>
        /// <param name="coordinates">x and y coordinates of input vertices.</param>
        public void AddPolygon(params float[] coordinates)
        {
            AddPolyline(0, true, coordinates);
        }
        /// <summary>
        /// Adds a polygon to the mesh domain.
        /// </summary>
        /// <param name="id">the identifier of this polygon.</param>
        /// <param name="coordinates">x and y coordinates of input vertices.</param>
        public void AddPolygon(int id, params float[] coordinates)
        {
            AddPolyline(id, true, coordinates);
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Inserts a vertex into the given triangulation.
        /// </summary>
        /// <param name="triangles">a triangulation.</param>
        /// <param name="v">the new vertex.</param>
        private void InsertVertex(List<Triangle> triangles, Vertex v)
        {
            // Find out if the vertex is inside the circumcircle of a triangle
            List<Triangle> encroached = new List<Triangle>();
            List<Segment> subSegments = new List<Segment>();
            foreach (Triangle t in triangles)
            {
                if (t.CircumCircle.Contains(v) != PointShapeRelation.Outside)
                {
                    // Insert (outer) segments
                    encroached.Add(t);
                    Segment s, duplicate;
                    s = new Segment(t.V1, t.V2);
                    duplicate = subSegments.Find(sl => sl == s);
                    if (duplicate == null)
                    {
                        subSegments.Add(s);
                    }
                    else
                    {
                        subSegments.Remove(duplicate);
                    }
                    s = new Segment(t.V2, t.V3);
                    duplicate = subSegments.Find(sl => sl == s);
                    if (duplicate == null)
                    {
                        subSegments.Add(s);
                    }
                    else
                    {
                        subSegments.Remove(duplicate);
                    }
                    s = new Segment(t.V3, t.V1);
                    duplicate = subSegments.Find(sl => sl == s);
                    if (duplicate == null)
                    {
                        subSegments.Add(s);
                    }
                    else
                    {
                        subSegments.Remove(duplicate);
                    }
                }
            }

            // Remove triangles
            foreach (Triangle t in encroached)
            {
                triangles.Remove(t);
            }

            // Create new triangles
            foreach (Segment s in subSegments)
            {
                triangles.Add(new Triangle(s.V1, s.V2, v));
            }
        }
        /// <summary>
        /// Returns the super triangle enclosing all input vertices.
        /// </summary>
        /// <returns></returns>
        private Triangle GetSuperTriangle()
        {
            float x = limit.V.X;
            float y = limit.V.Y;
            float r = limit.CircumCircle.R * 1.2f;
            float s = r / (float)System.Math.Tan(System.Math.PI / 6.0);
            float h = s * (float)System.Math.Tan(System.Math.PI / 3.0);

            Vertex v1 = new Vertex(x - s, y - r);
            Vertex v2 = new Vertex(x + s, y - r);
            Vertex v3 = new Vertex(x, y - r + h);
            v1.internalID = -1;
            v2.internalID = -1;
            v3.internalID = -1;

            return new Triangle(v1, v2, v3);
        }
        /// <summary>
        /// Updates mesh limit to enclose the given point.
        /// </summary>
        /// <param name="x">x coordinate of the point.</param>
        /// <param name="y">y coordinate of the point.</param>
        private void UpdateLimit(float x, float y)
        {
            if (inputVertices.Count == 0)
            {
                limit = new Quad(x, y, 0.0f, 0.0f);
            }
            else
            {
                float x1 = System.Math.Min(limit.Left, x);
                float x2 = System.Math.Max(limit.Right, x);
                float y1 = System.Math.Min(limit.Bottom, y);
                float y2 = System.Math.Max(limit.Top, y);

                limit = new Quad((x1 + x2) / 2.0f, (y1 + y2) / 2.0f, x2 - x1, y2 - y1);
            }
        }
        /// <summary>
        /// Adds a polyline to the mesh domain.
        /// </summary>
        /// <param name="id">the identifier of this polyline.</param>
        /// <param name="closed">true if the polyline is closed; otherwise false.</param>
        /// <param name="coordinates">x and y coordinates of input vertices.</param>
        private void AddPolyline(int id, bool closed, params float[] coordinates)
        {
            if (coordinates.Length % 2 != 0)
            {
                throw new ArgumentException("Input coordinates must contain two values (x then y) for each vertex.");
            }

            Vertex[] vertices = new Vertex[coordinates.Length / 2];
            for (int i = 0; i < vertices.Length; i++)
            {
                float x = coordinates[i * 2];
                float y = coordinates[i * 2 + 1];
                vertices[i] = new Vertex(x, y);
                UpdateLimit(x, y);
            }
            Polyline p = new Polyline(true, vertices);
            inputShapes.Add(p);
            inputRegions.Add(id, p);

        }
        #endregion
    }
}

