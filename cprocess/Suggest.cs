using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	class Suggest
		: Content
	{
		public Suggest()
			: base("suggest")
		{

		}

		public override void Publish()
		{
			Console.WriteLine("帮帮币-000");
		}
	}
}
