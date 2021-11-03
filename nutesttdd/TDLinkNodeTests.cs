using cprocess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace nutesttdd
{
	public class TDLinkNodeTests
	{
		DLinkNode<int> node1, node2, node3, node4;

		[SetUp]
		public void DLNsInit()
		{
			node1 = new DLinkNode<int>();
			node2 = new DLinkNode<int>();
			node3 = new DLinkNode<int>();
			node4 = new DLinkNode<int>();

			//node1.Prev = null;
			node1.Next = node2;
			node2.Prev = node1;
			node2.Next = node3;
			node3.Prev = node2;
			node3.Next = node4;
			node4.Prev = node3;
			//node4.Next = null;
		}

		[Test]
		public void AddTest()
		{
			//AddAfter
			//首
			DLinkNode<int> node8 = new DLinkNode<int>();
			node1.AddAfter(node8);
			//1 [8] 2 3 4
			Assert.IsNull(node1.Prev);
			Assert.AreEqual(node8, node1.Next);
			Assert.AreEqual(node1, node8.Prev);
			Assert.AreEqual(node2, node8.Next);
			Assert.AreEqual(node8, node2.Prev);
			Assert.AreEqual(node3, node2.Next);

			//中
			DLinkNode<int> node9 = new DLinkNode<int>();
			node3.AddAfter(node9);
			//1 8 2 3 [9] 4
			Assert.AreEqual(node2, node3.Prev);
			Assert.AreEqual(node9, node3.Next);
			Assert.AreEqual(node3, node9.Prev);
			Assert.AreEqual(node4, node9.Next);
			Assert.AreEqual(node9, node4.Prev);
			Assert.IsNull(node4.Next);

			//尾
			DLinkNode<int> node10 = new DLinkNode<int>();
			node4.AddAfter(node10);
			//1 8 2 3 9 4 [10]
			Assert.AreEqual(node9, node4.Prev);
			Assert.AreEqual(node10, node4.Next);
			Assert.AreEqual(node4, node10.Prev);
			Assert.IsNull(node10.Next);


			//AddBefore
			//首
			DLinkNode<int> node21 = new DLinkNode<int>();
			node1.AddBefore(node21);
			//[21] 1 8 2 3 9 4 10
			Assert.IsNull(node21.Prev);
			Assert.AreEqual(node1, node21.Next);
			Assert.AreEqual(node21, node1.Prev);
			Assert.AreEqual(node8, node1.Next);

			//中
			DLinkNode<int> node22 = new DLinkNode<int>();
			node3.AddBefore(node22);
			//21 1 8 2 [22] 3 9 4 10
			Assert.AreEqual(node8, node2.Prev);
			Assert.AreEqual(node22, node2.Next);
			Assert.AreEqual(node2, node22.Prev);
			Assert.AreEqual(node3, node22.Next);
			Assert.AreEqual(node22, node3.Prev);
			Assert.AreEqual(node9, node3.Next);

			//尾
			DLinkNode<int> node23 = new DLinkNode<int>();
			node10.AddBefore(node23);
			//21 1 8 2 22 3 9 4 [23] 10
			Assert.AreEqual(node9, node4.Prev);
			Assert.AreEqual(node23, node4.Next);
			Assert.AreEqual(node4, node23.Prev);
			Assert.AreEqual(node10, node23.Next);
			Assert.AreEqual(node23, node10.Prev);
			Assert.IsNull(node10.Next);
		}

		[Test]
		public void DelHeadTest()
		{
			//[1] 2 3 4
			node1.Del(node1);

			Assert.IsNull(node2.Prev);
			Assert.AreEqual(node3, node2.Next);

			//[2] 3 4
			node3.Del(node2);

			Assert.IsNull(node3.Prev);
			Assert.AreEqual(node4, node3.Next);
		}

		[Test]
		public void DelMidTest()
		{
			//1 2 [3] 4
			node1.Del(node3);

			Assert.AreEqual(node1, node2.Prev);
			Assert.AreEqual(node4, node2.Next);
			Assert.AreEqual(node2, node4.Prev);
			Assert.IsNull(node4.Next);

			//1 [2] 4
			node4.Del(node2);

			Assert.IsNull(node1.Prev);
			Assert.AreEqual(node4, node1.Next);
			Assert.AreEqual(node1, node4.Prev);
			Assert.IsNull(node4.Next);
		}

		[Test]
		public void DelTailTest()
		{
			//1 2 3 [4]
			node2.Del(node4);

			Assert.AreEqual(node2, node3.Prev);
			Assert.IsNull(node3.Next);

			//1 2 [3]
			node1.Del(node3);

			Assert.AreEqual(node1, node2.Prev);
			Assert.IsNull(node2.Next);
		}

		[Test]
		public void SwapHeadMidTest()
		{
			//[1] 2 [3] 4 => 3 2 1 4
			node1.Swap(node3);

			Assert.IsNull(node3.Prev);
			Assert.AreEqual(node2, node3.Next);
			Assert.AreEqual(node3, node2.Prev);
			Assert.AreEqual(node1, node2.Next);
			Assert.AreEqual(node2, node1.Prev);
			Assert.AreEqual(node4, node1.Next);
			Assert.AreEqual(node1, node4.Prev);
			Assert.IsNull(node4.Next);

			//[3] [2] 1 4 => 2 3 1 4
			node2.Swap(node3);

			Assert.IsNull(node2.Prev);
			Assert.AreEqual(node3, node2.Next);
			Assert.AreEqual(node2, node3.Prev);
			Assert.AreEqual(node1, node3.Next);
			Assert.AreEqual(node3, node1.Prev);
			Assert.AreEqual(node4, node1.Next);
			Assert.AreEqual(node1, node4.Prev);
			Assert.IsNull(node4.Next);
		}

		[Test]
		public void SwapMidTailTest()
		{
			//1 [2] 3 [4] => 1 4 3 2
			node2.Swap(node4);

			Assert.IsNull(node1.Prev);
			Assert.AreEqual(node4, node1.Next);
			Assert.AreEqual(node1, node4.Prev);
			Assert.AreEqual(node3, node4.Next);
			Assert.AreEqual(node4, node3.Prev);
			Assert.AreEqual(node2, node3.Next);
			Assert.AreEqual(node3, node2.Prev);
			Assert.IsNull(node2.Next);

			//1 4 [3] [2] => 1 4 2 3
			node2.Swap(node3);

			Assert.IsNull(node1.Prev);
			Assert.AreEqual(node4, node1.Next);
			Assert.AreEqual(node1, node4.Prev);
			Assert.AreEqual(node2, node4.Next);
			Assert.AreEqual(node4, node2.Prev);
			Assert.AreEqual(node3, node2.Next);
			Assert.AreEqual(node2, node3.Prev);
			Assert.IsNull(node3.Next);
		}

		[Test]
		public void SwapHeadTailTest()
		{
			//[1] 2 3 [4] => 4 2 3 1
			node1.Swap(node4);

			Assert.IsNull(node4.Prev);
			Assert.AreEqual(node2, node4.Next);
			Assert.AreEqual(node4, node2.Prev);
			Assert.AreEqual(node3, node2.Next);
			Assert.AreEqual(node2, node3.Prev);
			Assert.AreEqual(node1, node3.Next);
			Assert.AreEqual(node3, node1.Prev);
			Assert.IsNull(node1.Next);
		}

		[Test]
		public void SwapAdjTest()
		{
			//1 [2] [3] 4 => 1 3 2 4
			node2.Swap(node3);

			Assert.IsNull(node1.Prev);
			Assert.AreEqual(node3, node1.Next);
			Assert.AreEqual(node1, node3.Prev);
			Assert.AreEqual(node2, node3.Next);
			Assert.AreEqual(node3, node2.Prev);
			Assert.AreEqual(node4, node2.Next);
			Assert.AreEqual(node2, node4.Prev);
			Assert.IsNull(node4.Next);

			//[1] [3] => 3 1
			node3.Next = null;
			node1.Swap(node3);

			Assert.IsNull(node3.Prev);
			Assert.AreEqual(node1, node3.Next);
			Assert.AreEqual(node3, node1.Prev);
			Assert.IsNull(node1.Next);
		}

		[Test]
		public void SwapMidTest()
		{
			//1 [2] 3 [4] 5 => 1 4 3 2 5
			DLinkNode<int> node5 = new DLinkNode<int>();
			node4.Next = node5;
			node5.Prev = node4;
			node2.Swap(node4);

			Assert.IsNull(node1.Prev);
			Assert.AreEqual(node4, node1.Next);
			Assert.AreEqual(node1, node4.Prev);
			Assert.AreEqual(node3, node4.Next);
			Assert.AreEqual(node4, node3.Prev);
			Assert.AreEqual(node2, node3.Next);
			Assert.AreEqual(node3, node2.Prev);
			Assert.AreEqual(node5, node2.Next);
			Assert.AreEqual(node2, node5.Prev);
			Assert.IsNull(node5.Next);
		}

		[Test]
		public void FindByTest()
		{
			node1.Value = 1;
			node2.Value = 10;
			node3.Value = 25;
			node4.Value = 100;

			List<DLinkNode<int>> finded1 = node3.FindBy(10);
			List<DLinkNode<int>> finded2 = node3.FindBy(100);
			List<DLinkNode<int>> finded3 = node4.FindBy(100);
			List<DLinkNode<int>> finded4 = node1.FindBy(100);
			List<DLinkNode<int>> finded5 = node4.FindBy(80);

			Assert.AreEqual(1, finded1.Count);
			Assert.AreEqual(node2, finded1[0]);

			Assert.AreEqual(1, finded2.Count);
			Assert.AreEqual(node4, finded2[0]);

			Assert.AreEqual(1, finded3.Count);
			Assert.AreEqual(node4, finded3[0]);

			Assert.AreEqual(1, finded4.Count);
			Assert.AreEqual(node4, finded4[0]);

			Assert.AreEqual(0, finded5.Count);
		}

		[Test]
		public void ForeachTest()
		{
			foreach (var item in node1)
			{
				//Assert.AreEqual(node1, item);

			}

		}

	}
}
