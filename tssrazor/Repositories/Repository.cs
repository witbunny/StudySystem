using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tssrazor.Entities;

namespace tssrazor.Repositories
{
	public abstract class Repository
	{
		public abstract IList<int> GetIdTable();
	}

	public class Repository<T> : Repository 
		where T : Entity
	{
		private static IList<T> repositories;

		static Repository()
		{
			repositories = new List<T> { };
		}

		public override IList<int> GetIdTable()
		{
			return repositories.Select(r => r.Id).ToList();
		}

		public T Find(int id)
		{
			return repositories.Where(r => r.Id == id).SingleOrDefault();
		}

		public bool Delete(int id)
		{
			var find = Find(id);
			if (find != default)
			{
				repositories.Remove(find);
				return true;
			}

			return false;
		}

		public bool Save(T entity)
		{
			if (repositories.All(r => r.Id != entity.Id))
			{
				repositories.Add(entity);
				return true;
			}

			return false;
		}


	}
}
