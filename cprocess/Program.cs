using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace cprocess
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//线程
			//Thread current = Thread.CurrentThread;
			//Console.WriteLine(Thread.GetDomain().FriendlyName);
			//Console.WriteLine(current.ManagedThreadId);
			//Console.WriteLine(current.Priority);
			//Console.WriteLine(current.ThreadState);

			//Thread newthread = new Thread(ShowManagedThreadId);
			//newthread.Start();

			//for (int i = 0; i < 20; i++)
			//{
			//	new Thread(() =>
			//	{
			//		Console.WriteLine($"{i}:ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
			//	}).Start();
			//}


			//任务
			/*
			Action getup = () =>
			{
				Console.WriteLine("getup()...");
			};
			Func<int> getdown = () =>
			{
				Console.WriteLine("getdown()...");
				return new Random().Next();
			};

			//Task t1 = new Task(getup);
			//Task t2 = new Task<int>(getdown);

			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine($"before task:第{i + 1}次");
				Console.WriteLine();

				new Task(getup)
				.Start();

				for (int j = 0; j < 5; j++)
				{
					Console.WriteLine($"after task:j+1={j + 1}");
				}
				Console.WriteLine();
			}
			*/

			//异步方法
			//Task<int> task = getRandom();
			//Console.WriteLine(task.Result);
			//Process();

			

			Console.Read();
		}




		/*
		public static void ShowManagedThreadId()
		{
			Console.WriteLine($"ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
		}

		public static Task<int> getRandom()
		{
			Console.WriteLine("in getRandom() before task with Thread-" + Thread.CurrentThread.ManagedThreadId);
			return Task<int>.Run(() =>
			{
				Console.WriteLine("in getRandom() in task with Thread-" + Thread.CurrentThread.ManagedThreadId);
				Thread.Sleep(500);    //模拟耗时
				return new Random().Next();
			});
		}

		public static void Process()
		{
			Console.WriteLine("in Process() before task with Thread-" + Thread.CurrentThread.ManagedThreadId);

			Task<int> task = getRandom();
			
			Console.WriteLine("in Process() after task with Thread-" + Thread.CurrentThread.ManagedThreadId);
			
			Console.WriteLine(task.Result);
			
			Console.WriteLine("in Process() after result with Thread-" + Thread.CurrentThread.ManagedThreadId);
		}
		*/


	}
}
