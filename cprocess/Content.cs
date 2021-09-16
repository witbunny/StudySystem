using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	abstract class Content
		: Entity
	{
		public string title;
		public string body;
		protected string kind;
		private DateTime createTime;
		protected DateTime PublishTime;

		public Content(string cate)
		{
			Kind = cate;
		}

		public string Kind { get; set; }

		public void Add()
		{

		}

		public abstract void Publish();

	}
}
