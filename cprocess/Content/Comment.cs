using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	public class Comment : Entity 
	{
		public string Body { get; set; }
		public User Commenter { get; set; }
		public Article Article { get; set; }
		public Appraise Appraise { get; set; }
	}
}
