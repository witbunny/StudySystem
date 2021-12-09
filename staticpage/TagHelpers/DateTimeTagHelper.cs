using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace staticpage.TagHelpers
{
	[HtmlTargetElement("datetime", Attributes = "asp-showicon, asp-only")]
	public class DateTimeTagHelper : TagHelper
	{
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "small";

			string ctt = output.GetChildContentAsync().Result.GetContent();
			DateTime dateTime = Convert.ToDateTime(ctt);

			output.Content.SetContent(dateTime.ToString("yyyy年MM月dd日 HH时mm分ss秒"));

			bool isshowicon = Convert.ToBoolean(context.AllAttributes["asp-showicon"].Value.ToString());

			if (isshowicon)
			{
				output.PreContent.SetHtmlContent("<span class=\"fa fa-calendar\"></span>");
			}

			output.Attributes.RemoveAll("asp-showicon");

			string only = context.AllAttributes["asp-only"].Value.ToString();

			if (only == "date")
			{
				output.Content.SetContent(dateTime.ToString("yyyy年MM月dd日"));
			}

			output.Attributes.Remove(context.AllAttributes["asp-only"]);

			base.Process(context, output);
		}
	}
}
