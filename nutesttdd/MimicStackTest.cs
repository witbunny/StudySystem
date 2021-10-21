using cprocess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace nutesttdd
{
	class MimicStackTest
	{
		//[Test]
		public void MimicStackTest001()
		{
			MimicStack mstack = new MimicStack(3);

			Console.WriteLine(mstack.Push(35));
			Console.WriteLine(mstack.Push(25));
			Console.WriteLine(mstack.Push(15));

			Console.WriteLine(mstack.Pop());
			Console.WriteLine(mstack.Push(5));
			Console.WriteLine(mstack.Pop());
			Console.WriteLine(mstack.Pop());

			int[] arr = new int[] { 5, 6, 7, 8, 9 };
			Console.WriteLine(mstack.Push(arr));
			Console.WriteLine(mstack.Pop());
			Console.WriteLine(mstack.Pop());
			Console.WriteLine(mstack.Pop());
			Console.WriteLine(mstack.Pop());

		}

		//[Test]
		public void MimicStackTest002()
		{
			//构造一个能装任何数据的数组，并完成数据的读写

			Object[] obj = new Object[]
			{
				2, "123", new User()
			};


			//使用object改造数据结构栈（MimicStack），并在出栈时获得出栈元素

			MimicStackObject mso = new MimicStackObject(3);
			Console.WriteLine(mso.Push(1));
			Console.WriteLine(mso.Push("123"));
			Console.WriteLine(mso.Push(new User()));
			Console.WriteLine(mso.Push(new int[] { 1, 2, 3 }));

			Console.WriteLine(mso.Pop());
			Console.WriteLine(mso.Pop());
			Console.WriteLine(mso.Pop());
			Console.WriteLine(mso.Pop());

			Console.WriteLine(mso.Push(new Object[] { new int[] { 1, 2, 3 }, 2, "456", 9 }));

			Console.WriteLine(mso.Pop());
			Console.WriteLine(mso.Pop());
			Console.WriteLine(mso.Pop());
			Console.WriteLine(mso.Pop());
		}

		[Test]
		public void TMimicStackTest()
		{
			//MimicStack mstack = new MimicStack(3);
			MimicStack<int> mstack = new MimicStack<int>(3);

			Console.WriteLine($"{mstack.Push(35, out int putin)}+{putin}");
			Console.WriteLine($"{mstack.Push(25, out putin)}+{putin}");
			Console.WriteLine($"{mstack.Push(15, out putin)}+{putin}");

			Console.WriteLine($"{mstack.Pop(out int putout)}+{putout}");
			Console.WriteLine($"{mstack.Push(5, out putin)}+{putin}");
			Console.WriteLine($"{mstack.Pop(out putout)}+{putout}");
			Console.WriteLine($"{mstack.Pop(out putout)}+{putout}");

			int[] arr = new int[] { 5, 6, 7, 8, 9 };
			Console.WriteLine($"{mstack.Push(arr, out List<int> list)}+{list}");
			Console.WriteLine($"{mstack.Pop(out putout)}+{putout}");
			Console.WriteLine($"{mstack.Pop(out putout)}+{putout}");
			Console.WriteLine($"{mstack.Pop(out putout)}+{putout}");
			Console.WriteLine($"{mstack.Pop(out putout)}+{putout}");
		}
	}
}
