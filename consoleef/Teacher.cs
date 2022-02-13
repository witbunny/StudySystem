using System;
using System.Collections.Generic;
using System.Text;

namespace consoleef
{
	class Teacher : Person
	{
		public string Major { get; set; }
		public double Salary { get; set; }

		public IList<Student> Students { get; set; }
	}
}
