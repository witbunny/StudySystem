using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	class TokenManager
	{
		private Token _tokens;

		public void Add(Token token)
		{
			_tokens |= token;
		}

		public void Remove(Token token)
		{
			_tokens ^= token;
		}

		public bool Has(Token token)
		{
			return (_tokens & token) == token;
		}
	}
}
