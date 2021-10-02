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

		private DateTime CreateTime { get; set; }
		protected DateTime PublishTime { get; private set; }

		public Content(string cate)
		{
			Kind = cate;
			CreateTime = DateTime.Now;
			PublishTime = CreateTime;
		}

		public string Kind { get; set; }

		public void Add()
		{
			
		}

		public abstract void Publish();

	}
}
