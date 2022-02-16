using System;
using System.Collections.Generic;
using System.Text;

namespace consoleef
{
	public class Bed : Entity
	{
		public string Location { get; set; }

		public virtual Student Student { get; set; }
	}
}
