using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	public class Article
		: Content, IAppraise
	{
		public int AgreeAmount { get; set; }
		public int DisagreeAmount { get; set; }

		public User Author { get; set; }

		public IList<Comment> Comments { get; set; }
		public Appraise Appraise { get; set; }
		public IList<Keyword> Keywords { get; set; }

		public Article(string title)
			: base("article")
		{
			if (string.IsNullOrWhiteSpace(title))
			{
				Console.WriteLine("标题不能为空");
			}
			else if (title.StartsWith(" ") || title.EndsWith(" "))
			{
				Title = title.Trim();
			}
			else
			{
				Title = title;
			}
		}

		[HelpMoneyChanged(-1, Message = "文章发布")]
		public override void Publish()
		{
			//Console.WriteLine("帮帮币-1");
			Author.HelpMoney--;
		}

		public void Agree(/*User ath,*/ User apr)
		{
			//Console.WriteLine($"{ath.Name}帮帮点+1");
			//Console.WriteLine($"{apr.Name}帮帮点-1");
			apr.HelpPoint++;
			Author.HelpPoint++;
			AgreeAmount++;
		}

		public void Disagree(/*User ath,*/ User apr)
		{
			//Console.WriteLine($"{ath.Name}帮帮点-1");
			//Console.WriteLine($"{apr.Name}帮帮点+1");
			apr.HelpPoint++;
			Author.HelpPoint++;
			DisagreeAmount++;
		}
	}
}
