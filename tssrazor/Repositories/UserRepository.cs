using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tssrazor.Entities;

namespace tssrazor.Repositories
{
	public class UserRepository : Repository
	{
		private static IList<User> users;

		static UserRepository()
		{
			users = new List<User>
			{
				new User(1, "leo") { InviteCode = "0101" },
				new User(2, "tik") { InviteCode = "0202" }
			};
		}

		public override IList<int> GetIdTable()
		{
			return users.Select(u => u.Id).ToList();
		}

		public User Find(int id)
		{
			return users.Where(u => u.Id == id).SingleOrDefault();
		}

		public User Find(string name)
		{
			return users.Where(u => u.Name == name).SingleOrDefault();
		}

		public bool Delete(int id)
		{
			var find = Find(id);
			if (find != default)
			{
				users.Remove(find);
				return true;
			}

			return false;
		}

		public bool Save(User user)
		{
			if (users.All(u => u.Id != user.Id))
			{
				users.Add(user);
				return true;
			}

			return false;
		}


	}
}
