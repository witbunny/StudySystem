using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tssrazor.Entities;

namespace tssrazor.Repositories
{
	public class KeywordRepository : Repository
	{
		private static IList<Keyword> keywords;

		static KeywordRepository()
		{
			keywords = new List<Keyword>
			{
				new Keyword() { Id = 1, Name = "编程", UsedAmount = 17 },
				new Keyword() { Id = 2, Name = "软件", UsedAmount = 12 },
				new Keyword() { Id = 3, Name = "语言", UsedAmount = 25 },
				new Keyword() { Id = 4, Name = "设计模式", UsedAmount = 5 },
				new Keyword() { Id = 5, Name = "范式", UsedAmount = 3 }
			};
		}

		public override IList<int> GetIdTable()
		{
			return keywords.Select(w => w.Id).ToList();
		}

		public IList<Keyword> GetList(int skipCount, int takeCount)
		{
			return keywords.Skip(skipCount).Take(takeCount).ToList();
		}
	}
}
