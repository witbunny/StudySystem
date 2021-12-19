using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tssrazor.Repositories;

namespace tssrazor.Entities.Messages
{
	public class Refresh : Message
	{
		public Refresh(MessageRepository messageRepository, DateTime dateTime, User recipient)
			: base(messageRepository, KindOfMessage.Refresh)
		{
			CreateTime = dateTime;
			Recipient = recipient;
		}

		public Refresh(int id, DateTime dateTime, User recipient)
			: base(id, KindOfMessage.Refresh)
		{
			CreateTime = dateTime;
			Recipient = recipient;
		}
	}
}
