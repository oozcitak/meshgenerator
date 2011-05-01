using System;
using System.Collections;
using System.Collections.Generic;

namespace Manina.Math.Mesh
{
	/// <summary>
	/// Represents a collection of triangles.
	/// </summary>
	public class TriangleCollection : IList<Triangle>, ICollection<Triangle>, IEnumerable<Triangle>
	{
		#region Member Variables
		private List<Triangle> items;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the item at the given index.
		/// </summary>
		/// <param name="index">the item index.</param>
		public Triangle this[int index] {
			get { return items[index]; }
			set { items[index] = value; }
		}
		/// <summary>
		/// Gets the number of elements contained in the collection.
		/// </summary>
		public int Count {
			get { return items.Count; }
		}
		/// <summary>
		/// Gets a value indicating whether collection is read-only.
		/// </summary>
		public bool IsReadOnly {
			get { return false; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		public TriangleCollection ()
		{
			items = new List<Triangle> ();
		}
		#endregion

		#region Instance Methods
		/// <summary>
		/// Returns the triangle containing the given coordinates, or null
		/// if a triangle wasn't found.
		/// </summary>
		/// <param name="x">x coordinate.</param>
		/// <param name="y">y coordinate.</param>
		public Triangle FindByCoordinates (float x, float y)
		{
			foreach (Triangle t in this) {
				if (t.Contains (x, y) != PointShapeRelation.Outside) {
					return t;
				}
			}
			
			return null;
		}
		#endregion

		#region Interface Implementation
		/// <summary>
		/// Adds an item to the collection.
		/// </summary>
		/// <param name="item">the new item.</param>
		public void Add (Triangle item)
		{
			items.Add (item);
		}
		/// <summary>
		/// Inserts an item to the collection at the specified index.
		/// </summary>
		/// <param name="index">the zero-based index at which
		/// <paramref name="item"/> should be inserted.</param>
		/// <param name="item">the new item.</param>
		public void Insert (int index, Triangle item)
		{
			items.Insert (index, item);
		}
		/// <summary>
		/// Removes the item at the given index.
		/// </summary>
		/// <param name="index">the index of the item to remove</param>
		public void RemoveAt (int index)
		{
			items.RemoveAt (index);
		}
		/// <summary>
		/// Removes the given item from the collection.
		/// </summary>
		/// <param name="item">the item to remove.</param>
		/// <returns>
		/// true if the item was removed; otherwise false.
		/// </returns>
		public bool Remove (Triangle item)
		{
			return items.Remove (item);
		}
		/// <summary>
		/// Removes all items from the collection.
		/// </summary>
		public void Clear ()
		{
			items.Clear ();
		}
		/// <summary>
		/// Finds the given item in the collection and returns its index.
		/// </summary>
		/// <param name="item">the item to find.</param>
		/// <returns>
		/// Returns the index of the given item; or -1 if the item
		/// was not found.
		/// </returns>
		public int IndexOf (Triangle item)
		{
			return items.IndexOf (item);
		}
		/// <summary>
		/// Determines if the given item is a member of the collection.
		/// </summary>
		/// <param name="item">the item to find.</param>
		/// <returns>
		/// true if the item was found; otherwise false.
		/// </returns>
		public bool Contains (Triangle item)
		{
			return items.Contains (item);
		}
		/// <summary>
		/// Copies the elements of the collection to an array, starting at
		/// a particular index.
		/// </summary>
		/// <param name="array">the target array.</param>
		/// <param name="arrayIndex">the index in the array where copying begins.</param>
		public void CopyTo (Triangle[] array, int arrayIndex)
		{
			items.CopyTo (array, arrayIndex);
		}
		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// A enumerator object that can be used to iterate through the collection.
		/// </returns>
		public IEnumerator<Triangle> GetEnumerator ()
		{
			return items.GetEnumerator ();
		}
		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// A enumerator object that can be used to iterate through the collection.
		/// </returns>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return GetEnumerator ();
		}
		#endregion
	}
}

