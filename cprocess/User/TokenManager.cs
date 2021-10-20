using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	class TokenManager
	{
		private Token? _tokens;

		public void Add(Token token)
		{
			_tokens |= token;
		}

		public void Remove(Token token)
		{
			if (Has(token))
			{
				_tokens ^= token;
			}
			else
			{
				Console.WriteLine("该权限未被赋予");
			}
			
		}

		public bool Has(Token token)
		{
			return (_tokens & token) == token;
		}
	}
}
