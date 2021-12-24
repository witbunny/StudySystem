using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tssrazor.Validations
{
	public class NamePasswordAttribute : RegularExpressionAttribute
	{
		public NamePasswordAttribute() 
			: base(@"[a-zA-Z]+\d*")
		{
		}

		public override string FormatErrorMessage(string name)
		{
			return $"{name}只能包含大、小写字母或数字，并以大、小写字母开头";
		}
	}
}
