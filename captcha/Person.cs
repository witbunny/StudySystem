using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace captcha
{
	public abstract class Person : Entity
	{
		//[Index(IsUnique = true, IsClustered = false)]
		public string Name { get; set; }
	}
}
