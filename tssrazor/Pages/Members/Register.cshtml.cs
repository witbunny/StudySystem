using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tssrazor.Entities;
using tssrazor.Repositories;

namespace tssrazor.Pages.Members
{
    //[BindProperties]
    public class RegisterModel : PageModel
    {
        private UserRepository userRepository;

		public RegisterModel()
		{
            userRepository = new UserRepository();
		}

        [BindProperty]
        public Register Register { get; set; }
        
        public User NewUser { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
		{

            User invitedUser = userRepository.Find(Register.InvitedName);

            NewUser = new User(userRepository, Register.Name)
            {
                Password = Register.Password,
                InvitedBy = invitedUser
            };

            userRepository.Save(NewUser);
		}
    }

    public class Register
	{
        public string Name { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        public string CaptchaCode { get; set; }

        public string InvitedName { get; set; }
        public string InvitedCode { get; set; }
    }
}
