using NUnit.Framework;
using staticpage.Pages.Task.History;
using System;
using System.Collections.Generic;
using System.Text;

namespace nutesttdd
{
	class CalendarTests
	{
		[Test]
		public void CalendarTest()
		{
			Calendar calendar = new Calendar();

			Assert.AreEqual(DayOfWeek.Monday, calendar.StartDayOfWeek);
			Assert.AreEqual(DayOfWeek.Sunday, calendar.EndDayOfWeek);
			Assert.AreEqual(new DateTime(2021, 11, 1), 
				calendar.FirstDayOfFirstWeekInMonth(2021, 11));
			Assert.AreEqual(new DateTime(2021, 12, 5),
				calendar.LastDayOfLastWeekInMonth(2021, 11));
			calendar.GetMonthCalendar(2021, 11);
		}
	}
}
