using System;
using System.Collections.Generic;
using System.Text;

namespace consoleef
{
	public class Classroom : Entity
	{
		public string Name { get; set; }

		public virtual IList<Student> Students { get; set; }
	}
}
