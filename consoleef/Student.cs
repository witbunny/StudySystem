using System;
using System.Collections.Generic;
using System.Text;

namespace consoleef
{
	class Student : Person
	{
		public string Major { get; set; }
		public double Score { get; set; }

		public int? BedId { get; set; }
		public Bed Bed { get; set; }

		//public int TeacherId { get; set; }
		//public Teacher Teacher { get; set; }

		public IList<Teacher> Teachers { get; set; }
	}
}
