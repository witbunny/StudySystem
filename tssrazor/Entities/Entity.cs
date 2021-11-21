using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tssrazor.Repositories;

namespace tssrazor.Entities
{
	public abstract class Entity
	{
		protected IList<int> idTable;

		public Entity(Repository repository)
		{
			idTable = repository.GetIdTable();
			idTable = idTable.OrderBy(i => i).ToList();
			Id = idTable.Count == 0 ? 1 : idTable.Last() + 1;
		}
		public Entity(int id)
		{
			Id = id;
		}

		public int Id { get; protected set; }

	}
}
