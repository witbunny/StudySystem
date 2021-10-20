using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	internal class MimicStack
	{
		private int[] stack;
		private int point;

		public MimicStack(int deep)
		{
			stack = new int[deep];
			point = -1;
		}

		public int Push(int data)
		{
			if (point == stack.Length - 1)
			{
				Console.WriteLine("栈溢出");
				return 0;
			}
			else
			{
				point++;
				stack[point] = data;
				return 1;
			}

		}

		public int Push(int[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (Push(array[i]) == 0)
				{
					return i;
				}
			}
			return array.Length;
		}

		public int Pop()
		{
			if (point == -1)
			{
				Console.WriteLine("栈已空");
				return -1;
			}
			else
			{
				//stack[point] = 0;
				point--;
				return stack[point + 1];
			}
		}
	}

	internal class MimicStack<T>
	{
		private T[] stack;
		private int point;

		public MimicStack(int deep)
		{
			stack = new T[deep];
			point = -1;
		}

		public int Push(T data)
		{
			if (point == stack.Length - 1)
			{
				Console.WriteLine("栈溢出");
				return 0;
			}
			else
			{
				point++;
				stack[point] = data;
				return 1;
			}

		}

		public int Push(T[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (Push(array[i]) == 0)
				{
					return i;
				}
			}
			return array.Length;
		}

		public bool Pop(out T result)
		{
			if (point == -1)
			{
				Console.WriteLine("栈已空");
				result = default(T);
				return false;
			}
			else
			{
				//stack[point] = 0;
				point--;
				result = stack[point + 1];
				return true;
			}
		}
	}
}
