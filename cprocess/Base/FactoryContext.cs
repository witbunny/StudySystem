using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	class FactoryContext
	{
		public readonly static FactoryContext fc = new FactoryContext();

		private FactoryContext()
		{

		}
	}
}
