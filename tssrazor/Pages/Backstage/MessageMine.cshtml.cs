using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tssrazor.Entities.Messages;
using tssrazor.Repositories;

namespace tssrazor.Pages.Backstage
{
    public class MessageMineModel : PageModel
    {
        private MessageRepository messageRepository;

		public MessageMineModel()
		{
            messageRepository = new MessageRepository();
            PageSize = 10;
		}

        [BindProperty]
        public MessageStatus MsgStatus { get; set; }
        [BindProperty]
        public IList<Message> Messages { get; set; }
        [BindProperty]
        public MessageStatus SubmitStatus { get; set; }

        [BindProperty]
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }

        public void OnGet()
        {
            MsgStatus = (MessageStatus)Convert.ToInt32(RouteData.Values["msgStatus"]);
            PageIndex = Convert.ToInt32(RouteData.Values["pageIndex"]);

            TotalCount = messageRepository.GetCount(MsgStatus);
            PageNumber = (int)Math.Ceiling((double)TotalCount / PageSize);

            Messages = messageRepository.GetList(MsgStatus, PageIndex, PageSize);
        }

        public void OnPost()
		{
			foreach (var item in Messages)
			{
				if (item.IsChecked)
				{
                    messageRepository.Find(item.Id).Status = SubmitStatus;
				}
			}
            PageIndex = 1;

            TotalCount = messageRepository.GetCount(MsgStatus);
            PageNumber = (int)Math.Ceiling((double)TotalCount / PageSize);

            Messages = messageRepository.GetList(MsgStatus, PageIndex, PageSize);
        }
    }
}
