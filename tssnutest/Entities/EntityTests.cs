using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using tssrazor.Entities;
using tssrazor.Entities.Contents;
using tssrazor.Repositories;

namespace tssnutest.Entities
{
	class EntityTests
	{
		[Test]
		public void EntityConstructorTest()
		{
			//Entity entity = new Entity();
			ArticleRepository articleRepository = new ArticleRepository();
			UserRepository userRepository = new UserRepository();

			Article article = new Article(articleRepository, "多态的特性", userRepository.Find(2));
			articleRepository.Save(article);

			Article article2 = new Article(articleRepository, "继承的特性", userRepository.Find(3));
			articleRepository.Save(article2);


		}
	}
}
