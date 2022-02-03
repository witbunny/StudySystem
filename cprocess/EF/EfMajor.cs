using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace cprocess.EF
{
	[Table("EF_Major")]
	class EfMajor
	{
		[Column("MajorId")]
		public int EfMajorId { get; set; }
		[Required]
		public string Name { get; set; }

		[NotMapped]
		public double Difficulty { get; set; }

		public EfTeacher Teacher { get; set; }
	}
}
