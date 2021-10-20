using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	public class Entity
	{
		protected int id;

		public int Id
		{
			get => id; private set => id = value;
		}
	}

	internal class Entity<T>
	{
		public T Id { get; set; }
	}
}
