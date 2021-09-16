using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	class Article
		: Content, IAppraise
	{
		public Article()
			: base("article")
		{

		}

		public override void Publish()
		{
			Console.WriteLine("帮帮币-1");
		}

		public void Agree(User ath, User apr)
		{
			Console.WriteLine($"{ath.Name}帮帮点+1");
			Console.WriteLine($"{apr.Name}帮帮点-1");
		}

		public void Disagree(User ath, User apr)
		{
			Console.WriteLine($"{ath.Name}帮帮点-1");
			Console.WriteLine($"{apr.Name}帮帮点+1");
		}
	}
}
