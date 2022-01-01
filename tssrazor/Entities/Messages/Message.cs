using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tssrazor.Repositories;

namespace tssrazor.Entities.Messages
{
	public class Message : Entity
	{
		public Message()
		{

		}

		public Message(MessageRepository messageRepository, KindOfMessage kind)
			: base(messageRepository)
		{
			Kind = kind;
		}

		public Message(int id, KindOfMessage kind)
			: base(id)
		{
			Kind = kind;
		}

		public KindOfMessage Kind { get; set; }
		public DateTime CreateTime { get; set; }
		public User Addresser { get; set; }
		public User Recipient { get; set; }
		public MessageStatus Status { get; set; }

		public bool IsChecked { get; set; }
	}

	public enum KindOfMessage
	{
		Unknown = 0,
		//[Description("刷新")]
		//[Display(Name = "刷新")]
		Refresh = 1
	}

	public enum MessageStatus
	{
		Unread = 0,
		Read = 1,
		Deleted = 2,
		All = 3
	}
}
