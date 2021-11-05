using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	
	public delegate int ProvideWater(Person person);
	public delegate int Water(ProvideWater pw);

	
}
