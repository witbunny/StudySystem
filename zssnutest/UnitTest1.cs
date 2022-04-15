using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using zssapicore;
using zssapicore.Controllers;

namespace zssnutest
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			WeatherForecastController controller = new WeatherForecastController(null);
			IEnumerable<WeatherForecast> result = controller.Get();
			Assert.AreEqual(result.ToList().Count, 10);

			Assert.Pass();
		}
	}
}