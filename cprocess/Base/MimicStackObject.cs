using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	public class MimicStackObject
	{
		private Object[] stack;
		private int point;

		public MimicStackObject(int deep)
		{
			stack = new Object[deep];
			point = 0;
		}

		public int Push(Object data)
		{
			if (point == stack.Length)
			{
				Console.WriteLine("栈溢出");
				return 0;
			}
			else
			{
				stack[point] = data;
				point++;
				return 1;
			}
		}

		public int Push(Object[] datas)
		{
			for (int i = 0; i < datas.Length; i++)
			{
				if (Push(datas[i]) == 0)
				{
					return i;
				}//else continue
			}
			return datas.Length;
		}

		public Object Pop()
		{
			if (point == 0)
			{
				Console.WriteLine("栈已空");
				return null;
			}
			else
			{
				point--;
				return stack[point];
			}
		}
	}
}
