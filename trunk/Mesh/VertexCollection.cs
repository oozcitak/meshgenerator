using System;
using System.Collections;
using System.Collections.Generic;

namespace Manina.Math.Mesh
{
	/// <summary>
	/// Represents a collection of points.
	/// </summary>
	public class VertexCollection : IList<Vertex>, ICollection<Vertex>, IEnumerable<Vertex>
	{
		#region Member Variables
		private List<Vertex> items;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the item at the given index.
		/// </summary>
		/// <param name="index">the item index.</param>
		public Vertex this[int index] {
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
		public VertexCollection ()
		{
			items = new List<Vertex> ();
		}
		#endregion

		#region Instance Methods
		/// <summary>
		/// Returns the vertex at the given coordinates, or null
		/// if a vertex wasn't found.
		/// </summary>
		/// <param name="x">x coordinate.</param>
		/// <param name="y">y coordinate.</param>
		/// </returns>
		public Vertex FindByCoordinates (float x, float y)
		{
			Vertex target = new Vertex (x, y);
			foreach (Vertex v in items) {
				if (target == v) {
					return v;
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
		public void Add (Vertex item)
		{
			items.Add (item);
		}
		/// <summary>
		/// Inserts an item to the collection at the specified index.
		/// </summary>
		/// <param name="index">the zero-based index at which
		/// <paramref name="item"/> should be inserted.</param>
		/// <param name="item">the new item.</param>
		public void Insert (int index, Vertex item)
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
		public bool Remove (Vertex item)
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
		public int IndexOf (Vertex item)
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
		public bool Contains (Vertex item)
		{
			return items.Contains (item);
		}
		/// <summary>
		/// Copies the elements of the collection to an array, starting at
		/// a particular index.
		/// </summary>
		/// <param name="array">the target array.</param>
		/// <param name="arrayIndex">the index in the array where copying begins.</param>
		public void CopyTo (Vertex[] array, int arrayIndex)
		{
			items.CopyTo (array, arrayIndex);
		}
		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// A enumerator object that can be used to iterate through the collection.
		/// </returns>
		public IEnumerator<Vertex> GetEnumerator ()
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

