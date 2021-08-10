using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	class User
	{
		private string name;
		private string password;
		private string invitedBy;

		public User()
		{

		}

		public User(string name, string password)
		{
			//this.name = name;
			Name = name;
			this.password = password;
		}

		public User(string name, string password, string invitedBy)
			: this(name, password)
		{
			this.invitedBy = invitedBy;
		}



		public string Name
		{
			get { return name; }
			set 
			{
				name = value == "admin" ? "系统管理管" : value;
			}
		}

		//public string GetName()
		//{
		//	return name;
		//}

		//public void SetName(string name)
		//{
		//	this.name = name;
		//}

		public string Password
		{
			private get { return password; }
			set { password = value; }
		}

		//public string GetPassword()
		//{
		//	return password;
		//}

		//public void SetPassword(string password)
		//{
		//	this.password = password;
		//}

		public string GetInviteBy()
		{
			return invitedBy;
		}

		public void SetInviteBy(string invitedBy)
		{
			this.invitedBy = invitedBy;
		}


		public string Register()
		{
			return $"{name}开始注册，密码：{password}，邀请人：{invitedBy}";
		}

		public string Login()
		{
			return $"{name}开始登录，输入密码：{password}";
		}
	}
}
