﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tssrazor.UIComponents
{
	public class Pagination
	{
		public int PageIndex { get; set; }

		public int PageSize { get; set; }

		public int TotalCount { get; set; }

		public int PageNumber { get; set; }
	}
}
