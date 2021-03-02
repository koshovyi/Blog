using System;
using System.Collections;
using System.Collections.Generic;

namespace Blog.DataStructures
{
	public class Stack<T> : IEnumerable<T>
	{

		private readonly int _Size;

		private readonly T[] _Array;

		private int _Top;

		public Stack(int Size)
		{
			this._Size = Size;
			this._Top = 0;
			this._Array = new T[this._Size];
		}

		public int Top
		{
			get
			{
				return this._Top;
			}
		}

		public int Size
		{
			get
			{
				return this._Size;
			}
		}

		public int Count
		{
			get
			{
				return this._Top;
			}
		}

		public bool IsFull()
		{
			return this._Top == this._Size;
		}

		public bool IsEmpty()
		{
			return this._Top == 0;
		}

		public void Push(T Element)
		{
			if (this.IsFull())
				throw new Exception();

			this._Array[this._Top++] = Element;
		}

		public T Peek()
		{
			return this._Array[this._Top - 1];
		}

		public T Pop()
		{
			return this._Array[--this._Top];
		}

		public IEnumerator<T> GetEnumerator()
		{
			if (this.IsEmpty())
				throw new Exception("Стек не заполнен.");

			for (int i = this._Top; i > 0; i--)
				yield return _Array[i - 1];
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

	}

}
