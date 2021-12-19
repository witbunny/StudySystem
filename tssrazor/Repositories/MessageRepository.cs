using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tssrazor.Entities.Messages;

namespace tssrazor.Repositories
{
	public class MessageRepository : Repository
	{
		private static IList<Message> messages;

		static MessageRepository()
		{
			messages = new List<Message>
			{
				new Refresh(1, new DateTime(2021, 1, 2, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(2, new DateTime(2021, 2, 2, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(3, new DateTime(2021, 3, 2, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(4, new DateTime(2021, 4, 2, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(5, new DateTime(2021, 5, 2, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(6, new DateTime(2021, 6, 2, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(7, new DateTime(2021, 7, 2, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(8, new DateTime(2021, 8, 2, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(9, new DateTime(2021, 9, 2, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(10, new DateTime(2021, 10, 2, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(11, new DateTime(2021, 11, 2, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(12, new DateTime(2021, 12, 1, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(13, new DateTime(2021, 12, 2, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(14, new DateTime(2021, 12, 3, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(15, new DateTime(2021, 12, 4, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(16, new DateTime(2021, 12, 5, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(17, new DateTime(2021, 12, 6, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(18, new DateTime(2021, 12, 7, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(19, new DateTime(2021, 12, 8, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(20, new DateTime(2021, 12, 9, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(21, new DateTime(2021, 12, 10, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(22, new DateTime(2021, 12, 11, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(23, new DateTime(2021, 12, 12, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(24, new DateTime(2021, 12, 13, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(25, new DateTime(2021, 12, 14, 9, 20, 45), new UserRepository().Find(1)) {  },
				new Refresh(26, new DateTime(2021, 12, 15, 9, 20, 45), new UserRepository().Find(1)) {  }
			};
		}

		public override IList<int> GetIdTable()
		{
			return messages.Select(m => m.Id).ToList();
		}

		public int GetCount(MessageStatus? messageStatus)
		{
			if (messageStatus == null)
			{
				return messages.Count;
			}

			return messages.Where(m => m.Status == messageStatus).Count();
		}

		public IList<Message> GetList(MessageStatus? messageStatus, int pageIndex, int pageSize)
		{
			if (messageStatus == null)
			{
				return messages.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
			}

			return messages.Where(m => m.Status == messageStatus).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
		}

		public Message Find(int id)
		{
			return messages.Where(m => m.Id == id).SingleOrDefault();
		}
	}
}
