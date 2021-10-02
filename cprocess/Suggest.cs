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

		[HelpMoneyChanged(0, Message = "意见发布")]
		public override void Publish()
		{
			Console.WriteLine("帮帮币-000");
		}
	}
}
