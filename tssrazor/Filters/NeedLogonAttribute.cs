using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tssrazor.Filters
{
	public class NeedLogonAttribute : Attribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			if (string.IsNullOrEmpty(context.HttpContext.Request.Cookies[Keys.UserId]))
			{
				context.Result = new RedirectToPageResult("/Members/Logon");
			}
		}
	}

	public class HasLogonAttribute : Attribute, IPageFilter
	{
		public void OnPageHandlerSelected(PageHandlerSelectedContext context)
		{
			(context.HandlerInstance as PageModel).ViewData["HasLogon"] = context.HttpContext.Request.Cookies[Keys.UserId];
		}

		public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
		{
			//throw new NotImplementedException();
		}

		public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
		{
			//throw new NotImplementedException();
		}
	}

	public class ContextPerRequestAttribute : Attribute, IPageFilter
	{
		public void OnPageHandlerSelected(PageHandlerSelectedContext context)
		{
			//throw new NotImplementedException();
		}

		public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
		{
			//throw new NotImplementedException();
		}

		public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
		{
			//throw new NotImplementedException();
		}
	}

	public class ClearContextAttribute : Attribute, IResultFilter
	{
		public void OnResultExecuting(ResultExecutingContext context)
		{
			//throw new NotImplementedException();
		}

		public void OnResultExecuted(ResultExecutedContext context)
		{
			//throw new NotImplementedException();
		}
	}

	public class CloseConnectionAttribute : ResultFilterAttribute
	{
		public override void OnResultExecuting(ResultExecutingContext context)
		{
			base.OnResultExecuting(context);
		}

		public override void OnResultExecuted(ResultExecutedContext context)
		{
			base.OnResultExecuted(context);
		}
	}
}
