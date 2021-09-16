using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	class Problem
		: Content
	{
		//private string title;
		//private string body;
		private int reward;
		private string author;
		private string[] keywords;

		public Problem()
			: base("problem")
		{

		}

		public Problem(string body, int num)
			: this()
		{
			Body = body;
			keywords = new string[num];
		}

		public string this[int index]
		{
			get { return keywords[index]; }
			set { keywords[index] = value; }
		}

		public string Title { get; set; }
		public string Body { get; set; }
		public int Reward
		{
			get => reward;
			set 
			{
				if (value < 0)
				{
					Console.WriteLine("悬赏不能为负数");
					return;
				}
				reward = value;
			}
		}
		public string Author { get; set; }


		public override void Publish()
		{
			Console.WriteLine($"帮帮币-{reward}");
		}

		public string Load(int Id)
		{
			return "";
		}

		public string Delete(int Id)
		{
			return "";
		}

		private Repoistory repoistory;

		public Repoistory Repoistory
		{
			get { return repoistory; }
			set { }
		}
	}
}
