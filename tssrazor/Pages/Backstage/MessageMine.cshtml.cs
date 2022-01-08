using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tssrazor.Entities.Messages;
using tssrazor.Filters;
using tssrazor.Repositories;

namespace tssrazor.Pages.Backstage
{
    [NeedLogon]
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

        [BindProperty(SupportsGet = true)]
        public int Testid { get; set; }

		public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
		{
			base.OnPageHandlerSelected(context);
		}

		public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
		{
            //if (string.IsNullOrEmpty(Request.Cookies[Keys.UserId]))
            //{
            //    context.Result = new RedirectToPageResult("/Members/Logon");
            //}
            base.OnPageHandlerExecuting(context);
		}

		public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
		{
			base.OnPageHandlerExecuted(context);
		}

		public IActionResult OnGet()
        {
			//if (string.IsNullOrEmpty(Request.Cookies[Keys.UserId]))
			//{
			//	return RedirectToPage("/Members/Logon");
			//}

			//ViewData["HasLogon"] = Request.Cookies[Keys.UserId];

            MsgStatus = (MessageStatus)Convert.ToInt32(RouteData.Values["msgStatus"]);
            PageIndex = Convert.ToInt32(RouteData.Values["pageIndex"]);

            TotalCount = messageRepository.GetCount(MsgStatus);
            PageNumber = (int)Math.Ceiling((double)TotalCount / PageSize);

			//PageIndex = PageIndex > PageNumber ? PageNumber : PageIndex;
			if (PageIndex > PageNumber)
			{
                return RedirectToPage(new { pageIndex = PageNumber });
			} //else nothing

            Messages = messageRepository.GetList(PageIndex, PageSize, MsgStatus);
			return Page();
        }

        public RedirectToPageResult OnPost()
		{
			foreach (var item in Messages)
			{
				if (item.IsChecked)
				{
                    messageRepository.Find(item.Id).Status = SubmitStatus;
				}
			}

            //PageIndex = 1;

            //TotalCount = messageRepository.GetCount(MsgStatus);
            //PageNumber = (int)Math.Ceiling((double)TotalCount / PageSize);

            //Messages = messageRepository.GetList(PageIndex, PageSize, MsgStatus);

            return RedirectToPage();
        }
    }
}
