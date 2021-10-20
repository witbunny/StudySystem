using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	class EmailMessage
		: ISendMessage
	{
		public void Send()
		{
			Console.WriteLine("send email message");
		}
	}
}
