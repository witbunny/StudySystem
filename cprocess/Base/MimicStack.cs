using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	public class MimicStack
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

	public class MimicStack<T>
	{
		private T[] stack;
		private int pointEmpty;

		public bool IsEmpty { get => pointEmpty == 0; }
		public bool IsFull { get => pointEmpty == stack.Length; }

		public MimicStack(int deep)
		{
			stack = new T[deep];
			pointEmpty = 0;
		}

		public int Push(T data, out T result)
		{
			if (IsFull)
			{
				Console.WriteLine("栈溢出");
				result = default(T);
				return 0;
			}
			else
			{
				stack[pointEmpty] = data;
				pointEmpty++;
				result = data;
				return 1;
			}

		}

		public int Push(T[] datas, out List<T> result)
		{
			result = new List<T>();

			for (int i = 0; i < datas.Length; i++)
			{
				if (Push(datas[i], out T single) == 0)
				{
					return i;
				}
				else
				{
					result.Add(single);
				}
			}
			return datas.Length;
		}

		public bool Pop(out T result)
		{
			if (IsEmpty)
			{
				Console.WriteLine("栈已空");
				result = default(T);
				return false;
			}
			else
			{
				pointEmpty--;
				result = stack[pointEmpty];
				return true;
			}
		}
	}
}
