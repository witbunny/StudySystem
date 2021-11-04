using cprocess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace nutesttdd
{
	class WaterTests
	{
		[Test]
		public void WaterTest()
		{
			Person person = new Person()
			{
				Age = 23,
				Height = 170,
				Weight = 65
			};
			ProvideWater provide;

			provide = AgeWater;
			Assert.AreEqual(23, provide(person));

			provide = delegate (Person person)
			{
				return person.Height;
			};
			Assert.AreEqual(170, provide(person));

			provide = p =>  p.Weight;
			Assert.AreEqual(65, provide(person));


			Assert.AreEqual(23, GetWater(person, AgeWater));
			Assert.AreEqual(170, GetWater(person, HeightWater));
			Assert.AreEqual(65, GetWater(person, WeightWater));


			Water water = delegate (ProvideWater pw)
			{
				return pw(person);
			};
			Assert.AreEqual(23, water(AgeWater));
			Assert.AreEqual(170, water(HeightWater));
			Assert.AreEqual(65, water(WeightWater));

		}

		public static int GetWater(Person person, ProvideWater pw)
		{
			return pw(person);
		}

		public static int AgeWater(Person person)
		{
			return person.Age;
		}
		public static int HeightWater(Person person)
		{
			return person.Height;
		}
		public static int WeightWater(Person person)
		{
			return person.Weight;
		}
	}
}
