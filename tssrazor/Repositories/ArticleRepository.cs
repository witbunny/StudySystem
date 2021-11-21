using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tssrazor.Entities;
using tssrazor.Entities.Contents;

namespace tssrazor.Repositories
{
	public class ArticleRepository : Repository
	{
		private static IList<Article> articles;

		static ArticleRepository()
		{
			articles = new List<Article>
			{
				new Article(1, "逻辑概念", new UserRepository().Find(1))
				{
					Body = @"复习：

数据结构是一个“逻辑”概念
要拿到数据，必须知道它的地址
以数组为例，在大多数语言中（C#/Java）中：

数组就是一排连续的盒子
每一个盒子都有一个地址，获取盒子里的数据（元素）需要知道它的地址
但数组这排盒子的地址是连续的，或者说，这一排盒子占用了一段连续的地址
所以我们只需要记录第一个盒子的地址（存储在数组变量名中）
当我们要取第n个盒子里的数据，只需要在第一个盒子的地址上加n，就能直接得到该盒子的地址
注意上面第4条，这是我们理解数组的关键，这也是数组被如此广泛使用的原因：我们不是从数组中第1个元素开始，依次挨着数（找）第2个第3个……直到第n个，而是通过运算直接得到第n个数组元素的地址！所以，取数组中第2000个元素，并不会比取数组中第2个元素慢。",
					CreateTime = new DateTime(2021, 5, 5, 9, 7, 8),
					PublishTime = new DateTime(2021, 5, 5, 9, 7, 8)
				},
				new Article(2, "冒泡排序", new UserRepository().Find(1))
				{
					Body = @"需求：将数组中的数字（比如：9 2 3 5 4 7 6 8 1 0），按从小到大的顺序排列

PS：憋说你一眼就看出来啦……

建议：在学习冒泡排序之前，先@想一想@自己的方案，比如，可不可以：

PS：读别人的代码，比自己写还难

准备一个同样大小的空数组（以下称为：结果数组）
原数组中找到一个最大值（max），放到结果数组第1位
原数组中删除这个最大值（不行，做不到），改成：在原数组中找到除了max以下最大（第2大）的，放到结果数组第2位
循环上述过程，在原数组中找到第3大的，放到结果数组第3位
……
然后，对比一下最经典的入门级算法：冒泡排序",
					CreateTime = new DateTime(2021, 10, 17, 14, 30, 50),
					PublishTime = new DateTime(2021, 10, 17, 14, 30, 50)
				},
				new Article(3, "二分查找", new UserRepository().Find(2))
				{
					Body = @"猜数字的游戏（1-1000），你会怎么猜？

500：大了
250：小了
350：小了
400：大了
375：小了
385：你特么真是个天才！
其实，你这种猜测方法，归纳出来就是二分查找法。

将数组中间位置的元素与查找值比较，如果两者相等，则查找成功；
否则利用中间位置记录将数组分成前、后两个集合，
如果中间位置元素大于查找值，则进一步在其左边/前面的元素中查找，
否则在其右边/后面的元素中查找
重复以上过程，直到找到满足条件的元素",
					CreateTime = new DateTime(2021, 10, 19, 14, 30, 50),
					PublishTime = new DateTime(2021, 10, 19, 14, 30, 50)
				}
			};
		}

		public override IList<int> GetIdTable()
		{
			return articles.Select(a => a.Id).ToList();
		}

		public Article Find(int id)
		{
			return articles.Where(a => a.Id == id).SingleOrDefault();
		}

		public bool Delete(int id)
		{
			var find = Find(id);
			if (find != default)
			{
				articles.Remove(find);
				return true;
			}

			return false;
		}

		public bool Save(Article article)
		{
			if (articles.All(a => a.Id != article.Id))
			{
				articles.Add(article);
				return true;
			}

			return false;
		}


	}
}
