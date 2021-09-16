using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	class ContentService
	{
		public static void Release(Content content)
		{
			content.Publish();
			Console.WriteLine("save into db");
		}
	}
}
