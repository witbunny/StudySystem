﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace cprocess.EF
{
	[Table("EF_Teacher")]
	class EfTeacher
	{
		public int Id { get; set; }
		public string Name { get; set; }

	}
}
