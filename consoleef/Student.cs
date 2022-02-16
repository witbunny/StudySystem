using System;
using System.Collections.Generic;
using System.Text;

namespace consoleef
{
	public class Student : Person
	{
		public string Major { get; set; }
		public double Score { get; set; }

		public int? BedId { get; set; }
		public virtual Bed Bed { get; set; }

		//public int? ClassroomId { get; set; }
		public virtual Classroom Classroom { get; set; }

		public virtual IList<Teacher> Teachers { get; set; }
	}
}
