﻿using System;
using System.Collections.Generic;
using System.Text;

namespace consoleef
{
	public class Teacher : Person
	{
		public string Major { get; set; }
		public double Salary { get; set; }

		public virtual IList<Student> Students { get; set; }
	}
}
