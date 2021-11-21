using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tssrazor.Repositories;

namespace tssrazor.Entities
{
	public class User : Entity
	{
		public User(UserRepository userRepository, string name)
			: base(userRepository)
		{
			Name = name;
		}
		public User(int id, string name)
			: base(id)
		{
			Name = name;
		}

		public string Name { get; set; }
		public string Password { get; set; }

		
	}
}
