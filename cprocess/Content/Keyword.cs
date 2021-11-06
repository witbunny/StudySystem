using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	public class Keyword : Entity
	{
		public string Name { get; set; }
		public IList<Article> Articles { get; set; }
	}
}
