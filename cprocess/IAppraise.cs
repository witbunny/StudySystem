using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	interface IAppraise
	{
		void Agree(User ath, User apr);
		void Disagree(User ath, User apr);
	}
}
