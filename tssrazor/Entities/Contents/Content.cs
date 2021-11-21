using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tssrazor.Repositories;

namespace tssrazor.Entities.Contents
{
	public abstract class Content : Entity
	{
		public Content(ContentKind kind, Repository repository)
			: base(repository)
		{
			Kind = kind;
		}
		public Content(ContentKind kind, int id)
			: base(id)
		{
			Kind = kind;
		}
		public ContentKind Kind { get; }

		public string Title { get; set; }
		public string Body { get; set; }
		public User Author { get; set; }

		public DateTime CreateTime { get; set; }
		public DateTime PublishTime { get; set; }

		public abstract void Publish();
	}

	public enum ContentKind
	{
		Unknown = 0,
		Article = 1
	}
}
