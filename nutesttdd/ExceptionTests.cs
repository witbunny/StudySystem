using cprocess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace nutesttdd
{
	class ExceptionTests
	{
		[Test]
		public void ExceptionTest()
		{
			Problem problem = new Problem()
			{
				//Reward = -10
				//Author = new User()
			};

			try
			{
				ContentService.Release(problem);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);

			}

		}
	}
}
