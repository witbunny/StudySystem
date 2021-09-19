using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	internal struct Tuition
	{
		public double Money { get; set; }

		public Tuition(double money)
		{
			Money = money;
		}

		public static DateTime GetDate(DateTime dateTime, double days)
		{
			return dateTime.AddDays(days);
		}

		public static DateTime GetDate(DateTime dateTime, int months)
		{
			return dateTime.AddMonths(months);
		}

		public static void showWeeks(DateTime dateTime, int count)
		{
			double offsetDays = 0.00;
			switch (dateTime.DayOfWeek)
			{
				case DayOfWeek.Sunday:
					offsetDays = 1.00;
					break;
				case DayOfWeek.Monday:
					offsetDays = 0.00;
					break;
				case DayOfWeek.Tuesday:
					offsetDays = 6.00;
					break;
				case DayOfWeek.Wednesday:
					offsetDays = 5.00;
					break;
				case DayOfWeek.Thursday:
					offsetDays = 4.00;
					break;
				case DayOfWeek.Friday:
					offsetDays = 3.00;
					break;
				case DayOfWeek.Saturday:
					offsetDays = 2.00;
					break;
				default:
					break;
			}

			for (int i = 1; i <= count; i++)
			{
				Console.WriteLine($"第{i}周：{dateTime.AddDays(offsetDays + 7 * (i - 1)).ToString("yyyy年MM月dd日")} - {dateTime.AddDays(offsetDays + 6.00 + 7 * (i - 1)).ToString("yyyy年MM月dd日")}");
			}
		}
	}
}
