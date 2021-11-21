using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tssrazor.Repositories;

namespace tssrazor.Entities.Contents
{
	public class Article : Content
	{
		public Article(ArticleRepository articleRepository, string title, User author)
			: base(ContentKind.Article, articleRepository)
		{
			Title = title;
			Author = author;
		}
		public Article(int id, string title, User author)
			: base(ContentKind.Article, id)
		{
			Title = title;
			Author = author;
		}

		public override void Publish()
		{
			if (CreateTime == default)
			{
				CreateTime = DateTime.Now;
				PublishTime = CreateTime;
			}
			else
			{
				PublishTime = DateTime.Now;
			}
		}


	}
}
