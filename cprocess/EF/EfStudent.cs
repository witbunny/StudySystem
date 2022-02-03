using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace cprocess.EF
{
	[Index("Id", IsUnique = true)]
	class EfStudent
	{
		public int Id { get; set; }
		//[Key]
		public string Name { get; set; }
		public int Age { get; set; }

		public bool IsFemale { get; set; }

		public DateTime Enroll { get; set; }

		public DayOfWeek? Oncall { get; set; }
	}
}
