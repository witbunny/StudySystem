using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	enum Token
	{
		SuperAdmin = 16,	//2^4 = 10000
		Admin = 8,			//2^3 = 01000
		Blogger = 4,		//2^2 = 00100
		Newbie = 2,			//2^1 = 00010
		Registered = 1,		//2^0 = 00001
		None = 0
	}
}
