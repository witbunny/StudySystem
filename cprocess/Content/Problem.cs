using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace cprocess
{
	public class Problem
		: Content
	{
		//private string title;
		//private string body;
		private int reward;
		//private User author;
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
					throw new ArgumentOutOfRangeException("value", $"{value}小于零");
					//Console.WriteLine("悬赏不能为负数");
					//return;
				}
				reward = value;
			}
		}
		public User Author { get; set; }

		#region 

		#endregion
		[HelpMoneyChanged(0, Message = "求助发布")]
		public override void Publish()
		{
			if (Author == null)
			{
				throw new ArgumentNullException("Author", "Author为空");
			}
			Reward = -10;
			Author.HelpMoney -= reward;
			
			//HelpMoneyChangedAttribute hmca = (HelpMoneyChangedAttribute)typeof(Problem).GetMethod("Publish").GetCustomAttribute(typeof(HelpMoneyChangedAttribute));
			//hmca.ChangeAmount = -reward;
			//Console.WriteLine($"帮帮币-{reward}");
		}

		public static string Load(int Id)
		{
			return "";
		}

		public static string Delete(int Id)
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
