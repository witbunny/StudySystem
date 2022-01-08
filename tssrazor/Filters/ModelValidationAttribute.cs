using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tssrazor.Filters
{
	public class ModelValidationAttribute : Attribute, IPageFilter
	{
		public void OnPageHandlerSelected(PageHandlerSelectedContext context)
		{
		}

		public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
		{
			//if (context.HandlerMethod.HttpMethod == "Post")
			//{
			//	if (!context.ModelState.IsValid)
			//	{
			//		Dictionary<string, string> errors =
			//			context.ModelState.Where(m => m.Value.Errors.Any()).ToDictionary(
			//				m => m.Key,
			//				m => m.Value.Errors.Select(e => e.ErrorMessage).First());

			//		(context.HandlerInstance as PageModel).TempData[Keys.ErrorInPost] = errors;
			//		context.Result = new RedirectResult(context.HttpContext.Request.Path.Value);
			//	}
			//}
			//else
			//{
			//	var temp = (context.HandlerInstance as PageModel).TempData[Keys.ErrorInPost];
			//	if (temp != null)
			//	{
			//		Dictionary<string, string> errors = temp as Dictionary<string, string>;

			//		foreach (var item in errors)
			//		{
			//			context.ModelState.AddModelError(item.Key, item.Value);
			//		}
			//	}
			//}

			//(context.HttpContext.Request.Headers["Origin"][0] + context.HttpContext.Request.Path);
			//(context.HttpContext.Request.Host.Value +  context.HttpContext.Request.Path.Value);

		}

		public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
		{
		}
	}
}
