using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace staticpage.TagHelpers
{
	[HtmlTargetElement("pager", Attributes = "path, pageIndex")]
	public class PagerTagHelper : TagHelper
	{
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "a";

			var path = context.AllAttributes["path"].Value;
			var pageIndex = context.AllAttributes["pageIndex"].Value;

			output.Attributes.Add("href", $"{path}/Page-{pageIndex}");

			output.Attributes.Remove(context.AllAttributes["path"]);
			output.Attributes.RemoveAll("pageIndex");

			base.Process(context, output);
		}
	}
}
