using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	[AttributeUsage(AttributeTargets.Method)]
	public class HelpMoneyChangedAttribute
		: Attribute
	{
		public HelpMoneyChangedAttribute(int amount)
		{
			ChangeAmount = amount;
		}

		public int ChangeAmount { get; set; }

		public string Message { get; set; }
	}
}
