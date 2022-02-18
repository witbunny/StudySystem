using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace captcha
{
	public class Student : Person
	{
		public double Score { get; set; }

		public Bed Bed { get; set; }

		public IList<Teacher> Teachers { get; set; }
	}
}
