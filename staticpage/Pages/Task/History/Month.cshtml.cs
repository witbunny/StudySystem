using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace staticpage.Pages.Task.History
{
	public class MonthModel : PageModel
	{
		public Calendar Calendar { get; set; }
		public IList<DateTime[]> MonthCalendar { get; set; }
		public int Year { get; set; }
		public int Month { get; set; }

		public void OnGet()
		{
			Year = int.Parse(Request.Query["year"][0]);
			Month = int.Parse(Request.Query["month"][0]);
			Calendar = new Calendar();
			MonthCalendar = Calendar.GetMonthCalendar(Year, Month);
		}
	}

	public class Calendar
	{
		public Calendar() : this(DayOfWeek.Monday) { }
		public Calendar(DayOfWeek startDayOfWeek)
		{
			StartDayOfWeek = startDayOfWeek;
			if (StartDayOfWeek == DayOfWeek.Sunday)
			{
				EndDayOfWeek = DayOfWeek.Saturday;
			}
			else
			{
				EndDayOfWeek = StartDayOfWeek - 1;
			}
		}
	
		public DayOfWeek StartDayOfWeek { get; }
		public DayOfWeek EndDayOfWeek { get; }

		public DateTime FirstDayOfFirstWeekInMonth(int year, int month)
		{
			DateTime currentDay = new DateTime(year, month, 1);
			while (currentDay.DayOfWeek != StartDayOfWeek)
			{
				currentDay = currentDay.AddDays(-1);
			}
			return currentDay;
		}
		public DateTime LastDayOfLastWeekInMonth(int year, int month)
		{
			DateTime currentDay = new DateTime(year, month, 1);
			currentDay = currentDay.AddDays(DateTime.DaysInMonth(year, month) - 1);
			while (currentDay.DayOfWeek != EndDayOfWeek)
			{
				currentDay = currentDay.AddDays(1);
			}
			return currentDay;
		}

		public IList<DateTime[]> GetMonthCalendar(int year, int month)
		{
			IList<DateTime[]> monthCalendar = new List<DateTime[]>();

			DateTime startDay = FirstDayOfFirstWeekInMonth(year, month);
			DateTime endDay = LastDayOfLastWeekInMonth(year, month);
			while (startDay != endDay.AddDays(1))
			{
				DateTime[] temp = new DateTime[7];
				for (int i = 0; i < 7; i++)
				{
					temp[i] = startDay;
					startDay = startDay.AddDays(1);
				}
				monthCalendar.Add(temp);
			}

			return monthCalendar;
		}


	}
}
