using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tssrazor.Entities
{
	public class Keyword : Entity
	{
		public string Name { get; set; }

		public int UsedAmount { get; set; }
	}
}
