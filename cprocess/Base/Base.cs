using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	internal class Base
	{
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



	}
}
