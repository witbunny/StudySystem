using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace captcha
{
	public class Teacher : Person
	{
		public double Salary { get; set; }

		public IList<Student> Students { get; set; }
	}
}
