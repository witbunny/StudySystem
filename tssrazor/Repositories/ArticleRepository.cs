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
				new Article(1, "1-逻辑概念", new UserRepository().Find(1))
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
				new Article(2, "2-冒泡排序", new UserRepository().Find(1))
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
				new Article(3, "3-二分查找", new UserRepository().Find(2))
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
				},
				new Article(4, "4-快速排序", new UserRepository().Find(1))
				{
					Body = @"总结：

通过一趟排序将要排序的数据分割成独立的两部分，其中一部分的所有数据都比另外一部分的所有数据都要小
然后再按此方法对这两部分数据分别进行快速排序，整个排序过程可以递归进行……
直到：整个数据变成有序序列。
第一轮
为什么不能简单的按照上述描述进行coding？

受限于“数组”的特征：定长定位。没有int[-1]啊！数组的操作只有一个：交换（swap）

#悟#：运动是相对的。",
					CreateTime = new DateTime(2021, 11, 5, 9, 7, 8),
					PublishTime = new DateTime(2021, 11, 5, 9, 7, 8)
				},
				new Article(5, "5-递归调用", new UserRepository().Find(1))
				{
					Body = @"完成一轮排序之后，如何对其左右两部分再进行一次排序呢？而且还要将这个过程一直执行下去呢……

童鞋们，这就是典型的递归啊！

首先，将每一轮的排序抽象成方法：

function quickSort(arr, left, right){    //@想一想@：为什么要left和right参数？
小技巧：记录下每一轮排序前的oldLeft和oldRight：

int oldLeft = left, oldRight = right;
一轮排序完成之后，继续调用方法自己：

            //左边排序
            quickSort(array, oldLeft, middle - 1);

            //右边排序
            quickSort(array, middle + 1, oldRight);
特别注意，一定要想好递归结束的条件：

            ///1.递归终止条件
            if (left >= right)
            {
                return;
            }",
					CreateTime = new DateTime(2021, 12, 17, 14, 30, 50),
					PublishTime = new DateTime(2021, 12, 17, 14, 30, 50)
				},
				new Article(6, "6-复杂度", new UserRepository().Find(2))
				{
					Body = @"冒泡排序和快速排序哪一个更快？为什么呢？

我们使用复杂度来衡量一个（比较各个）算法的效率：

空间复杂度
还记得飞哥自创的排序法不？用一个新数组按从小到大的顺序来装原数组……这种算法，就额外耗费了一个数组的存储空间；
而冒泡排序法，只耗费了多少额外空间？一个元素对应的临时变量而已。

这种算法所需的额外存储空间多少，就是空间复杂度。

时间复杂度
按字母意思，是指完成某个算法需要消耗的时间。

但因为耗时受硬件影响，不够客观，我们我们通常以运算（循环）次数衡量。

同时，算法还受数据影响

可能有最好的情况（比如第一次循环就找到），
还有可能有最坏的情况（比如直到循环结束才找到），
我们一般默认指的是通常状况，或者说算法的平均复杂度。
用大O表示，指示所需运算（循环）次数和参与运算元素之间的关系，一般包括三个量级：

线性：O(n），类似于 y=x
指数：O(n^2)，类似于 y=x^2
对数：O(log(n))，类似于 y=log(x)",
					CreateTime = new DateTime(2021, 12, 19, 14, 30, 50),
					PublishTime = new DateTime(2021, 12, 19, 14, 30, 50)
				}
			};
		}

		public int Count => articles.Count;

		public override IList<int> GetIdTable()
		{
			return articles.Select(a => a.Id).ToList();
		}

		public IList<Article> GetList(int pageIndex, int pageSize)
		{
			return articles.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
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
