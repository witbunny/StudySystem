using cprocess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nutesttdd
{
	class ArticleTests
	{
		User leo, asa, tik;
		IEnumerable<User> users;

		Keyword csharp, net, linq;
		IEnumerable<Keyword> keywords;

		Article generic, collection, lambda, where, select;
		IEnumerable<Article> articles;

		Comment excellent, good, bad;
		IEnumerable<Comment> comments;

		[SetUp]
		public void ArticleInit()
		{
			leo = new User { Name = "leo" };
			asa = new User { Name = "asa" };
			tik = new User { Name = "tik" };
			users = new List<User> { leo, asa, tik };

			csharp = new Keyword { Name = "C#" };
			net = new Keyword { Name = ".Net" };
			linq = new Keyword { Name = "Linq" };
			keywords = new List<Keyword> { csharp, net, linq };

			generic = new Article("为什么要有泛型")
			{
				Author = leo,
				Keywords = new List<Keyword> { csharp, net }
			};
			collection = new Article("泛型集合的优点")
			{
				Author = leo,
				Keywords = new List<Keyword> { csharp, net }
			};
			lambda = new Article("匿名方法与Lambda表达式")
			{
				Author = asa,
				Keywords = new List<Keyword> { csharp }
			};
			where = new Article("where的语法特点")
			{
				Author = tik,
				Keywords = new List<Keyword> { linq }
			};
			select = new Article("select与where的区别")
			{
				Author = tik,
				Keywords = new List<Keyword> { linq }
			};
			articles = new List<Article> { generic, collection, lambda, where, select };

			excellent = new Comment
			{
				Body = "非常棒！",
				Commenter = tik,
				Article = generic
			};
			good  = new Comment
			{
				Body = "好好好！",
				Commenter = asa,
				Article = generic
			};
			bad = new Comment
			{
				Body = "差差差！",
				Commenter = asa,
				Article = where
			};
			comments = new List<Comment> { excellent, good, bad };
		}

		[Test]
		public void ArticleTest()
		{
			var leoArticles = from a in articles
							  where a.Author == leo
							  select a;
			foreach (var item in leoArticles)
			{
				Console.WriteLine(item.Title + ":" + item.Author.Name);
			}

			var orderArticles = from a in articles
								orderby a.PublishTime descending
								select a;
			foreach (var item in orderArticles)
			{
				Console.WriteLine(item.Title + ":" + item.PublishTime);
			}

			var countArticles = from a in articles
								group a by a.Author
								into g
								select new
								{
									g.Key.Name,
									Count = g.Count()
								};
			foreach (var item in countArticles)
			{
				Console.WriteLine(item.Name + ":" + item.Count);
			}

			var keywordArticles = from a in articles
								  where a.Keywords.Contains(csharp) || a.Keywords.Contains(net)
								  select a;
			foreach (var item in keywordArticles)
			{
				foreach (var i in item.Keywords)
				{
					Console.WriteLine(item.Title + ":" + i.Name);
				}
			}


		}
	}
}
