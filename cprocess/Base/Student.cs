using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	public class Student : Person
	{
		public double Score { get; set; }
		public IList<Major> Majors { get; set; }
	}
}
