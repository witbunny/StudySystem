using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace captcha
{
	public class Entity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public Guid Id { get; set; }
	}
}
