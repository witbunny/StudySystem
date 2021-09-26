using System;

namespace cprocess
{
	class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine(Console.ReadLine());
			///Console.WriteLine(Console.ReadLine());
			///

			///*Console*/.WriteLine(Console.ReadLine());

			/*
			string greet;

			greet = "你好";
			Console.WriteLine(greet);

			greet = "大家好";
			Console.WriteLine(greet);

			const string welcome = "!";
			Console.WriteLine(welcome);

			var age = 32;
			Console.WriteLine(age);

			char a = '源';
			Console.WriteLine(a);

			uint agenum = 23;
			Console.WriteLine(int.MaxValue);
			Console.WriteLine(int.MinValue);
			Console.WriteLine(uint.MaxValue);
			Console.WriteLine(uint.MinValue);

			Console.WriteLine();
			Console.WriteLine(long.MaxValue);
			Console.WriteLine(long.MinValue);

			Console.WriteLine();
			Console.WriteLine(float.MaxValue);
			Console.WriteLine(float.MinValue);

			Console.WriteLine();
			Console.WriteLine(double.MaxValue);
			Console.WriteLine(double.MinValue);

			float score = 87.5F;
			double avg = 60.78994;
			decimal height = 70.45M;

			Console.WriteLine();
			Console.WriteLine(score);
			Console.WriteLine(avg);
			Console.WriteLine(height);

			bool passed = true;
			passed = false;

			Console.WriteLine();
			Console.WriteLine(passed);
			*/

			/*
			long lage;
			int iage = 23;
			lage = iage;

			iage = (int)lage;

			string str = iage.ToString();
			iage = Convert.ToInt32(str);
			iage = int.Parse("32");

			int a, b, c;
			a = b = c = 50;

			Console.WriteLine(3 + 2);
			Console.WriteLine(3 - 2);
			Console.WriteLine(3 * 2);
			Console.WriteLine(4 / 2);
			*/

			/*
			float a = 3;
			int b = 2;
			var c = a / b;

			Console.WriteLine(c);

			Console.WriteLine(0.1 + 0.2);//精度

			Console.WriteLine(true || true && false);//||&&短路
			Console.WriteLine(2 | 5);//10 101  111  7

			int n = 10;
			Console.WriteLine(n++);
			n = 10;
			Console.WriteLine(++n);
			*/

			/*
			//Console.WriteLine(233 + "一起来" + true);
			string name = "你好", wel = "一起来";
			//Console.WriteLine($"'{name}'\\\\，\r\n\"{wel}\"!");
			//Console.WriteLine($"'{name}'\\\\，" + Environment.NewLine + $"\"{wel}\"!");
			

			Console.WriteLine(@"E:\echo\zero\adn\adnWork\StudySystem\cprocess");
			Console.WriteLine($"'{name}'\\\\，\r\n\"{wel}\"!");
			Console.WriteLine($@"'{name}'\\\\，
				
					{wel}!");
			*/

			/*
			if (true)
			{

			}
			else
			{

			}

			string[] name = new string[3];
			name[0] = "fj";
			Console.WriteLine(name.Length); 

			while (true)
			{

			}

			for (int i = 0; i < length; i++)
			{

			}
			*/
			////////////////////////////////////////////////////////////////////
			///电脑计算并输出：[(23+7)x12-8]÷6的小数值（挑战：精确到小数点以后2位）


			/*

			Console.WriteLine(Math.Round(((float)((23 + 7) * 12 - 8) / 6), 2));

			///////////////////////////////////////////////////////////////////
			///
			int i = 15;
			Console.WriteLine(i++);
			i -= 5;
			Console.WriteLine(i);
			Console.WriteLine(i >= 10);

			Console.WriteLine("i值的最终结果为：" + i);

			int j = 20;
			Console.WriteLine($"{i}+{j}={i + j}");
			///15
			///11
			///true
			///11
			///11+20=31

			//////////////////////////////////////////////////////////////////
			///
			int a = 10;
			Console.WriteLine(a > 9 && (!(a < 11) || a > 10));
			//false

			////////////////////////////////////////////////////////////////
			///
			bool result = (a + 3 > 12) && a < 3.14 * 4 && a != 11;
			//9 < a < 12.56  a != 11

			//////////////////////////////////////////////////////////////
			///观察一起帮登录页面，用if...else...完成以下功能。
			//			用户依次由控制台输入：验证码、用户名和密码：
			//如果验证码输入错误，直接输出：“*验证码错误”；
			//如果用户名不存在，直接输出：“*用户名不存在”；
			//如果用户名或密码错误，输出：“*用户名或密码错误”
			//以上全部正确无误，输出：“恭喜！登录成功！”
			//PS：验证码 / 用户名 / 密码直接预设在源代码中，输入由Console.ReadLine()完成。
			string code = "ut91";
			string name = "yezi";
			string pass = "1234";
			bool login = false;

			do
			{
				Console.WriteLine($"请输入验证码（{code}）：");
				if (code != Console.ReadLine())
				{
					Console.WriteLine("验证码错误");
				}
				else
				{
					do
					{
						Console.WriteLine($"请输入用户名（{name}）：");
						if (name != Console.ReadLine())
						{
							Console.WriteLine("用户名不存在");
						}
						else
						{
							do
							{
								Console.WriteLine($"请输入密码（{pass}）：");
								if (pass != Console.ReadLine())
								{
									Console.WriteLine("密码错误");
								}
								else
								{
									Console.WriteLine("恭喜！登录成功！");
									login = true;
								}
							} while (!login);
						}
					} while (!login);
				}
			} while (!login);


			*/

			/*
			////////////////////////////////////////////////////////////////
			///
			//将源栈同学姓名 / 昵称分别：
			//按进栈时间装入一维数组，
			//按座位装入二维数组，
			//并输出共有多少名同学。
			string[] stu = new string[] { "张三", "李四", "王五", "赵六" };
			string[,] seat = new string[,] { { "张三", "王五" }, { "李四", "赵六" } };
			Console.WriteLine(stu.Length);
			Console.WriteLine(seat.Length);

			//用for循环输出存储在一维 / 二维数组里的源栈所有同学姓名 / 昵称
			for (int i = 0; i < stu.Length; i++)
			{
				Console.WriteLine(stu[i]);
			}
			Console.WriteLine();
			for (int i = 0; i < seat.GetLength(0); i++)
			{
				for (int j = 0; j < seat.GetLength(1); j++)
				{
					Console.WriteLine(seat[i, j]);
				}
			}
			//将源栈同学的成绩存入一个double数组中，用循环找到最高分和最低分
			double[] score = new double[] { 78.5, 89.3, 67.4, 93.6 };
			double ma = score[0];
			double mi = score[0];

			for (int i = 1; i < score.Length; i++)
			{
				//if (ma < score[i])
				//{
				//	ma = score[i];
				//}//else nothing

				ma = ma < score[i] ? score[i] : ma;

				//if (mi > score[i])
				//{
				//	mi = score[i];
				//}//else nothing

				mi = mi > score[i] ? score[i] : mi;
			}
			Console.WriteLine(ma);
			Console.WriteLine(mi);
			//生成一个元素（值随机，使用new Random()）从小到大排列的数组
			int n = 10;
			int[] num = new int[n];
			for (int i = 0; i < num.Length; i++)
			{
				Random rnd = new Random();
				num[i] = rnd.Next();
				Console.WriteLine(num[i]);
			}
			for (int i = 0; i < num.Length; i++)
			{
				for (int j = i + 1; j < num.Length; j++)
				{
					if (num[i] > num[j])
					{
						int temp = num[i];
						num[i] = num[j];
						num[j] = temp;
					}//else nothing
				}
			}
			Console.WriteLine();

			for (int i = 0; i < num.Length; i++)
			{
				Console.WriteLine(num[i]);
			}

			Console.WriteLine();

			//设立并显示一个多维数组的值，元素值等于下标之和。Console.Write()
			int a = 3, b = 6;
			int[,] matrix = new int[a, b];
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					matrix[i, j] = i + j;
					Console.Write(matrix[i, j]);
				}
				Console.WriteLine();
			}

			*/

			/*
			//利用ref调用Swap()方法交换两个同学的床位号
			int seata = 18, seatb = 32;
			Swap(ref seata, ref seatb);
			Console.WriteLine(seata);
			Console.WriteLine(seatb);

			//将登陆的过程封装成一个方法LogOn()，调用之后能够获得：
			//true / false，表示登陆是否成功
			//string，表示登陆失败的原因
			//if (LogOn(out string message))
			//{
			//	Console.WriteLine("恭喜！登录成功！");
			//}
			//else
			//{
			//	Console.WriteLine(message);
			//}

			//将之前作业封装成方法（自行思考参数和返回值），并调用执行。且以后作业，如无特别声明，皆需使用方法封装。

			//计算得到源栈同学的平均成绩（精确到两位小数），方法名GetAverage()
			double[] score = new double[] { 78.56, 98.75, 67.54, 85.35 };
			double avg = GetAverage(78.56, 98.75, 67.54, 85.35);
			Console.WriteLine(avg);

			//完成“猜数字”游戏，方法名GuessMe()：
			//随机生成一个大于0小于1000的整数
			//用户输入一个猜测值，系统进行判断，告知用户猜测的数是“大了”，还是“小了”
			//没猜中可以继续猜，但最多不能超过10次
			//如果5次之内猜中，输出：你真牛逼！
			//如果8次之内猜中，输出：不错嘛！
			//10次还没猜中，输出：(～￣(OO)￣)ブ
			GuessMe();

			*/



			//User newUser = new User("admin", "123", "lilei");
			//{
			//	name = "zl",
			//	password = "123",
			//	invitedBy = "lilei"
			//};

			//User newUser = new User()
			//{
			//	Name = "admin",
			//	Password = "123"
			//};


			/*------------------------------------------------------------------

			Console.WriteLine(newUser.Register());
			Console.WriteLine(newUser.Login());

			//newUser.SetName("zlll");
			//Console.WriteLine(newUser.GetName());

			newUser.Password = "234";
			//Console.WriteLine(newUser.Password);

			var ays = new
			{
				Name = "345",
				pass = "566",
			};

			Problem pbm = new Problem("dotnet", 10);
			pbm.Reward = -57;


			pbm[0] = "C#";
			Console.WriteLine(pbm[0]);


			-----------------------------------------------------------------*/


			/*---------------------------------------------------------------------
			MimicStack mstack = new MimicStack(3);

			Console.WriteLine(mstack.Push(35));
			Console.WriteLine(mstack.Push(25));
			Console.WriteLine(mstack.Push(15));

			Console.WriteLine(mstack.Pop());
			Console.WriteLine(mstack.Push(5));
			Console.WriteLine(mstack.Pop());
			Console.WriteLine(mstack.Pop());

			int[] arr = new int[] { 5, 6, 7, 8, 9 };
			Console.WriteLine(mstack.Push( arr ));
			Console.WriteLine(mstack.Pop());
			Console.WriteLine(mstack.Pop());
			Console.WriteLine(mstack.Pop());
			Console.WriteLine(mstack.Pop());

			------------------------------------------------------------------*/


			/*-----------------------------------------------------------------
			Content ctt = new Problem();
			ctt.Add();
			((Problem)ctt).Publish();

			Problem pbm = ctt as Problem;
			-----------------------------------------------------------------*/


			/*------------------------------------------------------------------
			Article atc = new Article();
			Suggest sgt = new Suggest();
			Problem pbm = new Problem()
			{
				Reward = 10
			};

			ContentService.Release(atc);
			ContentService.Release(sgt);
			ContentService.Release(pbm);

			-------------------------------------------------------------------*/


			/*--------------------------------------------------------------------
			Tuition tuition = new Tuition();
			Tuition ttn = tuition;
			tuition.Money = 20.25;

			Cost cost = new Cost();
			Cost cst = cost;
			cost.Money = 20.35;

			DateTime time = new DateTime(2021, 9, 22, 14, 00, 30);
			Console.WriteLine(Tuition.GetDate(time, 20.00));
			Console.WriteLine(Tuition.GetDate(time, 3));
			Console.WriteLine(time.DayOfWeek);

			Tuition.showWeeks(time, 8);

			-------------------------------------------------------------*/

			/*-------------------------------------------------------------
			
			User superX = new User()
			{
				Name = "superX",
				Tokens = new TokenManager(),
			};

			superX.Tokens.Add(Token.Admin);
			superX.Tokens.Add(Token.Blogger);
			superX.Tokens.Add(Token.Newbie);

			superX.Tokens.Remove(Token.Newbie);

			if (superX.Tokens.Has(Token.SuperAdmin))
			{
				superX.Tokens.Remove(Token.SuperAdmin);
			}
			else
			{
				superX.Tokens.Add(Token.SuperAdmin);
			}

			--------------------------------------------------------*/

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

			//接口显式实现的调用
			ISendMessage sm = new User();
			sm.Send();



			Console.Read();
		}

		/*

		private static void GuessMe()
		{
			Console.WriteLine("请输入一个不超过1000的自然数：");
			int target = new Random().Next(0, 1000);
			for (int i = 1; i <= 10; i++)
			{
				int input = int.Parse(Console.ReadLine());
				if (target == input)
				{
					if (i <= 5)
					{
						Console.WriteLine($"恭喜你，答对了！只用了{i}次呢，你真牛逼！");
					}
					else if (i <= 8)
					{
						Console.WriteLine($"恭喜你，答对了！只用了{i}次呢，不错嘛！");
					}
					else
					{
						Console.WriteLine($"恭喜你，答对了！只用了{i}次呢，棒棒哒！");
					}
					return;
				}
				else
				{
					if (i < 10)
					{
						if (target > input)
						{
							Console.WriteLine($"太小了呢！（还剩{10 - i}次）");
						}
						else
						{
							Console.WriteLine($"太大了哟！（还剩{10 - i}次）");
						}
					}
					else
					{
						Console.WriteLine("(～￣(OO)￣)ブ");
					}
				}
			}
		}

		private static double GetAverage(params double[] score)
		{
			double temp = 0.00;
			for (int i = 0; i < score.Length; i++)
			{
				temp += score[i];
			}
			return Math.Round(temp / score.Length, 2);
		}

		private static bool LogOn(out string failed)
		{
			string code = "ut91";
			string name = "yezi";
			string pass = "1234";
			failed = "";

			Console.WriteLine($"请输入验证码（{code}）：");
			if (code != Console.ReadLine())
			{
				failed = "验证码错误";
			}
			else
			{
				Console.WriteLine($"请输入用户名（{name}）：");
				if (name != Console.ReadLine())
				{
					failed = "用户名不存在";
				}
				else
				{
					Console.WriteLine($"请输入密码（{pass}）：");
					if (pass != Console.ReadLine())
					{
						failed = "密码错误";
					}
					else
					{
						return true;
					}
				}
			}
			return false;
		}


		/// <summary>
		/// 交换
		/// </summary>
		/// <param name="a">值一</param>
		/// <param name="b">值二</param>
		static void Swap(ref int a, ref int b)
		{
			int temp = a;
			a = b;
			b = temp;
		}


		*/


	}
}
