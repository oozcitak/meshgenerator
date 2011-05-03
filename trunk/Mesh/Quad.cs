using System;

namespace Manina.Math
{
    /// <summary>
    /// Represents a quad.
    /// </summary>
    internal class Quad
    {
        #region Member Variables
        private float perimeter = -1.0f;
        private float area = -1.0f;
        private Circle circumCircle = null;
        internal int internalID;
        #endregion

        #region Properties
        /// <summary>
        /// Identifies this object.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Gets the center vertex.
        /// </summary>
        public Vertex V { get; private set; }
        /// <summary>
        /// Gets the width.
        /// </summary>
        public float Width { get; private set; }
        /// <summary>
        /// Gets the height.
        /// </summary>
        public float Height { get; private set; }
        /// <summary>
        /// Gets the x coordinate of the left side.
        /// </summary>
        public float Left { get; private set; }
        /// <summary>
        /// Gets the x coordinate of the right side.
        /// </summary>
        public float Right { get; private set; }
        /// <summary>
        /// Gets the y coordinate of the bottom side.
        /// </summary>
        public float Bottom { get; private set; }
        /// <summary>
        /// Gets the y coordinate of the top side.
        /// </summary>
        public float Top { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="v">center vertex of the quad.</param>
        /// <param name="width">width of the quad.</param>
        /// <param name="height">height of the quad.</param>
        public Quad(Vertex v, float width, float height)
        {
            V = v;
            Width = width;
            Height = height;

            Left = v.X - width / 2.0f;
            Right = v.X + width / 2.0f;
            Bottom = v.Y - height / 2.0f;
            Top = v.Y + height / 2.0f;
        }
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="x">x coordinate of the center point.</param>
        /// <param name="y">y coordinate of the center point.</param>
        /// <param name="width">width of the quad.</param>
        /// <param name="height">height of the quad.</param>
        public Quad(float x, float y, float width, float height)
            : this(new Vertex(x, y), width, height)
        {
            ;
        }
        #endregion

        #region Shape Members
        /// <summary>
        /// Gets the perimeter.
        /// </summary>
        public float Perimeter
        {
            get
            {
                if (perimeter < 0.0f)
                {
                    perimeter = 2.0f * (Width + Height);
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
                    area = Width * Height;
                }
                return area;
            }
        }
        /// <summary>
        /// Gets the circumcircle of the quad.
        /// </summary>
        public Circle CircumCircle
        {
            get
            {
                if (circumCircle == null)
                {
                    float r = (float)System.Math.Sqrt(Width * Width + Height * Height) / 2.0f;
                    circumCircle = new Circle(V, r);
                }
                return circumCircle;
            }
        }
        #endregion
    }
}

