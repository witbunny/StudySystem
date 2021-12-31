using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tssrazor.Repositories;
using tssrazor.Validations;

namespace tssrazor.Entities
{
	public class User : Entity
	{
		public User()
		{

		}
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

		[Required(ErrorMessage = "* 用户名不能为空")]
		[NamePassword]
		[Display(Name = "用户名")]
		public string Name { get; set; }

		[Required(ErrorMessage = "* 密码不能为空")]
		[MinLength(4, ErrorMessage = "* 长度不小于4个")]
		[NamePassword]
		[Display(Name = "密码")]
		public string Password { get; set; }

		public string InviteCode { get; set; }


		public User InvitedBy { get; set; }
	}
}
