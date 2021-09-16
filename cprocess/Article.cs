using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	class Article
		: Content
	{
		public Article()
			: base("article")
		{

		}

		public override void Publish()
		{
			Console.WriteLine("帮帮币-1");
		}
	}
}
