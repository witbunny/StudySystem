using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	class DBMessage
		: ISendMessage
	{
		public void Send()
		{
			Console.WriteLine("send db message");
		}
	}
}
