using System;
using System.IO;
using System.Reflection;
using System.Text;
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

			//IO
			//path
			string folderpath = @"E:\echo\zero\adn";
			//string fullpath = Path.Join(folderpath, @"test.text");
			string fullpath = Path.Combine(folderpath, @"test.text");
			Console.WriteLine(fullpath);
			Console.WriteLine("HasExtension:" + Path.HasExtension(fullpath));
			Console.WriteLine("GetExtension:" + Path.GetExtension(fullpath));
			Console.WriteLine("GetFileNameWithoutExtension:" + Path.GetFileNameWithoutExtension(fullpath));
			Console.WriteLine("GetDirectoryName:" + Path.GetDirectoryName(fullpath));

			//directory
			folderpath = Path.Combine(folderpath, @"test\testing");
			Console.WriteLine(folderpath);
			//Directory.CreateDirectory(folderpath);
			//Directory.Delete(folderpath, false);
			Console.WriteLine(Environment.CurrentDirectory);

			//file
			fullpath = Path.Combine(folderpath, @"test.text");
			//FileStream stream = File.Create(fullpath);
			//stream.Write(
			//	new byte[4] { 33, 34, 35, 36 }, //要写入的字节
			//	0,
			//	4  /*缓冲的大小*/);
			//stream.Flush();

			FileStream stream = File.OpenRead(fullpath);
			byte[] container = new byte[100];
			stream.Read(container, 0, 100);
			stream.Flush();
			Console.WriteLine(Encoding.UTF8.GetString(container));

			stream.Dispose();

			/*
			StreamWriter writer = File.AppendText(Path.Join(folderpath, "greet.txt"));
			string greet = "吃饭了";
			writer.Write(greet);
			writer.WriteLine(true);
			writer.Write(new char[] { 'l', 'c', 'b', 'c' });

			//write() 之后还需要flush()才能真正的写入文件
			writer.Flush();

			//调用Dispose()释放文件资源，让其他“人”也可以操作该文件 
			writer.Dispose();
			*/

			using (StreamWriter writer    //StreamWriter实现了IDisposable
				= File.CreateText(Path.Join(folderpath, "greet.txt")))
			{
				writer.Write("吃饭了");
			}//在using块结束时由writer调用其Dispose()方法





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
